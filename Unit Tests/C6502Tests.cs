using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NESCove.Core;
using NESCove.MOS6502;

namespace Unit_Tests
{
    [TestClass]
    public class C6502Tests
    {
        [TestMethod]
        [Priority(0)]
        public void C6502_Init()
        {
            /*
             * Create an unused test cpu. This will minimize the impact on the first test
             * due to looking up the CPU and Test memory classes. Providing a more accurate
             * computation time for the first test
             */
            var c = CreateTestCPU();
            c.Memory[0x00] = 0x00;
            c.Step();
        }

        [TestMethod]
        public void C6502_Execute_ImmediateValue_A()
        {
            var c = CreateTestCPU();
            c.Memory[0x00] = 0xA9;
            c.Memory[0x01] = 0xFF;
            c.Step();
            // We should probably assert all the registers (JL)
            Assert.AreEqual(c.RegA, 0xFF, "Loading FF into A using Immediate Addressing");
        }

        [TestMethod]
        public void C6502_Execute_AbsolouteValue_A()
        {
            var c = CreateTestCPU();
            c.Memory[0x16A0] = 0x13;
            c.Memory[0x00] = 0xAD;
            c.Memory[0x01] = 0xA0;
            c.Memory[0x02] = 0x16;
            c.Step();
            Assert.AreEqual(c.RegA, 0x13, "Loading 13 into A using absolute addressing");
        }

        [TestMethod]
        public void C6502_Execute_ZeroPage_A()
        {
            var c = CreateTestCPU();
            c.Memory[0xFC] = 0x14;
            c.Memory[0x00] = 0xA5;
            c.Memory[0x01] = 0xFC;
            c.Step();
            Assert.AreEqual(c.RegA, 0x14, "Loading 14 into A using Zero Page Addressing"); 
        }

        [TestMethod]
        public void C6502_Execute_Immediate_X()
        {
            var c = CreateTestCPU();
            c.Memory[0x00] = 0xA2;
            c.Memory[0x01] = 0x06;
            c.Step();
            Assert.AreEqual(c.RegX, 0x06, "Loading 06 into X using Immediate Addressing");
        }

        [TestMethod]
        public void C6502_Execute_PreIndexed_Indirect_A()
        {
            var c = CreateTestCPU();
            c.Memory[0x46] = 0x05;
            c.Memory[0x47] = 0x20;
            c.Memory[0x2005] = 0xFF;
            c.Memory[0x00] = 0xA1;
            c.Memory[0x01] = 0x46;
            c.Step();
            Assert.AreEqual(c.RegA, 0xFF, "Loading FF into A using Pre-Indexed Indirect Addressing");
        }

        [TestMethod]
        public void C6502_Execute_Immediate_Y()
        {
            var c = CreateTestCPU();
            c.Memory[0x00] = 0xA0;
            c.Memory[0x01] = 0x04;
            c.Step();
            Assert.AreEqual(c.RegY, 0x04, "Loading 04 into Y using Immediate Addressing");
        }

        [TestMethod]
        public void C6502_Execute_PostIndexed_Indirect_A()
        {
            var c = CreateTestCPU();
            c.Memory[0x48] = 0x19;
            c.Memory[0x49] = 0x32;
            c.Memory[0x3219] = 0xCF;
            c.Memory[0x00] = 0xB1;
            c.Memory[0x01] = 0x48;
            c.Step();
            Assert.AreEqual(c.RegA, 0xCF, "Loading CF into A using Post-Indexed Indirect Addressing");
        }

        [TestMethod]
        public void C6502_Execute_ZeroPage_Indexed_A()
        {
            var c = CreateTestCPU();
            c.Memory[0x00] = 0xA2;
            c.Memory[0x01] = 0xDF;
            c.Memory[0xDF] = 0xFE;
            c.Memory[0x02] = 0xB5;
            c.Memory[0x03] = 0x00;
            c.Step(2);
            Assert.AreEqual(c.RegA, 0xFE, "Loading FE into A using Zero-Page Indexed Addressing");
        }

        [TestMethod]
        public void C6502_Execute_Absoloute_XA()
        {
            var c = CreateTestCPU();
            c.Memory[0x00] = 0xA2;
            c.Memory[0x01] = 0xFF;

            c.Memory[0x10FF] = 0xFB;
            c.Memory[0x02] = 0xBD;
            c.Memory[0x03] = 0x00;
            c.Memory[0x04] = 0x10;
            c.Step(2);
            Assert.AreEqual(c.RegA, 0xFB, "Loading FB into A using Absolute X Addressing");
        }

        [TestMethod]
        public void C6502_Execute_Absoloute_YA()
        {
            var c = CreateTestCPU();
            c.Memory[0x00] = 0xA0;
            c.Memory[0x01] = 0xFF;

            c.Memory[0x11FF] = 0xFD;
            c.Memory[0x02] = 0xB9;
            c.Memory[0x03] = 0x00;
            c.Memory[0x04] = 0x11;
            c.Step(2);
            Assert.AreEqual(c.RegA, 0xFD, "Loading FD into A using Absolute Y Addressing");
        }



        private C6502 CreateTestCPU()
        {
            C6502 cpu = new C6502();
            cpu.Memory = new TestMemoryProvider();
            return cpu;
        }


    }
}
