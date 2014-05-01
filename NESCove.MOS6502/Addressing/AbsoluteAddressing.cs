namespace NESCove.MOS6502.Addressing
{
    public class AbsoluteAddressing : IAddressingType
    {
        public byte? ParameterSize { get { return 2; } }
        public byte GetOperand(C6502 cpu, ushort parameter)
        {
            return cpu.Memory[GetAddress(cpu, parameter)];
        }

        public ushort GetAddress(C6502 cpu, ushort parameter)
        {
            return parameter;
        }
    }
}
