// By Filipe
namespace ImageProcessorLibrary
{
    public interface IImagePicker
    {
        /// <summary>
        /// Gets the next index in the _imageFiles dictionary
        /// </summary>
        /// <param name="currentIndex">the index to the current Image being displayed</param>
        /// <param name="count">the current size of the Dictionary</param>
        /// <returns>the current index in the Dictionary of the Image being displayed +1 </returns>
        int NextImageIndex(int currentIndex, int count);

        /// <summary>
        /// Gets the previous index in the _imageFiles dictionary
        /// </summary>
        /// <param name="currentIndex">the index to the current Image being displayed</param>
        /// <param name="count">the current size of the Dictionary</param>
        /// <returns>the current index in the Dictionary of the Image being displayed -1 </returns>
        int PreviousImageIndex(int currentIndex, int count);
    }
}
