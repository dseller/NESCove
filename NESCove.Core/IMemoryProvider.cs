using System;

namespace NESCove.Core
{
    public interface IMemoryProvider
    {
        byte this[UInt16 address] { get; set; }
    }
}
