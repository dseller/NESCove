using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NESCove.MOS6502.Addressing;

namespace NESCove.MOS6502.Opcodes
{
    public abstract class OpcodeBase : IOpcode
    {
        public IAddressingType AddressingType { get; set; }

        protected OpcodeBase(IAddressingType addressing)
        {
            AddressingType = addressing;
        }

        protected void SetNegative(C6502 cpu, byte operand)
        {
            if (operand > 0x7F)
                cpu.SetFlag(StatusFlags.Negative);
            else
                cpu.ResetFlag(StatusFlags.Negative);
        }

        protected void SetZero(C6502 cpu, byte operand)
        {
            if (operand == 0)
                cpu.SetFlag(StatusFlags.Zero);
            else
                cpu.ResetFlag(StatusFlags.Zero);
        }

        public Boolean IsSamePage(ushort address, ushort addressB)
        {
            return (int)(address / C6502.PageSize) == (int)(addressB / C6502.PageSize);
        }

        public int CalculateExtraCycles(int addressA, int addressB, Boolean branch = false)
        {
            return (IsSamePage((ushort)addressA, (ushort)addressB) ? 0 : 1) + (branch ? 1 : 0);
        }

        public abstract int Execute(C6502 cpu, ushort parameter);
    }
}
