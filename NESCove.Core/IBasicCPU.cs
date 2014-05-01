using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NESCove.Core
{
    /// <summary>
    /// Basic CPU interface
    /// </summary>
    /// <typeparam name="O">Opcode value type</typeparam>
    /// <typeparam name="W">Word value type</typeparam>
    /// <typeparam name="M">Memory length value type</typeparam>
    public interface IBasicCPU<O, W, M>
    {
        /// <summary>
        /// Memory provider for 6502 CPU
        /// </summary>
        IMemoryProvider<W, M> Memory { get; }
        /// <summary>
        /// Execution state with all registers
        /// </summary>
        IBasicState<O, W, M> State { get; }
        /// <summary>
        /// Steps the CPU one operation
        /// </summary>
        /// <param name="iterations">What do you think it does, SRSLY</param>
        /// <returns>The amount of cycles that were spent running this operation</returns>
        int Step(int iterations = 1);
    }
}
