
namespace NESCove.MOS6502.Addressing
{
    /// <summary>
    /// Empty class for no addressing
    /// </summary>
    public class ImpliedAddressing : IAddressingType
    {
        public byte? ParameterSize { get { return null; } }
        public byte GetOperand(C6502 cpu, ushort parameter)
        {
            return 0;
        }

        public ushort GetAddress(C6502 cpu, ushort parameter)
        {
            return 0;
        }
    }
}
 