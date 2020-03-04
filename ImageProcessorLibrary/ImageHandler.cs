using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;

// By Filipe
namespace ImageProcessorLibrary
{
    /// <summary>
    /// The class that will handle the Images
    /// It will handle the processing, the loading,
    /// the browsing and the picker.
    /// </summary>
    public class ImageHandler : IModel
    {
        /// <summary>
        /// IImageLoader named _imageLoader
        /// Responsible for loading and browsing Images
        /// </summary>
        private readonly IImageLoader _imageLoader;
        /// <summary>
        /// IImagePicker named _imagePicker
        /// Responsible for changing the Image index in the _imageFiles Dictionary
        /// </summary>
        private readonly IImagePicker _imagePicker;

        // Declaring a private ImageProcess named _imageProcess
        private ImageProcess _imageProcess;
        // Declaring a private Dictionary<string, Image> named _imageFiles
        private IDictionary<string, Image> _imageFiles;

        public ImageHandler(IImageLoader imageLoader, IImagePicker imagePicker)
        {
            // Responsible for loading and browsing Images
            _imageLoader = imageLoader;
            // Responsible for changing the Image index in the _imageFiles Dictionary
            _imagePicker = imagePicker;

            // Initialize the Image Process class
            // used to process/edit images
            _imageProcess = new ImageProcess();

            // Initialize the Dictionary used to 
            // store the name of the Images and the
            // actual Images
            _imageFiles = new Dictionary<string, Image>();

            // Populate the Image Dictionary with some initial Images so that
            // the program starts with a few already loaded up
            PopulateImageDictionary(_imageLoader.LoadInitalImages());
        }

        /// <summary>
        /// Get a key in the Dictionary by giving an index
        /// </summary>
        /// <param name="increment">an int; either to increase, decrease or keep the same index</param>
        /// <returns>a string containing the key used in the _imageFiles Dictionary</returns>
        public string ChangeImage(int increment)
        {
            // Set the new index to be +1 or -1, depending on increment
            int index = _imagePicker.GetImageIndex(increment, _imageFiles.Count);
            // Get the key with the new index
            string key = _imageFiles.ElementAt(index).Key;

            return key;
        }

        /// <summary>
        /// Browse for new Images and call PopulateImageDictionary
        /// if any Images were found
        /// </summary>
        public void AddNewImages()
        {
            // Open browse window
            IList<string> imagePaths = _imageLoader.BrowseNewImages();
            // If we couldn't find anything stop the logic here
            if (imagePaths == null)
                return;

            // Populate the dictionary
            PopulateImageDictionary(imagePaths);
        }

        /// <summary>
        /// Populate the Images Dictionary with a List of strings 
        /// containing the paths for the Images
        /// </summary>
        /// <param name="imagePaths">a vector of strings; each string containing path 
        /// for an image file to be inserted into the _imageFiles dictionary</param>
        public void PopulateImageDictionary(IList<string> imagePaths)
        {
            var images = new List<Image>();
            foreach (string path in imagePaths)
            {
                // Convert the path of an Image to an Image
                Image convertedImage = _imageProcess.ConvertToImage(path);
                // Add the Image to the local images List
                images.Add(convertedImage);
            }

            // Convert paths to ids and store them temporarily
            IList<string> imageIds = LoadImages(imagePaths);

            // Add the new images to the dictionary
            for (int i = 0; i < images.Count; i++)
            {
                // Make sure there aren't images with the same name
                int idNumber = 0;
                while (_imageFiles.ContainsKey(imageIds[i]))
                {
                    // A duplicated an Image with the same name was added
                    // we add a number at the end to make the key different
                    idNumber++;
                    imageIds[i] = imageIds[i] + idNumber;
                }

                // Add the key (string) and value (Image) to the _imageFiles Dictionary
                _imageFiles.Add(imageIds[i], images[i]);
            }
        }

        /// <summary>
        /// Load the media items pointed to by 'pathfilenames' into the 'Model'
        /// </summary>
        /// <param name="pathfilenames">a vector of strings; each string containing path/filename for an image file to be loaded</param>
        /// <returns>the unique identifiers of the images that have been loaded</returns>
        public IList<string> LoadImages(IList<string> pathfilenames)
        {
            var imageIdentifiers = new List<string>();
            foreach (string path in pathfilenames)
            {
                // Add the names of each image to the local List
                imageIdentifiers.Add(Path.GetFileName(path));
            }

            return imageIdentifiers;
        }

        /// <summary>
        /// Return a copy of the image specified by 'key', scaled according to the dimensions of the visual container (i.e. frame) it will be viewed in.
        /// </summary>
        /// <param name="key">the unique identifier for the image to be returned</param>
        /// <param name="frameWidth">the width (in pixels) of the 'frame' it is to occupy</param>
        /// <param name="frameHeight">the height (in pixles) of the 'frame' it is to occupy</param>
        /// <returns>the Image pointed identified by key</returns>
        public Image GetImage(string key, int frameWidth, int frameHeight)
        {
            // Get the Image from the Dictionary at a certain key
            Image originalImage = _imageFiles[key];
            // Resize the Image with the specific width and height
            Image imageToGet = _imageProcess.ResizeImage(originalImage, frameWidth, frameHeight);

            return imageToGet;
        }
    }
}
