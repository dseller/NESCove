using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NESCove.MOS6502.Addressing
{
    public interface IAddressingType
    {
        /// <summary>
        /// Parameter size in byte count
        /// </summary>
        byte? ParameterSize { get; }

        /// <summary>
        /// This will translate from parameter to operand.
        /// <remarks>Note that the first parameter is a short. This can be a byte too.</remarks>
        /// </summary>
        /// <param name="parameter">The parameter from the instruction.</param>
        /// <returns></returns>
        byte GetOperand(C6502 cpu, UInt16 parameter);

        /// <summary>
        /// This will only retrieve the address, mostly used in the GetOperand method.
        /// It can also be used in opcodes that will write to memory.
        /// </summary>
        /// <param name="cpu"></param>
        /// <param name="parameter"></param>
        /// <returns></returns>
        UInt16 GetAddress(C6502 cpu, UInt16 parameter);
    }
}
