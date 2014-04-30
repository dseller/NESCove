using NESCove.MOS6502.Addressing;

namespace NESCove.MOS6502.Opcodes
{
    public class TAX : OpcodeBase
    {
        public TAX(IAddressingType addressing) 
            : base(addressing)
        {

        }

        public override int Execute(C6502 cpu, ushort parameter)
        {
            byte operand = cpu.RegA;
            SetNegative(cpu, operand);
            SetZero(cpu, operand);
            cpu.RegX = operand;
            return 0;
        }
    }
}
