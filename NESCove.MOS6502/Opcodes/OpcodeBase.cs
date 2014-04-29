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
        protected IAddressingType AddressingType { get; set; }

        protected OpcodeBase(IAddressingType addressing)
        {
            AddressingType = addressing;
        }

        public abstract void Execute(C6502 cpu, ushort parameter);
    }
}
