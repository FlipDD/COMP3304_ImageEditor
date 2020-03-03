using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using ImageResizerLibrary;

namespace COMP3304Application
{
    public partial class Form1 : Form, IModel
    {
        private ImageProcess imageProcess;
        private IList<ImageData> _imagesData;
        private IDictionary<int, Image> _imageFiles;
        private CurrentImage _currentImage;
        private Load _load;
        private int _currentIndex;

        public Form1()
        {
            InitializeComponent();
            // INSTANTIATE the image process class --
            // Used to convert paths into images
            // and format them, i.e. scale, rotate.
            imageProcess = new ImageProcess();

            // INITIALIZE the List that will
            // store image data
            _imagesData = new List<ImageData>();

            // INITIALIZE the Dictionary that will 
            // hold the original Images in memory
            _imageFiles = new Dictionary<int, Image>();
           
            // ASSIGN the delegates
            _currentImage = CurrentImage;
            _load = LoadNewImage;

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
            for (int i = 0; i < _filePaths.Count; i++) {
                _imageFiles.Add(i, imageProcess.ConvertToImage(_filePaths[i]));
                _imagesData.Add(new ImageData());
            }

            // Show first image in collection
            CurrentImage(0);
        }


        public void CurrentImage(int increment)
        {
            // increment current index by passed value
            _currentIndex += increment;
            // reset current index if boundaries are reached 
            if (_currentIndex > _imageFiles.Count - 1) { _currentIndex = 0; }
            else if (_currentIndex < 0) { _currentIndex = _imageFiles.Count - 1; }
            // TODO review this
            // DELETED - get scaled image    
            // to use ORIGINAL WIDHTH AND HEIGHT instead
            // Pictures don't lose quality like this
            // Might need to consider storing scaled width and height?
            Image original = _imageFiles[_currentIndex];
            picturePanel.BackgroundImage = imageProcess.ResizeImage(original, original.Width, original.Height);

            // Save values of new width and height
            //ImageData imageData = _imagesData[_currentIndex];
            //imageData.ResizedWidth = 50;
            //imageData.ResizedHeight = 50;
            //_imagesData[_currentIndex] = imageData;

            //picturePanel.BackgroundImage = imageProcess.ResizeImage(original, _imagesData[_currentIndex].ResizedWidth, _imagesData[_currentIndex].ResizedWidth);
            //pbImage.Image = imageProcess.ResizeImage(_imageFiles[_currentIndex], 150, 150);
        }

        public void LoadNewImage()
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

                DialogResult result = fileDialog.ShowDialog();
                // try catch vs. if (result == DialogResult.OK)
                try {
                    // Iterates through all selected files adding them to dictionary
                    foreach (string newFile in fileDialog.FileNames) {
                        _imageFiles.Add(_imageFiles.Count, imageProcess.ConvertToImage(newFile));
                    }
                }
                catch (Exception a) {
                    Console.WriteLine("Error with importing image: {0}", a);
                }
            }
        }


        // Events for when buttons are clicked
        // NEXT image button click
        private void btnNext_Click(object sender, EventArgs e) => _currentImage(1);

        // PREVIOUS image button click
        private void btnPrevious_Click(object sender, EventArgs e) => _currentImage(-1);

        // LOAD new image button click
        private void btnLoad_Click(object sender, EventArgs e) => _load();

        IList<string> IModel.Load(IList<string> pathfilenames)
        {
            IList<string> imageIdentifiers = new List<string>();
            foreach (string path in pathfilenames) {
                imageIdentifiers.Add(Path.GetFileName(path));
            }

            return imageIdentifiers;
        }

        Image IModel.GetImage(string key, int frameWidth, int frameHeight)
        {
            throw new NotImplementedException();
        }

        //private void Form1_Resize(object sender, EventArgs e)
        //{
        //    Image originalImage = _imageFiles[_currentIndex];
        //    float scaledWidth = picturePanel.Width / originalImage.Width;
        //    float scaledHeight = picturePanel.Height / originalImage.Height;
        //    float scale = Math.Min(scaledHeight, scaledWidth);
        //    float widthResult = originalImage.Width * scale;
        //    float heightResult = originalImage.Height * scale;

        //    // Change image
        //    picturePanel.BackgroundImage = imageProcess
        //                    .ResizeImage(_imageFiles[_currentIndex],
        //                                 (int) widthResult,
        //                                 (int) heightResult);

        //}
    }
}
