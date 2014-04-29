using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NESCove.MOS6502.Opcodes
{
    public interface IOpcode
    {
        void Execute(C6502 cpu, ushort parameter);
    }
}
