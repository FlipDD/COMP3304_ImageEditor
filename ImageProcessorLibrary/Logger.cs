using System;

namespace ImageProcessorLibrary
{
    /// <summary>
    /// Class to handle all types of logging to the console
    /// </summary>
    public class Logger : ILogger
    {
        /// <summary>
        /// Declaring a private static Logger Instance
        /// </summary>
        private static Logger instance;

        /// <summary>
        /// Get the Logger if it already exists
        /// otherwise create one (Singleton)
        /// </summary>
        public static Logger Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new Logger();
                }
                return instance;
            }
        }

        /// <summary>
        /// Print a message to the console
        /// </summary>
        /// <param name="message">a string; the message to print</param>
        public void PrintMessage(string message) => Console.WriteLine(message);
    }
}
