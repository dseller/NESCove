using System;

namespace NESCove.Core
{
    /// <summary>
    /// Memory Provider interface
    /// </summary>
    public interface IMemoryProvider
    {
        byte this[ushort address] { get; set; }
    }
}
