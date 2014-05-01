using NESCove.MOS6502.Addressing;

namespace NESCove.MOS6502.Opcodes
{
    public class TXS : OpcodeBase
    {
        public TXS(IAddressingType addressing) 
            : base(addressing)
        {

        }

        public override int Execute(C6502 cpu, byte operand)
        {
            cpu.State.StackPointer = cpu.State.RegX;
            return 2;
        }
    }
}
