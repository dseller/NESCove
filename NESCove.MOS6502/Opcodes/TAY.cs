using NESCove.MOS6502.Addressing;

namespace NESCove.MOS6502.Opcodes
{
    public class TAY : OpcodeBase
    {
        public TAY(IAddressingType addressing) 
            : base(addressing)
        {

        }

        public override int Execute(C6502 cpu, ushort parameter)
        {
            byte operand = cpu.RegA;
            SetNegative(cpu, operand);
            SetZero(cpu, operand);
            cpu.RegY = operand;
            return 2;
        }
    }
}
