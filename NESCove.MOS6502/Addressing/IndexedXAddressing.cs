namespace NESCove.MOS6502.Addressing
{
    public class IndexedXAddressing : IAddressingType
    {
        public byte? ParameterSize { get { return 2; } }
        public byte GetOperand(C6502 cpu, ushort parameter)
        {
            return cpu.Memory[(ushort) (cpu.RegX + parameter)];
        }
    }
}
