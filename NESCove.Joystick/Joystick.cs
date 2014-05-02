using NESCove.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NESCove.Joystick
{
    public class Joystick : IMemoryProvider<byte, byte>
    {
        public byte this[byte address]
        {
            get
            {
                
            }
            set
            {
                
            }
        }

        public int this[int address]
        {
            get
            {
                return (byte)this[(byte)address];
            }
            set
            {
                this[(byte)address] = (byte)value;
            }
        }
    }
}
