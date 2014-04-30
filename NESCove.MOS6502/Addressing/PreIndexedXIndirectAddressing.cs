using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NESCove.MOS6502.Addressing
{
    public class PreIndexedXIndirectAddressing : IAddressingType
    {
        public byte? ParameterSize { get { return 1; } }
        public byte GetOperand(C6502 cpu, ushort parameter)
        {
            UInt16 address1 = (ushort) ((parameter & 0xFF) + cpu.RegX);
            byte b1 = cpu.Memory[address1];
            byte b2 = cpu.Memory[(ushort) (address1 + 1)];
            UInt16 address2 = (ushort) ((b2 << 8) | b1);
            return cpu.Memory[address2];
        }
    }
}
