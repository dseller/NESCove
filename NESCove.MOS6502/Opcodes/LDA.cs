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
            return 0;
        }
    }
}
