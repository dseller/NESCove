using NESCove.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NESCove.MOS6502
{
    /// <summary>
    /// Represents the state of a CPU
    /// </summary>
    public class ExecutionState : IExecutionState 
    {
        public ExecutionState()
        {
            // Stack pointer is initialized by ROM.
            // StackPointer = 0xFF;
        }

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
        public byte ProcessorStatus { get; set; }
        // Register values
        private byte _A, _X, _Y, _SP;
        /// <summary>
        /// Pointer in stack
        /// </summary>
        public byte StackPointer  // Stack is at 0x0100 - 0x01FF. 
        {
            get { return _SP; }
            set                   
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


        public bool IsFlagSet(byte flag)
        {
            return (ProcessorStatus & flag) != 0;
        }

        public void SetFlag(byte flag)
        {
            ProcessorStatus |= flag;
        }

        public void ClearFlag(byte flag)
        {
            ProcessorStatus &= (byte)~flag;
        }

        private void UpdateALUFlags(byte value)
        {
            // Update Negative Flag
            if (value > 0x7F)
                SetFlag((byte)StatusFlags.Negative);
            else
                ClearFlag((byte)StatusFlags.Negative);
            // Update Zero Flag
            if (value == 0)
                SetFlag((byte)StatusFlags.Zero);
            else
                ClearFlag((byte)StatusFlags.Zero);
        }

    }
}
