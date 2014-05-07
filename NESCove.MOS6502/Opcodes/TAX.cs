using NESCove.Core;
using NESCove.MOS6502.Addressing;

namespace NESCove.MOS6502.Opcodes
{
    public class TAX : OpcodeBase
    {
        public TAX(IAddressingType addressing) 
            : base(addressing)
        {

        }

        public override int Execute(C6502 cpu, byte operand)
        {
            cpu.State.RegX = cpu.State.RegA;
            SetNegative(cpu, () => Helper.IsSigned(cpu.State.RegX));
            SetZero(cpu, () => cpu.State.RegX == 0);
            return 2;
        }
    }
}
