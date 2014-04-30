
namespace NESCove.MOS6502.Addressing
{
    public class ImmediateAddressing : IAddressingType
    {
        public byte? ParameterSize { get { return 1; } }
        public byte GetOperand(C6502 cpu, ushort parameter)
        {
            return (byte) (parameter & 0xFF);
        }

        public EnumAddressingType TypeEnum
        {
            get
            {
                return EnumAddressingType.Immediate;
            }
        }
    }
}
