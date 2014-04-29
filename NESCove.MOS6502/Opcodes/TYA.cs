using NESCove.MOS6502.Addressing;

namespace NESCove.MOS6502.Opcodes
{
    public class TYA : OpcodeBase
    {
        public TYA(IAddressingType addressing) 
            : base(addressing)
        {
        }

        public override void Execute(C6502 cpu, ushort parameter)
        {
            byte operand = cpu.RegY;
            SetNegative(cpu, operand);
            SetZero(cpu, operand);
            cpu.RegA = operand;
        }
    }
}
