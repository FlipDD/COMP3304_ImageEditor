using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImageProcessorLibrary
{
    public class ImageHandler : IModel
    {
        private readonly IImageLoader _imageLoader;
        private readonly IImagePicker _imagePicker;

        public ImageProcess _imageProcess;
        public IDictionary<string, Image> _imageFiles;

        public ImageHandler(IImageLoader imageLoader, IImagePicker imagePicker)
        {
            _imageLoader = imageLoader;
            _imagePicker = imagePicker;

            _imageProcess = new ImageProcess();
            _imageFiles = new Dictionary<string, Image>();

            PopulateImageDictionary(_imageLoader.LoadInitalImages());
        }

        public void InitializeHandler()
        {
        }

        public Image ChangeImage(int increment)
        {
            int index = _imagePicker.GetImageIndex(increment, _imageFiles.Count);
            return _imageFiles.ElementAt(index).Value;
        }

        public void AddNewImages()
        {
            // OPEN browse window
            IList<string> _imagePaths = _imageLoader.BrowseNewImages();

            // Populate the dictionary
            PopulateImageDictionary(_imagePaths);
        }

        public void PopulateImageDictionary(IList<string> imagePaths)
        {
            // CONVERT paths to Images and store them temporarily
            IList<Image> _images = new List<Image>();
            foreach (string path in imagePaths)
            {
                _images.Add(_imageProcess.ConvertToImage(path));
            }

            // CONVERT paths to ids and store them temporarily
            IList<string> _imageIds = LoadImages(imagePaths);

            // ADD the new images to the dictionary
            for (int i = 0; i < _images.Count; i++)
            {
                // Make sure there aren't images with the same name
                int idNumber = 0;
                while (_imageFiles.ContainsKey(_imageIds[i]))
                {
                    idNumber++;
                    _imageIds[i] = _imageIds[i] + idNumber;
                }

                _imageFiles.Add(_imageIds[i], _images[i]);
            }
        }

        public IList<string> LoadImages(IList<string> pathfilenames)
        {
            IList<string> _imageIdentifiers = new List<string>();
            foreach (string path in pathfilenames)
            {
                _imageIdentifiers.Add(Path.GetFileName(path));
            }

            return _imageIdentifiers;
        }

        public Image GetImage(string key, int frameWidth, int frameHeight)
        {
            Image _originalImage = _imageFiles[key];
            Image _imageToGet = _imageProcess.ResizeImage(_originalImage, frameWidth, frameHeight);
            return _imageToGet;
        }
    }
}
