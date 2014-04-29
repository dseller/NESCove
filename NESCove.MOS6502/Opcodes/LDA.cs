using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NESCove.MOS6502.Addressing;

namespace NESCove.MOS6502.Opcodes
{
    public class LDA : OpcodeBase
    {
        public LDA(IAddressingType addressing) 
            : base(addressing)
        {

        }


        public override void Execute(C6502 cpu, ushort parameter)
        {
            byte operand = AddressingType.GetOperand(cpu, parameter);
            if (operand > 0x7F)
                cpu.SetFlag(StatusFlags.Negative);
            else
                cpu.ResetFlag(StatusFlags.Negative);
            if (operand == 0)
                cpu.SetFlag(StatusFlags.Zero);
            else
                cpu.ResetFlag(StatusFlags.Zero);
            cpu.RegA = operand;
        }
    }
}
