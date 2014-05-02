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
            ZeroPage = new ZeroPageAddressing(),
            ZeroPageX = new ZeroPageIndexedXAddressing(),
            ZeroPageY = new ZeroPageIndexedYAddressing(),
            Absoloute = new AbsoluteAddressing(),
            AbsolouteX = new IndexedXAddressing(),
            AbsolouteY = new IndexedYAddressing(),
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
            _opcodes.Add(0x1D, new ORA(AbsolouteX));
            _opcodes.Add(0x19, new ORA(AbsolouteY));
            _opcodes.Add(0x01, new ORA(IndirectX));
            _opcodes.Add(0x11, new ORA(IndirectY));
            // LDA
            _opcodes.Add(0xA9, new LDA(new ImmediateAddressing()));
            _opcodes.Add(0xA5, new LDA(new ZeroPageAddressing()));
            _opcodes.Add(0xB5, new LDA(new ZeroPageIndexedXAddressing()));
            _opcodes.Add(0xAD, new LDA(new AbsoluteAddressing()));
            _opcodes.Add(0xBD, new LDA(new IndexedXAddressing()));
            _opcodes.Add(0xB9, new LDA(new IndexedYAddressing()));
            _opcodes.Add(0xA1, new LDA(new PreIndexedXIndirectAddressing()));
            _opcodes.Add(0xB1, new LDA(new PostIndexedYIndirectAddressing()));
            // LDX
            _opcodes.Add(0xA2, new LDX(new ImmediateAddressing()));
            _opcodes.Add(0xA6, new LDX(new ZeroPageAddressing()));
            _opcodes.Add(0xB6, new LDX(new ZeroPageIndexedYAddressing()));
            _opcodes.Add(0xAE, new LDX(new AbsoluteAddressing()));
            _opcodes.Add(0xBE, new LDX(new IndexedYAddressing()));
            // LDY
            _opcodes.Add(0xA0, new LDY(new ImmediateAddressing()));
            _opcodes.Add(0xA4, new LDY(new ZeroPageAddressing()));
            _opcodes.Add(0xB4, new LDY(new ZeroPageIndexedXAddressing()));
            _opcodes.Add(0xAC, new LDY(new AbsoluteAddressing()));
            _opcodes.Add(0xBC, new LDY(new IndexedXAddressing()));
            // TAX, TAY, TSX, TXA, TXS, TYA, INX, INY, DEX, DEY
            _opcodes.Add(0xAA, new TAX(new ImpliedAddressing()));
            _opcodes.Add(0xA8, new TAY(new ImpliedAddressing()));
            _opcodes.Add(0xBA, new TSX(new ImpliedAddressing()));
            _opcodes.Add(0x8A, new TXA(new ImpliedAddressing()));
            _opcodes.Add(0x9A, new TXS(new ImpliedAddressing()));
            _opcodes.Add(0x98, new TYA(new ImpliedAddressing()));
            _opcodes.Add(0xE8, new INX(new ImpliedAddressing()));
            _opcodes.Add(0xC8, new INY(new ImpliedAddressing()));
            _opcodes.Add(0xCA, new DEX(new ImpliedAddressing()));
            _opcodes.Add(0x88, new DEY(new ImpliedAddressing()));
            // STA
            _opcodes.Add(0x85, new STA(new ZeroPageAddressing()));
            _opcodes.Add(0x95, new STA(new ZeroPageIndexedXAddressing()));
            _opcodes.Add(0x8D, new STA(new AbsoluteAddressing()));
            _opcodes.Add(0x9D, new STA(new IndexedXAddressing()));
            _opcodes.Add(0x99, new STA(new IndexedYAddressing()));
            _opcodes.Add(0x81, new STA(new PreIndexedXIndirectAddressing()));
            _opcodes.Add(0x91, new STA(new PostIndexedYIndirectAddressing()));
            // STX
            _opcodes.Add(0x86, new STX(new ZeroPageAddressing()));
            _opcodes.Add(0x96, new STX(new ZeroPageIndexedYAddressing()));
            _opcodes.Add(0x8E, new STX(new AbsoluteAddressing()));
            // STY
            _opcodes.Add(0x84, new STY(new ZeroPageAddressing()));
            _opcodes.Add(0x94, new STY(new ZeroPageIndexedXAddressing()));
            _opcodes.Add(0x8C, new STY(new AbsoluteAddressing()));
            // CLC, CLD, CLI, CLV, SEC, SED, SEI
            _opcodes.Add(0x18, new CLC(new ImpliedAddressing()));
            _opcodes.Add(0xD8, new CLD(new ImpliedAddressing()));
            _opcodes.Add(0x58, new CLI(new ImpliedAddressing()));
            _opcodes.Add(0xB8, new CLV(new ImpliedAddressing()));
            _opcodes.Add(0x38, new SEC(new ImpliedAddressing()));
            _opcodes.Add(0xF8, new SED(new ImpliedAddressing()));
            _opcodes.Add(0x78, new SEI(new ImpliedAddressing()));
            // INC
            _opcodes.Add(0xE6, new INC(new ZeroPageAddressing()));
            _opcodes.Add(0xF6, new INC(new ZeroPageIndexedXAddressing()));
            _opcodes.Add(0xEE, new INC(new AbsoluteAddressing()));
            _opcodes.Add(0xFE, new INC(new IndexedXAddressing()));
            // DEC
            _opcodes.Add(0xC6, new DEC(new ZeroPageAddressing()));
            _opcodes.Add(0xD6, new DEC(new ZeroPageIndexedXAddressing()));
            _opcodes.Add(0xCE, new DEC(new AbsoluteAddressing()));
            _opcodes.Add(0xDE, new DEC(new IndexedXAddressing()));
            // PHA, PHP, PLA, PLP
            _opcodes.Add(0x48, new PHA(new ImpliedAddressing()));
            _opcodes.Add(0x08, new PHP(new ImpliedAddressing()));
            _opcodes.Add(0x68, new PLA(new ImpliedAddressing()));
            _opcodes.Add(0x28, new PLP(new ImpliedAddressing()));
            // Branching: JMP, JSR, RTS, RTI
            _opcodes.Add(0x4C, new JMP(new AbsoluteAddressing()));
            _opcodes.Add(0x6C, new JMP(new IndirectAddressing()));
            _opcodes.Add(0x20, new JSR(new AbsoluteAddressing()));
            _opcodes.Add(0x60, new RTS(new ImpliedAddressing()));
            _opcodes.Add(0x40, new RTI(new ImpliedAddressing()));
            // ADC
            _opcodes.Add(0x69, new ADC(new ImmediateAddressing()));
            _opcodes.Add(0x65, new ADC(new ZeroPageAddressing()));
            _opcodes.Add(0x75, new ADC(new ZeroPageIndexedXAddressing()));
            _opcodes.Add(0x6D, new ADC(new AbsoluteAddressing()));
            _opcodes.Add(0x7D, new ADC(new IndexedXAddressing()));
            _opcodes.Add(0x79, new ADC(new IndexedYAddressing()));
            _opcodes.Add(0x61, new ADC(new PreIndexedXIndirectAddressing()));
            _opcodes.Add(0x71, new ADC(new PostIndexedYIndirectAddressing()));

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
