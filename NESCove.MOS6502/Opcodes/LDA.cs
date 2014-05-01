using System;
using NESCove.Core;
using NESCove.MOS6502.Addressing;

namespace NESCove.MOS6502.Opcodes
{
    public class LDA : OpcodeBase
    {
        public LDA(IAddressingType addressing)
            : base(addressing)
        {

        }


        public override int Execute(C6502 cpu, byte operand)
        {          
            cpu.State.RegA = operand;
            return 2;
        }
    }
}
