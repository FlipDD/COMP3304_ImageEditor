// By Nathan 
namespace ImageProcessorLibrary
{
    public class ImagePicker : IImagePicker
    {
        /// <summary>
        /// Gets the next index in the _imageFiles dictionary
        /// </summary>
        /// <param name="currentIndex">the index to the current Image being displayed</param>
        /// <param name="count">the current size of the Dictionary</param>
        /// <returns>the current index in the Dictionary of the Image being displayed +1 </returns>
        public int NextImageIndex(int currentIndex, int count)
        {
            // Increment current index by passed value
            currentIndex++;
            // Reset current index if boundaries are reached 
            if (currentIndex > count - 1)
                currentIndex = 0;

            return currentIndex;
        }

        /// <summary>
        /// Gets the previous index in the _imageFiles dictionary
        /// </summary>
        /// <param name="currentIndex">the index to the current Image being displayed</param>
        /// <param name="count">the current size of the Dictionary</param>
        /// <returns>the current index in the Dictionary of the Image being displayed -1 </returns>
        public int PreviousImageIndex(int currentIndex, int count)
        {
            // Decrement current index by passed value
            currentIndex--;
            // Reset current index if boundaries are reached 
            if (currentIndex < 0)
                currentIndex = count - 1;

            return currentIndex;
        }
    }
}
