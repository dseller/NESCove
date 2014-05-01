using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NESCove.MOS6502.Addressing;

namespace NESCove.MOS6502.Opcodes
{
    public class STX : OpcodeBase
    {
        public STX(IAddressingType addressing) 
            : base(addressing)
        {

        }

        public override int Execute(C6502 cpu, byte operand)
        {
            ExecutionState state = cpu.State as ExecutionState;
            if (state == null)
                throw new Exception("Something BAAAADD happened");

            cpu.Memory[AddressingType.GetAddress(cpu, state.Parameter)] = state.RegX;

            // I don't know what the fuck this is but it is 2 everywhere (DS).
            return 2;
        }
    }
}
