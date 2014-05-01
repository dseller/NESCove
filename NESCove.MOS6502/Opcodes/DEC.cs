using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NESCove.MOS6502.Addressing;

namespace NESCove.MOS6502.Opcodes
{
    public class DEC : OpcodeBase
    {
        public DEC(IAddressingType addressing) : base(addressing)
        {
        }

        public override int Execute(C6502 cpu, byte operand)
        {
            var state = cpu.State as ExecutionState;
            // TODO: Thank you Nevercast, for removing my SetZero/SetNegative methods ;-)
            cpu.Memory[AddressingType.GetAddress(cpu, state.Parameter)] = (byte) (operand - 1);
            return 2;
        }
    }
}
