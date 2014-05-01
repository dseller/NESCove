using NESCove.MOS6502.Addressing;

namespace NESCove.MOS6502.Opcodes
{
    public class TSX : OpcodeBase
    {
        public TSX(IAddressingType addressing) 
            : base(addressing)
        {

        }

        public override int Execute(C6502 cpu, byte operand)
        {
            cpu.State.RegX = cpu.State.StackPointer;
            return 2;
        }
    }
}
