using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NESCove.Core
{
    /// <summary>
    /// Basic CPU interface
    /// </summary>
    /// <typeparam name="O">Opcode value type</typeparam>
    /// <typeparam name="W">Word value type</typeparam>
    /// <typeparam name="M">Memory size value type</typeparam>
    public interface IBasicState<O, W, M> 
    {
        /// <summary>
        /// Last read opcode
        /// </summary>
        O Opcode { get; set; }
        /// <summary>
        /// Last read parameter
        /// </summary>
        M Parameter { get; set; }
        /// <summary>
        /// Address of next instruction
        /// </summary>
        M ProgramCounter { get; set; }
        /// <summary>
        /// Index of stack pointer
        /// </summary>
        byte StackPointer { get; set; }
        byte ProcessorStatus { get; set; }
        W RegA { get; set; }
        W RegX { get; set; }
        W RegY { get; set; }
        bool IsFlagSet(W flag);
        void SetFlag(W flag);
        void ClearFlag(W flag);
    }
}
