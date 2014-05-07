using NESCove.Core;
using NESCove.MOS6502.Addressing;

namespace NESCove.MOS6502.Opcodes
{
    public class ROR : OpcodeBase
    {
        public ROR(IAddressingType addressing) : base(addressing)
        {
        }

        public override int Execute(C6502 cpu, byte operand)
        {
            var state = cpu.State as ExecutionState;

            int v = operand;
            if (cpu.State.IsFlagSet((byte) StatusFlags.Carry))
                v |= 0x100;


            SetCarry(cpu, () => (v & 0x01) != 0);
            v >>= 1;
            v &= 0xFF;

            SetNegative(cpu, () => Helper.IsSigned((byte) v));
            SetZero(cpu, () => v == 0);

            // Hacky but it will do the trick. Accumulator Addressing is an outcast.
            if (AddressingType is AccumulatorAddressing)
                cpu.State.RegA = (byte)v;
            else
                cpu.Memory[AddressingType.GetAddress(cpu, state.Parameter)] = (byte)v;

            return 2;
        }
    }
}
