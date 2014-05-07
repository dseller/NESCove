using NESCove.Core;
using NESCove.MOS6502.Addressing;

namespace NESCove.MOS6502.Opcodes
{
    public class PLA : OpcodeBase
    {
        public PLA(IAddressingType addressing) : base(addressing)
        {
        }

        public override int Execute(C6502 cpu, byte operand)
        {
            cpu.State.RegA = cpu.Pop();
            SetNegative(cpu, () => Helper.IsSigned(cpu.State.RegA));
            SetZero(cpu, () => cpu.State.RegA == 0);
            return 4;
        }
    }
}
