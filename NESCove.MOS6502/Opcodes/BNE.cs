using NESCove.MOS6502.Addressing;

namespace NESCove.MOS6502.Opcodes
{
    class BNE : OpcodeBase
    {
        public BNE(IAddressingType addressing)
            : base(addressing)
        {
        }

        public override int Execute(C6502 cpu, byte operand)
        {
            // Relative to PC, therefore we need to emulate an immediate addressing mode to just use the parameter
            int address = (cpu.State.ProgramCounter + operand);
            if (!cpu.State.IsFlagSet((byte)StatusFlags.Zero))
            {
                // TODO: page boundary shit.
                cpu.State.ProgramCounter = (ushort)(address & 0xFFFF);
            }
            return 2;
        }
    }
}
