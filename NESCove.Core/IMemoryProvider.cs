using System;

namespace NESCove.Core
{
    /// <summary>
    /// Memory Provider interface
    /// </summary>
    /// <typeparam name="W">Word value type</typeparam>
    /// <typeparam name="M">Memory range value type</typeparam>
    public interface IMemoryProvider<W, M> : IGenericMemoryProvider
    {
        W this[M address] { get; set; }
    }

    public interface IGenericMemoryProvider
    {
        int this[int address] { get; set; }
    }
}
