using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NESCove.Core
{
    public class DataHelper
    {
        /// <summary>
        /// Composes bytes in to an integer of Little Endian byte order
        /// </summary>
        /// <param name="data">An array of data to use for the integer</param>
        /// <param name="offset">The offset in the array to begin composing from</param>
        /// <param name="length">The byte length of the integer</param>
        /// <returns>Integer as ushort</returns>
        public static ushort CompositeInteger(byte[] data, int offset, int length)
        {
            ushort result = 0;
            for (int index = 0; index < length; index++)
            {
                result = (ushort)(data[offset++] << (8 * index) | result);
            }
            return result;
        }

        /// <summary>
        /// Composes bytes in to an integer of Little Endian byte order
        /// </summary>
        /// <param name="provider">A memory provider to fetch bytes from</param>
        /// <param name="offset">Offset to state fetching bytes from</param>
        /// <param name="length">The byt elength of the integer</param>
        /// <returns></returns>
        public static ushort CompositeInteger(IMemoryProvider provider, ushort offset, int length)
        {
            ushort result = 0;
            for (int index = 0; index < length; index++)
            {
                result = (ushort)(provider[offset++] << (8 * index) | result);
            }
            return result;
        }
    }
}
