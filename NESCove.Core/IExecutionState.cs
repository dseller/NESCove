using System;
namespace NESCove.Core
{
    public interface IExecutionState
    {
        void ClearFlag(byte flag);
        bool IsFlagSet(byte flag);
        byte Opcode { get; set; }
        ushort Parameter { get; set; }
        byte ProcessorStatus { get; set; }
        ushort ProgramCounter { get; set; }
        byte RegA { get; set; }
        byte RegX { get; set; }
        byte RegY { get; set; }
        void SetFlag(byte flag);
        byte StackPointer { get; set; }
    }
}
