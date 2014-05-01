using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NESCove.MOS6502.Addressing;

namespace NESCove.MOS6502.Opcodes
{
    public class JSR : OpcodeBase
    {
        public JSR(IAddressingType addressing) : base(addressing)
        {
        }

        public override int Execute(C6502 cpu, byte operand)
        {
            var state = cpu.State as ExecutionState;

            ushort toPush = (ushort) (cpu.State.ProgramCounter - 1);
            // TODO: check if this is the correct order. I guess so (DS)
            cpu.Push((byte)((toPush >> 8) & 0xFF));
            cpu.Push((byte) (toPush & 0xFF));

            cpu.State.ProgramCounter = AddressingType.GetAddress(cpu, state.Parameter);
            return 6;
        }
    }
}
