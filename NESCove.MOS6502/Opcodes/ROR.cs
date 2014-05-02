using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NESCove.MOS6502.Addressing;

namespace NESCove.MOS6502.Opcodes
{
    public class ROR : OpcodeBase
    {
        public ROR(IAddressingType addressing) : base(addressing)
        {
        }

        public override int Execute(C6502 cpu, byte operand)
        {
            var state = cpu.State as ExecutionState;

            int v = operand;
            if (cpu.State.IsFlagSet((byte) StatusFlags.Carry))
                v |= 0x100;

            if ((v & 0x01) != 0)
                cpu.State.SetFlag((byte) StatusFlags.Carry);
            else
                cpu.State.ClearFlag((byte) StatusFlags.Carry);

            v >>= 1;
            v &= 0xFF;
            
            // TODO; Thank you Josh for removing the SetZero/SetNEgative again :p need to set ZERO/NEGATIVE even if it is not stored in A

            // Hacky but it will do the trick. Accumulator Addressing is an outcast.
            if (AddressingType is AccumulatorAddressing)
                cpu.State.RegA = (byte)v;
            else
                cpu.Memory[AddressingType.GetAddress(cpu, state.Parameter)] = (byte)v;

            return 2;
        }
    }
}
