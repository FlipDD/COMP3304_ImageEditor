using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;

// By Filipe and Nathan
namespace ImageProcessorLibrary
{
    public class ImageLoader : IImageLoader
    {
        /// <summary>
        /// Load the initial images that will appear when the program first starts
        /// </summary>
        /// <returns>a vector of strings containing the path for each image found</returns>
        public IList<string> LoadInitalImages()
        {
            // Create a temporary list to store all assets in the directory
            var filePaths = new List<string>();
            try
            {
                // Get the path to all Images in a directory
                // and populate the _filePaths List
                filePaths = Directory.GetFiles("../../FishAssets", "*.png", SearchOption.AllDirectories).ToList();
            }
            catch (Exception e)
            {
                // WriteLine in case there was a problem loading the Images
                Console.WriteLine("Error: {0}", e.ToString());
            }

            return filePaths;
        }
    }
}
