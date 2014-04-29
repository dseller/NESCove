using System;

namespace NESCove.MOS6502.Addressing
{
    public class PostIndexedIndirectAddressing : IAddressingType
    {
        public byte? ParameterSize { get { return 1; } }
        public byte GetOperand(C6502 cpu, ushort parameter)
        {
            UInt16 address1 = (ushort) (parameter & 0xFF);
            byte b1 = cpu.Memory[address1];
            byte b2 = cpu.Memory[(ushort)(address1 + 1)];
            UInt16 dataFromMemory = (ushort)((b2 << 8) | b1);
            return cpu.Memory[(ushort) (dataFromMemory + cpu.RegY)];
        }
    }
}
