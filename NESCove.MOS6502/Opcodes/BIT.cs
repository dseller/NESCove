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
            if ((operand & 0x80) != 0)
                cpu.State.SetFlag((byte) StatusFlags.Negative);
            else
                cpu.State.ClearFlag((byte) StatusFlags.Negative);

            if ((operand & 0x40) != 0)
                cpu.State.SetFlag((byte)StatusFlags.Overflow);
            else
                cpu.State.ClearFlag((byte)StatusFlags.Overflow);

            byte value = (byte) (operand & cpu.State.RegA);
            if (value == 0)
                cpu.State.SetFlag((byte) StatusFlags.Zero);
            else
                cpu.State.ClearFlag((byte) StatusFlags.Zero);

            return 3;
        }
    }
}
