using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NESCove.Core;

namespace Unit_Tests
{
    [TestClass]
    public class DataHelperTest
    {
        [TestMethod]
        public void DataHelper_CorrectEndian_16bit()
        {
            ushort targetNumber = 6502;
            byte[] littleEndian6502 = {0x66, 0x19};
            ushort result = Helper.CompositeInteger(littleEndian6502, 0, 2);
            Assert.AreEqual<ushort>(result, targetNumber);
        }

        [TestMethod]
        public void DataHelper_CorrectEndian_8bit()
        {
            byte targetNumber = 172;
            byte[] littleEndian172 = { 0xAC };
            ushort result = Helper.CompositeInteger(littleEndian172, 0, 1);
            Assert.AreEqual<ushort>(result, targetNumber);
        }
    }
}
