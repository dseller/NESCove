using System;

namespace NESCove.MOS6502.Addressing
{
    public class ZeroPageAddressing : IAddressingType
    {
        public byte? ParameterSize { get { return 1; } }
        public byte GetOperand(C6502 cpu, ushort parameter)
        {
            UInt16 address = (UInt16) (parameter & 0xFF);
            return cpu.Memory[address];
        }
    }
}
