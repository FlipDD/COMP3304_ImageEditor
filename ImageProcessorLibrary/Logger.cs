using System;
using System.Globalization;
using System.IO;

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

        // filename for error log
        private string fileName;
        // file path for error logger file
        private string path;

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

        public Logger(){
            // string that filename is created under
            fileName = "Error_Log.txt";
            path = @"..\..\" + fileName;
        }

        /// <summary>
        /// Print a message to the console
        /// </summary>
        /// <param name="message">a string; the message to print</param>
        public void PrintMessage(string message) => Console.WriteLine(message);


        /// <summary>
        /// Create a file and log errors to it  
        /// </summary>
        /// <param name="message"> string: message put into file</param>
        public void ErrorBuilder(string message) {            
            // log created using timestamp and error message
            string[] log = { DateTime.Now.ToString(), " Error ", message };
            try
            {
                // creates new file if one doesnt exist                            
                if (!File.Exists(path))
                {
                    // File creation with specified path
                    using (StreamWriter logFile = File.CreateText(path))
                    {
                        logFile.WriteLine(string.Concat(log));
                    }
                }
                else if(File.Exists(path)){
                    // adds message to existing file
                    using (StreamWriter logFile = new StreamWriter(path, true))
                    {
                        logFile.WriteLine(string.Concat(log));
                    }
                }
            }
            catch (Exception e) {
                Console.WriteLine("Failed to log error{0}",e);
            }
        }
    }
}
