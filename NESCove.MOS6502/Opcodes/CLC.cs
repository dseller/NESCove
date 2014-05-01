using NESCove.MOS6502.Addressing;

namespace NESCove.MOS6502.Opcodes
{
    public class CLC : OpcodeBase
    {
        public CLC(IAddressingType addressing) 
            : base(addressing)
        {
        }

        public override int Execute(C6502 cpu, byte operand)
        {
            cpu.State.ClearFlag((byte)StatusFlags.Carry);
            return 2;
        }
    }
}
