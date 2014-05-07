using NESCove.Core;
using NESCove.MOS6502.Addressing;

namespace NESCove.MOS6502.Opcodes
{
    public class TAY : OpcodeBase
    {
        public TAY(IAddressingType addressing) 
            : base(addressing)
        {

        }

        public override int Execute(C6502 cpu, byte operand)
        {
            cpu.State.RegY = cpu.State.RegA;
            SetNegative(cpu, () => Helper.IsSigned(cpu.State.RegY));
            SetZero(cpu, () => cpu.State.RegY == 0);
            return 2;
        }
    }
}
