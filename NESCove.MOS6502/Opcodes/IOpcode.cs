using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NESCove.MOS6502.Addressing;

namespace NESCove.MOS6502.Opcodes
{
    public interface IOpcode
    {
        IAddressingType AddressingType { get; }
        void Execute(C6502 cpu, ushort parameter);
    }
}
