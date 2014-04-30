using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NESCove.MOS6502.Addressing
{
    public enum EnumAddressingType
    {
        Immediate,
        ZeroPage,
        Absoloute,
        Implied,
        Indexed,
        ZeroPageIndexed,
        Indirect,
        PreIndexedIndirect,
        PostIndexedIndirect
    }
}
