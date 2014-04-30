namespace NESCove.MOS6502.Addressing
{
    public class ZeroPageIndexedXAddressing : IAddressingType
    {
        public byte? ParameterSize { get { return 1; } }
        public byte GetOperand(C6502 cpu, ushort parameter)
        {
            return cpu.Memory[(ushort)(cpu.RegX + (parameter & 0xFF))];
        }

        public EnumAddressingType TypeEnum
        {
            get
            {
                return EnumAddressingType.ZeroPageIndexed;
            }
        }
    }
}
