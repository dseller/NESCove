using NESCove.MOS6502.Addressing;

namespace NESCove.MOS6502.Opcodes
{
    public class ADC : OpcodeBase
    {
        public ADC(IAddressingType addressing) : base(addressing)
        {
        }

        public override int Execute(C6502 cpu, byte operand)
        {
            int result = (cpu.State.RegA + operand + (cpu.State.ProcessorStatus & (byte) StatusFlags.Carry));
            SetOverflow(cpu, () => ((cpu.State.RegA ^ operand) & 0x80) == 0 && ((cpu.State.RegA ^ result) & 0x80) != 0);
            cpu.State.RegA = (byte)(result & 0xFF);
            SetNegative(cpu, () => (cpu.State.RegA & 0x80) != 0);
            SetZero(cpu, () => cpu.State.RegA == 0);
            SetCarry(cpu, () => (result & 0x100) != 0);
            return 2;
        }
    }
}
