using System.Collections.Generic;
using NESCove.MOS6502.Addressing;

namespace NESCove.MOS6502.Opcodes
{
    public static class OpcodeFactory
    {
        private static readonly Dictionary<byte, IOpcode> _opcodes =
            new Dictionary<byte, IOpcode>();

        static OpcodeFactory()
        {
            _opcodes.Add(0x00, new BRK());
            // LDA
            _opcodes.Add(0xA9, new LDA(new ImmediateAddressing()));
            _opcodes.Add(0xA5, new LDA(new ZeroPageAddressing()));
            _opcodes.Add(0xB5, new LDA(new ZeroPageIndexedXAddressing()));
            _opcodes.Add(0xAD, new LDA(new AbsoluteAddressing()));
            _opcodes.Add(0xBD, new LDA(new IndexedXAddressing()));
            _opcodes.Add(0xB9, new LDA(new IndexedYAddressing()));
            _opcodes.Add(0xA1, new LDA(new PreIndexedIndirectAddressing()));
            _opcodes.Add(0xB1, new LDA(new PostIndexedIndirectAddressing()));
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
