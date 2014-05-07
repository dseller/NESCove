using NESCove.Core;
using NESCove.MOS6502.Addressing;

namespace NESCove.MOS6502.Opcodes
{
    public class INC : OpcodeBase
    {
        public INC(IAddressingType addressing) : base(addressing)
        {
        }

        public override int Execute(C6502 cpu, byte operand)
        {
            var state = cpu.State as ExecutionState;
            byte value = (byte) (operand + 1);
            cpu.Memory[AddressingType.GetAddress(cpu, state.Parameter)] = value;
            SetNegative(cpu, () => Helper.IsSigned(value));
            SetZero(cpu, () => value == 0);
            return 2;
        }
    }
}
