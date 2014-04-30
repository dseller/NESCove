using NESCove.Core;
using NESCove.MOS6502.Addressing;

namespace NESCove.MOS6502.Opcodes
{
    public class LDA : OpcodeBase
    {
        public LDA(IAddressingType addressing)
            : base(addressing)
        {

        }


        public override int Execute(C6502 cpu, ushort parameter)
        {
            byte operand = AddressingType.GetOperand(cpu, parameter);            
            SetNegative(cpu, operand);
            SetZero(cpu, operand);
            cpu.RegA = operand;

            // If you have any ideas on how to tidy this up, please do (JL)
            switch (cpu.Opcode)
            {
                case 0xA9: return 2;
                case 0xA5: return 3;
                case 0xB5: return 4;
                case 0xAD: return 4;
                case 0xBD: return 4 + CalculateExtraCycles(-1 + cpu.ProgramCounter - AddressingType.ParameterSize.Value, parameter);
                case 0xB9: return 4 + CalculateExtraCycles(-1 + cpu.ProgramCounter - AddressingType.ParameterSize.Value, parameter);
                case 0xA1: return 6;
                case 0xB1: return 5 + CalculateExtraCycles(-1 + cpu.ProgramCounter - AddressingType.ParameterSize.Value, parameter);
            }

            throw new OpcodeExecutionException();
        }
    }
}
