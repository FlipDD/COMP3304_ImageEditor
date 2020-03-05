using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImageProcessorLibrary
{
    /// <summary>
    /// The logger interface
    /// Should get more methods as we go
    /// </summary>
    interface ILogger
    {
        /// <summary>
        /// Print a message to the console
        /// </summary>
        /// <param name="message">a string; the message to print</param>
        void PrintMessage(string message);
    }
}
