using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NESCove.MOS6502.Addressing;
using NESCove.Core;

namespace NESCove.MOS6502.Opcodes
{
    public abstract class OpcodeBase : IOpcode
    {
        public IAddressingType AddressingType { get; set; }

        protected OpcodeBase(IAddressingType addressing)
        {
            AddressingType = addressing;
        }

        public int CalculateExtraCycles(int addressA, int addressB, Boolean branch = false)
        {
            return (Helper.IsSamePage((ushort)addressA, (ushort)addressB) ? 0 : 1) + (branch ? 1 : 0);
        }

        public abstract int Execute(C6502 cpu, byte operand);
    }
}
