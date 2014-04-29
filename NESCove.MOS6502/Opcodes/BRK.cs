using NESCove.MOS6502.Addressing;

namespace NESCove.MOS6502.Opcodes
{
    public class BRK : OpcodeBase
    {
        public BRK() 
            : base(new ImpliedAddressing())
        {
            // This was removed from the 6502 in the Ricoh 2A03 NES chip.
            // We need to make this eat a clock cycle when we g et timing done.
            // http://www.thealmightyguru.com/Games/Hacking/Wiki/index.php?title=BRK
        }

        public override void Execute(C6502 cpu, ushort parameter)
        {
            
        }
    }
}
