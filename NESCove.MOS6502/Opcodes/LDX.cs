using NESCove.MOS6502.Addressing;

namespace NESCove.MOS6502.Opcodes
{
    public class LDX : OpcodeBase
    {
        public LDX(IAddressingType addressing)
            : base(addressing)
        {

        }

        public override int Execute(C6502 cpu, ushort parameter)
        {
            byte operand = AddressingType.GetOperand(cpu, parameter);
            SetNegative(cpu, operand);
            SetZero(cpu, operand);
            cpu.RegX = operand;
            switch (cpu.Opcode)
            {
                case 0xA1: return 2;
                case 0xA6: return 3;
                case 0xB6: return 4;
                case 0xAE: return 4;
                case 0xBE: return 4 + CalculateExtraCycles(-1 + cpu.ProgramCounter - AddressingType.ParameterSize.Value, parameter);
            }
        }
    }
}
