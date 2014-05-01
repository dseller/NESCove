using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NESCove.MOS6502.Addressing;
using NESCove.Core;

namespace NESCove.MOS6502.Opcodes
{
    public class STA : OpcodeBase
    {
        public STA(IAddressingType addressing) 
            : base(addressing)
        {

        }

        public override int Execute(C6502 cpu, byte operand)
        {
            throw new NotImplementedException();
        }
    }
}
