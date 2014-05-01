
namespace NESCove.MOS6502.Addressing
{
    public class ImmediateAddressing : IAddressingType
    {
        public byte? ParameterSize { get { return 1; } }
        public byte GetOperand(C6502 cpu, ushort parameter)
        {
            return (byte) (parameter & 0xFF);
        }

        public ushort GetAddress(C6502 cpu, ushort parameter)
        {
            // Basically not implemented... todo, check if should throw exception
            return (byte) (parameter & 0xFF);
        }
    }
}
