using NESCove.MOS6502.Addressing;

namespace NESCove.MOS6502.Opcodes
{
    public class SEI : OpcodeBase
    {
        public SEI(IAddressingType addressing) 
            : base(addressing)
        {
        }

        public override int Execute(C6502 cpu, byte operand)
        {
            cpu.State.SetFlag((byte)StatusFlags.InterruptDisable);
            return 2;
        }
    }
}
