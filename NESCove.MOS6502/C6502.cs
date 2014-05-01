using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NESCove.Core;
using NESCove.MOS6502.Opcodes;
using System.Diagnostics;

namespace NESCove.MOS6502
{
    public class C6502 : IBasicCPU<byte, byte, ushort>
    {
        // Moved here to keep it out of Core
        /// <summary>
        /// Page size of the 6502 memory
        /// </summary>
        public const int PageSize = 256;

        public IBasicState<byte, byte, ushort> State { get; private set; }
        public IMemoryProvider<byte, ushort> Memory { get; private set; }

        /// <summary>
        /// Create a new 6502 instance with a test memory provider
        /// </summary>
        public C6502()
        {
            State = new ExecutionState();
            Memory = new TestMemoryProvider();
        }

        /// <summary>
        /// Create a new 6502 instance with a specfied memory provider
        /// </summary>
        /// <param name="memoryProvider">Memory provider to use</param>
        public C6502(MemoryProviderBase memoryProvider)
            : this()
        {
            Memory = memoryProvider;
        }

        public byte GetOperandSafe(IOpcode opcode)
        {
            if (!opcode.AddressingType.ParameterSize.HasValue) return 0;
            var parameterSize = opcode.AddressingType.ParameterSize.Value;
            State.Parameter = (ushort)Helper.CompositeInteger(Memory, State.ProgramCounter, parameterSize);
            State.ProgramCounter += parameterSize;
            return opcode.AddressingType.GetOperand(this, State.Parameter);
        }

        private int ExecuteNextOperation()
        {
            State.Opcode = Memory[State.ProgramCounter++];
            IOpcode handler = OpcodeFactory.GetOpcode(State.Opcode);
            if (handler == null)
                throw new Exception("Opcode not implemented!");
            var operand = GetOperandSafe(handler);
            return handler.Execute(this, operand );
        }

        public int Step(int iterations = 1)
        {
            if (iterations < 1) throw new ArgumentOutOfRangeException("iterations", iterations, "Must be greater than 0");
            int cost = 0;
            for (int iteration = 0; iteration < iterations; iteration++)
            {
                try
                {
                    cost += ExecuteNextOperation();
                }
                catch (OpcodeExecutionException oee)
                {
                    var ErrorTitle = String.Format("OEE Failure executing opcode {0:X2}", State.Opcode);
                    Debug.Fail(ErrorTitle, oee.ToString() + "\r\n" + ToString());
                    throw new Exception(ErrorTitle, oee);
                }
            }
            return cost;
        }

        public void Push(byte value)
        {
            Memory[0x01FF - State.StackPointer] = value;
            State.StackPointer--;
        }

        public byte Pop()
        {
            State.StackPointer++;
            return (byte) Memory[0x01FF - State.StackPointer];
        }

        public override string ToString()
        {
            /*
             * The performance impact of this is probably so insignificant that it's stupid
             * But I'm in one of those moods (JL)
             */
            var state = State; 
            StringBuilder builder = new StringBuilder();
            builder.AppendFormat("=======================================\r\n");
            builder.AppendFormat("  PC = {0:X4}\tSP= {1:X2}\r\n", state.ProgramCounter, state.StackPointer);
            builder.AppendFormat("   A = {0:X2}\tX = {1:X2}\t\tY = {2:X2}\r\n", state.RegA, state.RegX, state.RegY);
            builder.AppendFormat("=======================================\r\n\r\n");
            return builder.ToString();
        }
    }
}
 