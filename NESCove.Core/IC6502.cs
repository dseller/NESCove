using System;
namespace NESCove.Core
{
    public interface IC6502
    {
        IMemoryProvider Memory { get; }
        byte Pop();
        void Push(byte value);
        IExecutionState State { get; }
        int Step(int iterations = 1);
    }
}
