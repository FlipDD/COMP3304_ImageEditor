using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ImageResizerLibrary;

namespace COMP3304Application
{
    class ImageHandler : IModel
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
        }

        public void InitializeHandler()
        {
            _imageLoader.LoadInitalImages(_imageProcess, _imageFiles);
        }

        public void OpenLoadWindow()
        {
            _imageLoader.BrowseNewImages(_imageFiles);
        }

        public Image GetImage(int increment)
        {
            return _imagePicker.GetCurrentImage(increment);
        }

        public IList<string> LoadImages(IList<string> pathfilenames)
        {
            throw new NotImplementedException();
        }

        public Image GetImage(string key, int frameWidth, int frameHeight)
        {
            throw new NotImplementedException();
        }
    }
}
