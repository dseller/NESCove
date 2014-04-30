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

        public override int Execute(C6502 cpu, ushort parameter)
        {
            switch (cpu.Opcode)
            {
                case 0x85: return 3;
                case 0x95: return 4;
                case 0x8D: return 4;
                case 0x9D: return 4; // +1 if cross boundary
                case 0x99: return 4; // +1 boundary
                case 0x81: return 6;
                case 0x91: return 5; // +1 boundary
            }
            throw new OpcodeExecutionException();
        }
    }
}
