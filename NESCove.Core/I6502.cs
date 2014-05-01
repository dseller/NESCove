using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NESCove.Core
{
    public interface I6502
    {
        /// <summary>
        /// Memory provider for 6502 CPU
        /// </summary>
        IMemoryProvider Memory { get; }
        /// <summary>
        /// Execution state with all registers
        /// </summary>
        ExecutionState State { get; }
        /// <summary>
        /// Steps the CPU one operation
        /// </summary>
        /// <param name="iterations">What do you think it does, SRSLY</param>
        /// <returns>The amount of cycles that were spent running this operation</returns>
        int Step(int iterations = 1);
    }
}
