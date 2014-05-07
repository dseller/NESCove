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
            return (Helper.IsSamePage((ushort)addressA, (ushort)addressB, C6502.PageSize) ? 0 : 1) + (branch ? 1 : 0);
        }

        protected void SetZero(IC6502 cpu, Func<bool> predicate)
        {
            SetFlag(cpu, StatusFlags.Zero, predicate);
        }

        protected void SetNegative(IC6502 cpu, Func<bool> predicate)
        {
            SetFlag(cpu, StatusFlags.Negative, predicate);
        }

        protected void SetCarry(IC6502 cpu, Func<bool> predicate)
        {
            SetFlag(cpu, StatusFlags.Carry, predicate);
        }

        protected void SetOverflow(IC6502 cpu, Func<bool> predicate)
        {
            SetFlag(cpu, StatusFlags.Overflow, predicate);
        }

        protected void SetFlag(IC6502 cpu, StatusFlags flag, Func<bool> predicate)
        {
            if (predicate())
                cpu.State.SetFlag((byte) flag);
            else
                cpu.State.ClearFlag((byte) flag);
        }

        public abstract int Execute(C6502 cpu, byte operand);
    }
}
