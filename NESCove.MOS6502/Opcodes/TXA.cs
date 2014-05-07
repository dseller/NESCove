using NESCove.Core;
using NESCove.MOS6502.Addressing;

namespace NESCove.MOS6502.Opcodes
{
    public class TXA : OpcodeBase
    {
        public TXA(IAddressingType addressing) 
            : base(addressing)
        {

        }

        public override int Execute(C6502 cpu, byte operand)
        {
            cpu.State.RegA = cpu.State.RegX;
            SetNegative(cpu, () => Helper.IsSigned(cpu.State.RegA));
            SetZero(cpu, () => cpu.State.RegA == 0);
            return 2;
        }
    }
}
