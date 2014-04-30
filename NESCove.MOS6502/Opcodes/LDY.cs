using NESCove.Core;
using NESCove.MOS6502.Addressing;

namespace NESCove.MOS6502.Opcodes
{
    public class LDY : OpcodeBase
    {
        public LDY(IAddressingType addressing) 
            : base(addressing)
        {

        }

        public override int Execute(C6502 cpu, ushort parameter)
        {
            byte operand = AddressingType.GetOperand(cpu, parameter);
            SetNegative(cpu, operand);
            SetZero(cpu, operand); 
            cpu.RegY = operand;

            switch (cpu.Opcode)
            {
                case 0xA0: return 2;
                case 0xA4: return 3;
                case 0xB4: return 4;
                case 0xAC: return 4;
                case 0xBC: return 4 + CalculateExtraCycles(-1 + cpu.ProgramCounter - AddressingType.ParameterSize.Value, parameter);
            }

            throw new OpcodeExecutionException();
        }
    }
}
