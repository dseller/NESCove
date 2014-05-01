using System;

namespace NESCove.Core
{
    [Flags]
    public enum StatusFlags : byte
    {
        Carry = 0x01,
        Zero = 0x02,
        InterruptDisable = 0x04,
        DecimalMode = 0x08,
        Break = 0x10,
        RESERVED = 0x20,
        Overflow = 0x40,
        Negative = 0x80
    }
}
