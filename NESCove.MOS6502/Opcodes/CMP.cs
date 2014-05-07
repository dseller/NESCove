using NESCove.MOS6502.Addressing;

namespace NESCove.MOS6502.Opcodes
{
    public class CMP : OpcodeBase
    {
        public CMP(IAddressingType addressing) : base(addressing)
        {
        }

        public override int Execute(C6502 cpu, byte operand)
        {
            SetCarry(cpu, () => cpu.State.RegA > operand);
            byte result = (byte)(cpu.State.RegA - operand);
            SetNegative(cpu, () => (result & 0x80) != 0);
            SetZero(cpu, () => result == 0);
            return 2;
        }
    }
}
