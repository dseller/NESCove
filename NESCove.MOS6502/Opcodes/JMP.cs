using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NESCove.MOS6502.Addressing;

namespace NESCove.MOS6502.Opcodes
{
    public class JMP : OpcodeBase
    {
        public JMP(IAddressingType addressing) : base(addressing)
        {
        }

        public override int Execute(C6502 cpu, byte operand)
        {
            var state = cpu.State as ExecutionState;
            cpu.State.ProgramCounter = AddressingType.GetAddress(cpu, state.Parameter);
            return 3;
        }
    }
}
