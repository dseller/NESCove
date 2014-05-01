using NESCove.MOS6502.Addressing;

namespace NESCove.MOS6502.Opcodes
{
    public class INX : OpcodeBase
    {
        public INX(IAddressingType addressing) : base(addressing)
        {
        }

        public override int Execute(C6502 cpu, byte operand)
        {
            cpu.State.RegX++;
            return 2; //?
        }
    }
}
