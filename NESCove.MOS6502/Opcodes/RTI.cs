using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NESCove.MOS6502.Addressing;

namespace NESCove.MOS6502.Opcodes
{
    public class RTI : OpcodeBase
    {
        public RTI(IAddressingType addressing) : base(addressing)
        {
        }

        public override int Execute(C6502 cpu, byte operand)
        {
            cpu.State.ProcessorStatus = cpu.Pop();
            byte b1 = cpu.Pop();
            byte b2 = cpu.Pop();
            cpu.State.ProgramCounter = (ushort)((b2 << 8) | b1);
            return 6;
        }
    }
}
