using NESCove.MOS6502.Addressing;

namespace NESCove.MOS6502.Opcodes
{
    public class TYA : OpcodeBase
    {
        public TYA(IAddressingType addressing) 
            : base(addressing)
        {
        }

        public override int Execute(C6502 cpu, byte operand)
        {
            cpu.State.RegA = cpu.State.RegY;
            return 2;
        }
    }
}
