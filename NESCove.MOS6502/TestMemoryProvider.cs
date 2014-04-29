using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NESCove.Core;

namespace NESCove.MOS6502
{
    public class TestMemoryProvider : IMemoryProvider 
    {
        private byte[] _testArray = new byte[0x1000];

        public byte this[ushort address]
        {
            get { return _testArray[address]; }
            set { _testArray[address] = value; }
        }
    }
}
