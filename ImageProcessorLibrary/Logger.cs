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
            // string filepath is stored under
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

            // attempt creation of file or adding data to existing file
            try
            {
                // if file doesnt exist create new file                            
                if (!File.Exists(path))
                {
                    // File creation with specified path
                    using (StreamWriter logFile = File.CreateText(path))
                    {
                        // add message to file
                        logFile.WriteLine(string.Concat(log));
                    }
                }
                // if file already exists add to existing
                else if(File.Exists(path)){
                    // adds message to existing file
                    using (StreamWriter logFile = new StreamWriter(path, true))
                    {
                        // add message to file
                        logFile.WriteLine(string.Concat(log));
                    }
                }
            }
            // catch print error to console
            catch (Exception e) {
                Console.WriteLine("Failed to log error{0}",e);
            }
        }
    }
}
