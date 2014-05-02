using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NESCove.MOS6502.Opcodes
{
    public class ORA : OpcodeBase
    {
        public ORA(Addressing.IAddressingType a) : base(a) { }

        public override int Execute(C6502 cpu, byte operand)
        {
            cpu.State.RegA |= operand;
            return 2;
        }
    }
}
