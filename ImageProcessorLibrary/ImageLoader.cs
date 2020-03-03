﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace ImageProcessorLibrary
{
    public class ImageLoader : IImageLoader
    {  
        public IList<string> LoadInitalImages()
        {
            // CREATE a temporary list to store all assets in the directory
            IList<string> _filePaths = new List<string>();
            try
            {
                // GET the path to all Images in a directory
                // and populate the _filePaths List
                _filePaths = Directory.GetFiles("../../FishAssets", "*.*", SearchOption.AllDirectories).ToList();
            }
            catch (Exception e)
            {
                Console.WriteLine("Error: {0}", e.ToString());
            }

            return _filePaths;
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

                if (fileDialog.ShowDialog() == DialogResult.OK) {
                    return fileDialog.FileNames;
                }

                return null;
            }
        }
    }
}
