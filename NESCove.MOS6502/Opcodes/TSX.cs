using NESCove.MOS6502.Addressing;

namespace NESCove.MOS6502.Opcodes
{
    public class TSX : OpcodeBase
    {
        public TSX(IAddressingType addressing) 
            : base(addressing)
        {

        }

        public override void Execute(C6502 cpu, ushort parameter)
        {
            byte operand = cpu.StackPointer;
            SetNegative(cpu, operand);
            SetZero(cpu, operand);
            cpu.RegX = operand;
        }
    }
}
