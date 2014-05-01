using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NESCove.MOS6502.Addressing
{
    public class IndirectAddressing : IAddressingType
    {
        public byte? ParameterSize { get { return 2; } }
        public byte GetOperand(C6502 cpu, ushort parameter)
        {
            return cpu.Memory[GetAddress(cpu, parameter)];
        }

        public ushort GetAddress(C6502 cpu, ushort parameter)
        {
            //UInt16 address1 = (ushort)(parameter & 0xFF);
            byte b1 = cpu.Memory[parameter];
            byte b2 = cpu.Memory[(ushort)(parameter + 1)];
            return (ushort)((b2 << 8) | b1);
        }
    }
}
