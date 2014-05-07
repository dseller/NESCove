using NESCove.Core;
using NESCove.MOS6502.Addressing;

namespace NESCove.MOS6502.Opcodes
{
    public class BIT : OpcodeBase
    {
        public BIT(IAddressingType addressing) : base(addressing)
        {
        }

        public override int Execute(C6502 cpu, byte operand)
        {
            SetNegative(cpu, () => Helper.IsSigned(operand));
            SetOverflow(cpu, () => (operand & 0x40) != 0);
            byte value = (byte) (operand & cpu.State.RegA);
            SetZero(cpu, () => value == 0);
            return 3;
        }
    }
}
