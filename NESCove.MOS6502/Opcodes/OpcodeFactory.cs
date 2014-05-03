using System.Collections.Generic;
using NESCove.MOS6502.Addressing;

namespace NESCove.MOS6502.Opcodes
{
    public static class OpcodeFactory
    {
        private static readonly Dictionary<byte, IOpcode> _opcodes =
            new Dictionary<byte, IOpcode>();

        private static readonly IAddressingType
            Accumulator = new AccumulatorAddressing(),
            Immediate = new ImmediateAddressing(),
            Indirect = new IndirectAddressing(),
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
            _opcodes.Add(0x4C, new JMP(Absoloute));
            _opcodes.Add(0x6C, new JMP(Indirect));
            _opcodes.Add(0x20, new JSR(Absoloute));
            _opcodes.Add(0x60, new RTS(Implied));
            _opcodes.Add(0x40, new RTI(Implied));
            // ADC
            _opcodes.Add(0x69, new ADC(Immediate));
            _opcodes.Add(0x65, new ADC(ZeroPage));
            _opcodes.Add(0x75, new ADC(ZeroPageX));
            _opcodes.Add(0x6D, new ADC(Absoloute));
            _opcodes.Add(0x7D, new ADC(AbsolouteIndexedX));
            _opcodes.Add(0x79, new ADC(AbsolouteIndexedY));
            _opcodes.Add(0x61, new ADC(IndirectX));
            _opcodes.Add(0x71, new ADC(IndirectY));
            // SBC
            _opcodes.Add(0xE9, new SBC(Immediate));
            _opcodes.Add(0xE5, new SBC(ZeroPage));
            _opcodes.Add(0xF5, new SBC(ZeroPageX));
            _opcodes.Add(0xED, new SBC(Absoloute));
            _opcodes.Add(0xFD, new SBC(AbsolouteIndexedX));
            _opcodes.Add(0xF9, new SBC(AbsolouteIndexedY));
            _opcodes.Add(0xE1, new SBC(IndirectX));
            _opcodes.Add(0xF1, new SBC(IndirectY));
            // AND
            _opcodes.Add(0x29, new AND(Immediate));
            _opcodes.Add(0x25, new AND(ZeroPage));
            _opcodes.Add(0x35, new AND(ZeroPageX));
            _opcodes.Add(0x2D, new AND(Absoloute));
            _opcodes.Add(0x3D, new AND(AbsolouteIndexedX));
            _opcodes.Add(0x39, new AND(AbsolouteIndexedY));
            _opcodes.Add(0x21, new AND(IndirectX));
            _opcodes.Add(0x31, new AND(IndirectY));
            // EOR
            _opcodes.Add(0x49, new EOR(Immediate));
            _opcodes.Add(0x45, new EOR(ZeroPage));
            _opcodes.Add(0x55, new EOR(ZeroPageX));
            _opcodes.Add(0x4D, new EOR(Absoloute));
            _opcodes.Add(0x5D, new EOR(AbsolouteIndexedX));
            _opcodes.Add(0x59, new EOR(AbsolouteIndexedY));
            _opcodes.Add(0x41, new EOR(IndirectX));
            _opcodes.Add(0x51, new EOR(IndirectY));
            // ASL
            _opcodes.Add(0x0A, new ASL(Accumulator));
            _opcodes.Add(0x06, new ASL(ZeroPage));
            _opcodes.Add(0x16, new ASL(ZeroPageX));
            _opcodes.Add(0x0E, new ASL(Absoloute));
            _opcodes.Add(0x1E, new ASL(AbsolouteIndexedX));
            // BIT
            _opcodes.Add(0x24, new BIT(ZeroPage));
            _opcodes.Add(0x2C, new BIT(Absoloute));
            // LSR
            _opcodes.Add(0x4A, new LSR(Accumulator));
            _opcodes.Add(0x46, new LSR(ZeroPage));
            _opcodes.Add(0x56, new LSR(ZeroPageX));
            _opcodes.Add(0x4E, new LSR(Absoloute));
            _opcodes.Add(0x5E, new LSR(AbsolouteIndexedX));
            // ROL
            _opcodes.Add(0x2A, new ROL(Accumulator));
            _opcodes.Add(0x26, new ROL(ZeroPage));
            _opcodes.Add(0x36, new ROL(ZeroPageX));
            _opcodes.Add(0x2E, new ROL(Absoloute));
            _opcodes.Add(0x3E, new ROL(AbsolouteIndexedX));
            // ROR
            _opcodes.Add(0x6A, new ROR(Accumulator));
            _opcodes.Add(0x66, new ROR(ZeroPage));
            _opcodes.Add(0x76, new ROR(ZeroPageX));
            _opcodes.Add(0x6E, new ROR(Absoloute));
            _opcodes.Add(0x7E, new ROR(AbsolouteIndexedX));
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
