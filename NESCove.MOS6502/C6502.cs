using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NESCove.Core;

namespace NESCove.MOS6502
{
    public class C6502
    {
        // Special Purpose Registers
        public UInt16 ProgramCounter { get; set; }
        public Byte StackPointer { get; set; }      // Stack is at 0x0100 - 0x01FF. 
        public StatusFlags ProcessorStatus { get; set; }
        // General Purpose Registers
        public Byte RegA { get; set; }
        public Byte RegX { get; set; }
        public Byte RegY { get; set; }

        public IMemoryProvider Memory { get; private set; }

        public bool IsFlagSet(StatusFlags flag)
        {
            return (ProcessorStatus & flag) != 0;
        }

        public void SetFlag(StatusFlags flag)
        {
            ProcessorStatus |= flag;
        }

        public void ResetFlag(StatusFlags flag)
        {
            ProcessorStatus &= ~flag;
        }
    }
}
 