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

        public IList<string> BrowseNewImages()
        {
            // Display a dialog box to prompt the user to select a file.
            // Create an instance with a using statement so it automatically
            // closes the stream and calls .Dispose(), which calls .Close().
            using (OpenFileDialog fileDialog = new OpenFileDialog())
            {
                // Set the initial directory to look into
                // Make it the one where the FishAssets are located.
                string currentPath = Directory.GetCurrentDirectory();
                string newPath = Path.GetFullPath(Path.Combine(currentPath, @"..\..\FishAssets"));
                fileDialog.InitialDirectory = newPath;

                // Set the title of the File Dialog box
                fileDialog.Title = "Select Images";

                // Filter the results to only allow specific file types
                fileDialog.Filter = "Image files (*.jpg, *.jpeg, *.jpe, *.jfif, *.btm, *.png) | *.jpg; *.jpeg; *.jpe; *.jfif; *.btm; *.png";

                // Enable multiselect to allow multiple image selection
                fileDialog.Multiselect = true;

                // If we picked some Images, return them
                if (fileDialog.ShowDialog() == DialogResult.OK) {
                    return fileDialog.FileNames;
                }

                return null;
            }
        }
    }
}
