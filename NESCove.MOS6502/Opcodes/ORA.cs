﻿using NESCove.MOS6502.Addressing;

namespace NESCove.MOS6502.Opcodes
{
    public class ORA : OpcodeBase
    {
        public ORA(IAddressingType a) : base(a) { }

        public override int Execute(C6502 cpu, byte operand)
        {
            cpu.State.RegA |= operand;
            return 2;
        }
    }
}
