using System;
using NESCove.MOS6502.Addressing;

namespace NESCove.MOS6502.Opcodes
{
    public interface IOpcode
    {
        IAddressingType AddressingType { get; }
        int Execute(C6502 cpu, byte operand);
    }
}
