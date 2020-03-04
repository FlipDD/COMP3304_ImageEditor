// By Nathan 
namespace ImageProcessorLibrary
{
    public class ImagePicker : IImagePicker
    {
        private int _currentIndex = 0;

        public int GetImageIndex(int increment, int count)
        {
            // Increment current index by passed value
            _currentIndex += increment;
            // Reset current index if boundaries are reached 
            if (_currentIndex > count - 1)
                _currentIndex = 0;
            else if (_currentIndex < 0)
                _currentIndex = count - 1;

            return _currentIndex;
        }
    }
}
