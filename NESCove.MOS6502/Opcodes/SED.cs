using NESCove.MOS6502.Addressing;

namespace NESCove.MOS6502.Opcodes
{
    public class SED : OpcodeBase
    {
        public SED(IAddressingType addressing) : base(addressing)
        {
        }

        public override int Execute(C6502 cpu, byte operand)
        {
            cpu.State.SetFlag((byte)StatusFlags.DecimalMode);
            return 2;
        }
    }
}
