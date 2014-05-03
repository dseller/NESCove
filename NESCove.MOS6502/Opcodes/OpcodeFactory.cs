using System.Collections.Generic;
using NESCove.MOS6502.Addressing;

namespace NESCove.MOS6502.Opcodes
{
    public static class OpcodeFactory
    {
        private static readonly Dictionary<byte, IOpcode> _opcodes =
            new Dictionary<byte, IOpcode>();

        private static readonly IAddressingType
            Immediate = new ImmediateAddressing(),
            Implied = new ImpliedAddressing(),
            ZeroPage = new ZeroPageAddressing(),
            ZeroPageX = new ZeroPageIndexedXAddressing(),
            ZeroPageY = new ZeroPageIndexedYAddressing(),
            Absoloute = new AbsoluteAddressing(),
            AbsolouteIndexedX = new IndexedXAddressing(),
            AbsolouteIndexedY = new IndexedYAddressing(),
            IndirectX = new PreIndexedXIndirectAddressing(),
            IndirectY = new PostIndexedYIndirectAddressing();

        static OpcodeFactory()
        {
            _opcodes.Add(0x00, new BRK());
            // ORA
            _opcodes.Add(0x09, new ORA(Immediate));
            _opcodes.Add(0x05, new ORA(ZeroPage));
            _opcodes.Add(0x15, new ORA(ZeroPageX));
            _opcodes.Add(0x0D, new ORA(Absoloute));
            _opcodes.Add(0x1D, new ORA(AbsolouteIndexedX));
            _opcodes.Add(0x19, new ORA(AbsolouteIndexedY));
            _opcodes.Add(0x01, new ORA(IndirectX));
            _opcodes.Add(0x11, new ORA(IndirectY));
            // LDA
            _opcodes.Add(0xA9, new LDA(Immediate));
            _opcodes.Add(0xA5, new LDA(ZeroPage));
            _opcodes.Add(0xB5, new LDA(ZeroPageX));
            _opcodes.Add(0xAD, new LDA(Absoloute));
            _opcodes.Add(0xBD, new LDA(AbsolouteIndexedX));
            _opcodes.Add(0xB9, new LDA(AbsolouteIndexedY));
            _opcodes.Add(0xA1, new LDA(IndirectX));
            _opcodes.Add(0xB1, new LDA(IndirectY));
            // LDX
            _opcodes.Add(0xA2, new LDX(Immediate));
            _opcodes.Add(0xA6, new LDX(ZeroPage));
            _opcodes.Add(0xB6, new LDX(ZeroPageY));
            _opcodes.Add(0xAE, new LDX(Absoloute));
            _opcodes.Add(0xBE, new LDX(AbsolouteIndexedY));
            // LDY
            _opcodes.Add(0xA0, new LDY(Immediate));
            _opcodes.Add(0xA4, new LDY(ZeroPage));
            _opcodes.Add(0xB4, new LDY(ZeroPageX));
            _opcodes.Add(0xAC, new LDY(Absoloute));
            _opcodes.Add(0xBC, new LDY(AbsolouteIndexedX));
            // TAX, TAY, TSX, TXA, TXS, TYA, INX, INY, DEX, DEY
            _opcodes.Add(0xAA, new TAX(Implied));
            _opcodes.Add(0xA8, new TAY(Implied));
            _opcodes.Add(0xBA, new TSX(Implied));
            _opcodes.Add(0x8A, new TXA(Implied));
            _opcodes.Add(0x9A, new TXS(Implied));
            _opcodes.Add(0x98, new TYA(Implied));
            _opcodes.Add(0xE8, new INX(Implied));
            _opcodes.Add(0xC8, new INY(Implied));
            _opcodes.Add(0xCA, new DEX(Implied));
            _opcodes.Add(0x88, new DEY(Implied));
            // STA
            _opcodes.Add(0x85, new STA(ZeroPage));
            _opcodes.Add(0x95, new STA(ZeroPageX));
            _opcodes.Add(0x8D, new STA(Absoloute));
            _opcodes.Add(0x9D, new STA(AbsolouteIndexedX));
            _opcodes.Add(0x99, new STA(AbsolouteIndexedY));
            _opcodes.Add(0x81, new STA(IndirectX));
            _opcodes.Add(0x91, new STA(IndirectY));
            // STX
            _opcodes.Add(0x86, new STX(ZeroPage));
            _opcodes.Add(0x96, new STX(ZeroPageY));
            _opcodes.Add(0x8E, new STX(Absoloute));
            // STY
            _opcodes.Add(0x84, new STY(ZeroPage));
            _opcodes.Add(0x94, new STY(ZeroPageX));
            _opcodes.Add(0x8C, new STY(Absoloute));
            // CLC, CLD, CLI, CLV, SEC, SED, SEI
            _opcodes.Add(0x18, new CLC(Implied));
            _opcodes.Add(0xD8, new CLD(Implied));
            _opcodes.Add(0x58, new CLI(Implied));
            _opcodes.Add(0xB8, new CLV(Implied));
            _opcodes.Add(0x38, new SEC(Implied));
            _opcodes.Add(0xF8, new SED(Implied));
            _opcodes.Add(0x78, new SEI(Implied));
            // INC
            _opcodes.Add(0xE6, new INC(ZeroPage));
            _opcodes.Add(0xF6, new INC(ZeroPageX));
            _opcodes.Add(0xEE, new INC(Absoloute));
            _opcodes.Add(0xFE, new INC(AbsolouteIndexedX));
            // DEC
            _opcodes.Add(0xC6, new DEC(ZeroPage));
            _opcodes.Add(0xD6, new DEC(ZeroPageX));
            _opcodes.Add(0xCE, new DEC(Absoloute));
            _opcodes.Add(0xDE, new DEC(AbsolouteIndexedX));
            // PHA, PHP, PLA, PLP
            _opcodes.Add(0x48, new PHA(Implied));
            _opcodes.Add(0x08, new PHP(Implied));
            _opcodes.Add(0x68, new PLA(Implied));
            _opcodes.Add(0x28, new PLP(Implied));
            // Branching: JMP, JSR, RTS, RTI
            _opcodes.Add(0x4C, new JMP(new AbsoluteAddressing()));
            _opcodes.Add(0x6C, new JMP(new IndirectAddressing()));
            _opcodes.Add(0x20, new JSR(new AbsoluteAddressing()));
            _opcodes.Add(0x60, new RTS(Implied));
            _opcodes.Add(0x40, new RTI(Implied));
            // ADC
            _opcodes.Add(0x69, new ADC(new ImmediateAddressing()));
            _opcodes.Add(0x65, new ADC(new ZeroPageAddressing()));
            _opcodes.Add(0x75, new ADC(new ZeroPageIndexedXAddressing()));
            _opcodes.Add(0x6D, new ADC(new AbsoluteAddressing()));
            _opcodes.Add(0x7D, new ADC(new IndexedXAddressing()));
            _opcodes.Add(0x79, new ADC(new IndexedYAddressing()));
            _opcodes.Add(0x61, new ADC(new PreIndexedXIndirectAddressing()));
            _opcodes.Add(0x71, new ADC(new PostIndexedYIndirectAddressing()));
            // SBC
            _opcodes.Add(0xE9, new SBC(new ImmediateAddressing()));
            _opcodes.Add(0xE5, new SBC(new ZeroPageAddressing()));
            _opcodes.Add(0xF5, new SBC(new ZeroPageIndexedXAddressing()));
            _opcodes.Add(0xED, new SBC(new AbsoluteAddressing()));
            _opcodes.Add(0xFD, new SBC(new IndexedXAddressing()));
            _opcodes.Add(0xF9, new SBC(new IndexedYAddressing()));
            _opcodes.Add(0xE1, new SBC(new PreIndexedXIndirectAddressing()));
            _opcodes.Add(0xF1, new SBC(new PostIndexedYIndirectAddressing()));
            // AND
            _opcodes.Add(0x29, new AND(new ImmediateAddressing()));
            _opcodes.Add(0x25, new AND(new ZeroPageAddressing()));
            _opcodes.Add(0x35, new AND(new ZeroPageIndexedXAddressing()));
            _opcodes.Add(0x2D, new AND(new AbsoluteAddressing()));
            _opcodes.Add(0x3D, new AND(new IndexedXAddressing()));
            _opcodes.Add(0x39, new AND(new IndexedYAddressing()));
            _opcodes.Add(0x21, new AND(new PreIndexedXIndirectAddressing()));
            _opcodes.Add(0x31, new AND(new PostIndexedYIndirectAddressing()));
            // EOR
            _opcodes.Add(0x49, new EOR(new ImmediateAddressing()));
            _opcodes.Add(0x45, new EOR(new ZeroPageAddressing()));
            _opcodes.Add(0x55, new EOR(new ZeroPageIndexedXAddressing()));
            _opcodes.Add(0x4D, new EOR(new AbsoluteAddressing()));
            _opcodes.Add(0x5D, new EOR(new IndexedXAddressing()));
            _opcodes.Add(0x59, new EOR(new IndexedYAddressing()));
            _opcodes.Add(0x41, new EOR(new PreIndexedXIndirectAddressing()));
            _opcodes.Add(0x51, new EOR(new PostIndexedYIndirectAddressing()));
            // ASL
            _opcodes.Add(0x0A, new ASL(new AccumulatorAddressing()));
            _opcodes.Add(0x06, new ASL(new ZeroPageAddressing()));
            _opcodes.Add(0x16, new ASL(new ZeroPageIndexedXAddressing()));
            _opcodes.Add(0x0E, new ASL(new AbsoluteAddressing()));
            _opcodes.Add(0x1E, new ASL(new IndexedXAddressing()));
            // BIT
            _opcodes.Add(0x24, new BIT(new ZeroPageAddressing()));
            _opcodes.Add(0x2C, new BIT(new AbsoluteAddressing()));
            // LSR
            _opcodes.Add(0x4A, new LSR(new AccumulatorAddressing()));
            _opcodes.Add(0x46, new LSR(new ZeroPageAddressing()));
            _opcodes.Add(0x56, new LSR(new ZeroPageIndexedXAddressing()));
            _opcodes.Add(0x4E, new LSR(new AbsoluteAddressing()));
            _opcodes.Add(0x5E, new LSR(new IndexedXAddressing()));
            // ROL
            _opcodes.Add(0x2A, new ROL(new AccumulatorAddressing()));
            _opcodes.Add(0x26, new ROL(new ZeroPageAddressing()));
            _opcodes.Add(0x36, new ROL(new ZeroPageIndexedXAddressing()));
            _opcodes.Add(0x2E, new ROL(new AbsoluteAddressing()));
            _opcodes.Add(0x3E, new ROL(new IndexedXAddressing()));
            // ROR
            _opcodes.Add(0x6A, new ROR(new AccumulatorAddressing()));
            _opcodes.Add(0x66, new ROR(new ZeroPageAddressing()));
            _opcodes.Add(0x76, new ROR(new ZeroPageIndexedXAddressing()));
            _opcodes.Add(0x6E, new ROR(new AbsoluteAddressing()));
            _opcodes.Add(0x7E, new ROR(new IndexedXAddressing()));
        }

        public static IOpcode GetOpcode(byte opcode)
        {
            IOpcode handler;
            if (!_opcodes.TryGetValue(opcode, out handler))
                return null;
            return handler;
        }
    }
}
