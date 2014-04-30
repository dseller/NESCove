using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NESCove.MOS6502.Addressing
{
    public class ZeroPageIndexedYAddressing : IAddressingType
    {
        public byte? ParameterSize { get { return 1; } }
        public byte GetOperand(C6502 cpu, ushort parameter)
        {
            return cpu.Memory[(ushort)(cpu.RegY + (parameter & 0xFF))];
        }
    }
}
