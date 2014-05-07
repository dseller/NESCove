using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NESCove.MOS6502.Addressing;

namespace NESCove.MOS6502.Opcodes
{
    public class CPY : OpcodeBase
    {
        public CPY(IAddressingType addressing) : base(addressing)
        {
        }

        public override int Execute(C6502 cpu, byte operand)
        {
            // Set carry if Y >= operand
            if (cpu.State.RegY > operand)
                cpu.State.SetFlag((byte)StatusFlags.Carry);
            else
                cpu.State.ClearFlag((byte)StatusFlags.Carry);

            byte result = (byte)(cpu.State.RegY - operand);

            // Set negative if signed bit is set
            if ((result & 0x80) != 0)
                cpu.State.SetFlag((byte)StatusFlags.Negative);
            else
                cpu.State.ClearFlag((byte)StatusFlags.Negative);

            // Set zero if result = 0
            if (result == 0)
                cpu.State.SetFlag((byte)StatusFlags.Zero);
            else
                cpu.State.ClearFlag((byte)StatusFlags.Zero);

            return 2;
        }
    }
}
