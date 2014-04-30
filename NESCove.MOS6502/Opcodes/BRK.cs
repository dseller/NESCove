using NESCove.MOS6502.Addressing;

namespace NESCove.MOS6502.Opcodes
{
    public class BRK : OpcodeBase
    {
        public BRK() 
            : base(new ImpliedAddressing())
        {
            // This was removed from the 6502 in the Ricoh 2A03 NES chip.
            // We need to make this eat a clock cycle when we get timing done.
            // http://www.thealmightyguru.com/Games/Hacking/Wiki/index.php?title=BRK
        }

        public override int Execute(C6502 cpu, ushort parameter)
        {
            // Mixed results across sites, some say 2 some say 7. I'm going to assume
            // It's 2 on the Ricoh 2A03, as less operations are done
            return 2;
        }
    }
}
