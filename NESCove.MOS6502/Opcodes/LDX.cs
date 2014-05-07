using NESCove.Core;
using NESCove.MOS6502.Addressing;

namespace NESCove.MOS6502.Opcodes
{
    public class LDX : OpcodeBase
    {
        public LDX(IAddressingType addressing)
            : base(addressing)
        {

        }

        public override int Execute(C6502 cpu, byte operand)
        {
            cpu.State.RegX = operand;
            SetNegative(cpu, () => Helper.IsSigned(cpu.State.RegX));
            SetZero(cpu, () => cpu.State.RegX == 0);
            return 2;
        }
    }
}
