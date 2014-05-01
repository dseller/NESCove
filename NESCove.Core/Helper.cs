using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NESCove.Core
{
    public class Helper
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
        /// <param name="length">The byte length of the integer</param>
        /// <typeparam name="W">Word type</typeparam>
        /// <typeparam name="M">Memory length type</typeparam>
        /// <returns></returns>
        public static int CompositeInteger(IGenericMemoryProvider provider, int offset, int length)
        {
            int result = 0;
            for (int index = 0; index < length; index++)
            {
                result = (provider[offset++] << (8 * index) | result);
            }
            return result;
        }

        /// <summary>
        /// Compare two memory addresses to determine if they're in the same memory page
        /// </summary>
        /// <param name="address">Address A</param>
        /// <param name="addressB">Address B</param>s
        /// <returns>true if Address A and Address B are in the same page</returns>
        public static Boolean IsSamePage(int address, int addressB, int pageSize)
        {
            return (int)(address / pageSize) == (int)(addressB / pageSize);
        }
    }
}
