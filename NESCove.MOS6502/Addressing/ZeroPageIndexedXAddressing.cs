namespace NESCove.MOS6502.Addressing
{
    public class ZeroPageIndexedXAddressing : IAddressingType
    {
        public byte? ParameterSize { get { return 1; } }
        public byte GetOperand(C6502 cpu, ushort parameter)
        {
            return cpu.Memory[GetAddress(cpu, parameter)];
        }

        public ushort GetAddress(C6502 cpu, ushort parameter)
        {
            return (ushort) (cpu.State.RegX + (parameter & 0xFF));
        }
    }
}
