namespace NESCove.MOS6502.Addressing
{
    public class AccumulatorAddressing : IAddressingType
    {
        public byte? ParameterSize { get { return 0; } }
        public byte GetOperand(C6502 cpu, ushort parameter)
        {
            return cpu.State.RegA;
        }

        public ushort GetAddress(C6502 cpu, ushort parameter)
        {
            // TODO: maybe NotSupportedException() ?
            return cpu.State.RegA;
        }
    }
}
