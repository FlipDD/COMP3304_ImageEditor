using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ImageResizerLibrary;

namespace COMP3304Application
{
    class ImageHandler : IModel
    {
        private ImageProcess imageProcess;
        private IList<ImageData> _imagesData;
        private IDictionary<string, Image> _imageFiles;
        private CurrentImage _currentImage;
        private Load _load;
        private int _currentIndex;

        public ImageHandler()
        {
            // INSTANTIATE the image process class --
            // Used to convert paths into images
            // and format them, i.e. scale, rotate.
            imageProcess = new ImageProcess();

            // INITIALIZE the List that will
            // store image data
            _imagesData = new List<ImageData>();

            // INITIALIZE the Dictionary that will 
            // hold the original Images in memory
            _imageFiles = new Dictionary<string, Image>();

            // ASSIGN the delegates
            _currentImage = GetCurrentImage;
            _load = BrowseNewImages;

            // CREATE a temporary list to store all assets in the directory
            IList<string> _filePaths = new List<string>();
            try {
                // GET the path to all Images in a directory
                // and populate the _filePaths List
                _filePaths = Directory.GetFiles("../../FishAssets", "*.*", SearchOption.AllDirectories).ToList();
            }
            catch (Exception e) {
                Console.WriteLine("Error: {0}", e.ToString());
            }

            // CONVERT all Image paths (string) to Images
            // and POPULATE the _imageFiles Dictionary.
            IList<string> _identifiers = LoadImages(_filePaths);
            for (int i = 0; i < _identifiers.Count; i++)
            {
                _imageFiles.Add(_identifiers[i], imageProcess.ConvertToImage(_filePaths[i]));
                // REVIEW - Do we really need this?
                _imagesData.Add(new ImageData());
            }
        }

        public Image GetCurrentImage(int increment)
        {
            // Increment current index by passed value
            _currentIndex += increment;
            // Reset current index if boundaries are reached 
            if (_currentIndex > _imageFiles.Count - 1) { _currentIndex = 0; }
            else if (_currentIndex < 0) { _currentIndex = _imageFiles.Count - 1; }

            // REVIEW - Change this to be the panel width and height?
            Image original = _imageFiles.ElementAt(_currentIndex).Value;
            Image imageToGet = GetImage(_imageFiles.ElementAt(_currentIndex).Key, original.Width, original.Height);
            //GetImage(_imageFiles.ElementAt(_currentIndex).Key, original.Width, original.Height);
            return imageToGet;
        }

        public void BrowseNewImages()
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

                if (fileDialog.ShowDialog() == DialogResult.OK)
                {
                    // Iterates through all selected files adding them to dictionary
                    IList<string> _filesIdentifiers = LoadImages(fileDialog.FileNames);
                    for (int i = 0; i < fileDialog.FileNames.Length; i++)
                    {
                        string path = fileDialog.FileNames[i];
                        _imageFiles.Add(_filesIdentifiers[i], imageProcess.ConvertToImage(path));
                    }
                }
            }
        }

        public Image GetImage(string key, int frameWidth, int frameHeight)
        {
            return imageProcess.ResizeImage(_imageFiles[key], frameWidth, frameHeight);
        }

        public IList<string> LoadImages(IList<string> pathfilenames)
        {
            IList<string> _identifiers = new List<string>();
            foreach (string name in pathfilenames)
            {
                _identifiers.Add(Path.GetFileName(name));
            }

            return _identifiers;
        }
    }
}
