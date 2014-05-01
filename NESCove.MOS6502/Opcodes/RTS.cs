using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NESCove.MOS6502.Addressing;

namespace NESCove.MOS6502.Opcodes
{
    public class RTS : OpcodeBase
    {
        public RTS(IAddressingType addressing) : base(addressing)
        {
        }

        public override int Execute(C6502 cpu, byte operand)
        {
            byte b1 = cpu.Pop();
            byte b2 = cpu.Pop();

            // low byte first, b1 is low byte
            ushort address = (ushort) ((b2 << 8) | b1);

            cpu.State.ProgramCounter = (ushort) (address + 1);

            return 6;
        }
    }
}
