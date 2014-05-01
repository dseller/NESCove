using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NESCove.Core
{
    /// <summary>
    /// Represents the state of a CPU
    /// </summary>
    public class ExecutionState
    {
        /// <summary>
        /// Last read Opcode
        /// </summary>
        public Byte Opcode { get; set; }
        /// <summary>
        /// Last read parameter
        /// </summary>
        public UInt16 Parameter { get; set; }
        /// <summary>
        /// CPU Program Counter (Pointer to next instruction)
        /// </summary>
        public ushort ProgramCounter { get; set; }
        private StatusFlags ProcessorStatus;
        // Register values
        private byte _A, _X, _Y, _SP;
        /// <summary>
        /// Pointer in stack
        /// </summary>
        public byte StackPointer  // Stack is at 0x0100 - 0x01FF. 
        {
            get { return _SP; }
            set                   // We can also use this for StackOverflow/Underrun (If 6502 supports it)
            {
                _SP = value;
                UpdateALUFlags(_SP);
            }
        }
        /// <summary>
        /// Accumulator register
        /// </summary>
        public byte RegA
        {
            get { return _A; }
            set
            {
                _A = value;
                UpdateALUFlags(_A);
            }
        }
        /// <summary>
        /// Register X
        /// </summary>
        public byte RegX
        {
            get { return _X; }
            set
            {
                _X = value;
                UpdateALUFlags(_X);
            }
        }
        /// <summary>
        /// Register Y
        /// </summary>
        public byte RegY
        {
            get { return _Y; }
            set
            {
                _Y = value;
                UpdateALUFlags(_Y);
            }
        }


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

        private void UpdateALUFlags(byte value)
        {
            // Update Negative Flag
            if (value > 0x7F)
                SetFlag(StatusFlags.Negative);
            else
                ResetFlag(StatusFlags.Negative);
            // Update Zero Flag
            if (value == 0)
                SetFlag(StatusFlags.Zero);
            else
                ResetFlag(StatusFlags.Zero);
        }

    }
}
