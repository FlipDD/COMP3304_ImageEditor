using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COMP3304Application
{
    class ImagePicker : IImagePicker
    {
        private int _currentIndex = 0;

        public Image GetCurrentImage(int increment, IDictionary<string, Image> imageFiles)
        {
            // Increment current index by passed value
            _currentIndex += increment;
            // Reset current index if boundaries are reached 
            if (_currentIndex > imageFiles.Count - 1) { _currentIndex = 0; }
            else if (_currentIndex < 0) { _currentIndex = imageFiles.Count - 1; }

            // REVIEW - Change this to be the panel width and height?
            Image original = imageFiles.ElementAt(0).Value;
            Image newImage = GetImage(imageFiles.ElementAt(_currentIndex).Key, original.Width, original.Height);

            return newImage;
        }
    }
}
