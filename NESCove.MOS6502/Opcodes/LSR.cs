using NESCove.MOS6502.Addressing;

namespace NESCove.MOS6502.Opcodes
{
    public class LSR : OpcodeBase
    {
        public LSR(IAddressingType addressing) : base(addressing)
        {
        }

        public override int Execute(C6502 cpu, byte operand)
        {
            var state = cpu.State as ExecutionState;

            SetCarry(cpu, () => (operand & 0x01) != 0);
            int result = operand >> 1;
            result &= 0xFF;
            // Negative is always set in this opcode
            SetNegative(cpu, () => true);
            SetZero(cpu, () => result == 0);

            // Hacky but it will do the trick. Accumulator Addressing is an outcast.
            if (AddressingType is AccumulatorAddressing)
                cpu.State.RegA = (byte)result;
            else
                cpu.Memory[AddressingType.GetAddress(cpu, state.Parameter)] = (byte)result;

            return 2;
        }
    }
}
