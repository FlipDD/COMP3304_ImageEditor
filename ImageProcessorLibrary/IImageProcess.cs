using System.Drawing;

// By Filipe
namespace ImageProcessorLibrary
{
    interface IImageProcess
    {
        /// <summary>
        /// CONVERTS to an Image by providing a path
        /// </summary>
        /// <param name="path">a string; containing the path for a file to be converted to a Drawing.Image</param>
        /// <returns>returns the Image pointed by the path</returns>
        Image ConvertToImage(string path);

        /// <summary>
        /// RESIZE an Image with a specific width and height
        /// </summary>
        /// <param name="image">an Image; the Image to be Resized</param>
        /// <param name="width">an integer; the width the new Image should have</param>
        /// <param name="height">an integer; the height the new Image should have</param>
        /// <returns>the resized Image</returns>
        Image ResizeImage(Image image, int width, int height);
    }
}
