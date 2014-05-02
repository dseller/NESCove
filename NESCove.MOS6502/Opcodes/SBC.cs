using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NESCove.MOS6502.Addressing;

namespace NESCove.MOS6502.Opcodes
{
    public class SBC : OpcodeBase
    {
        public SBC(IAddressingType addressing)
            : base(addressing)
        {
        }

        public override int Execute(C6502 cpu, byte operand)
        {
            int result = (cpu.State.RegA - operand - (1 - (cpu.State.ProcessorStatus & (byte)StatusFlags.Carry)));

            if (((cpu.State.RegA ^ operand) & 0x80) != 0 && ((cpu.State.RegA ^ result) & 0x80) != 0)
                cpu.State.SetFlag((byte)StatusFlags.Overflow);
            else
                cpu.State.ClearFlag((byte)StatusFlags.Overflow);



            if ((result & 0x100) == 0)
                cpu.State.SetFlag((byte)StatusFlags.Carry);
            else
                cpu.State.ClearFlag((byte)StatusFlags.Carry);
            cpu.State.RegA = (byte)(result & 0xFF);
            return 2;
        }
    }
}
