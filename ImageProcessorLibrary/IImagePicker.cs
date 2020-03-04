// By Filipe
namespace ImageProcessorLibrary
{
    public interface IImagePicker
    {
        /// <summary>
        /// Gets the index of an Image in the "_imageFiles" dictionary
        /// Depending on how much we increment (-1, 0 or 1)
        /// </summary>
        /// <param name="increment">an integer; the amount we're incrementing by</param>
        /// <param name="count">an integer; the current size of the dictionary</param>
        /// <returns>the index we're gonna use</returns>
        int GetImageIndex(int increment, int count);
    }
}
