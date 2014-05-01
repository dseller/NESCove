using NESCove.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NESCove.MOS6502
{
    public abstract class MemoryProviderBase : IMemoryProvider<byte, ushort>
    {
        public abstract byte this[ushort address] { get; set; }

        public abstract int this[int address] { get; set; }
    }
}
