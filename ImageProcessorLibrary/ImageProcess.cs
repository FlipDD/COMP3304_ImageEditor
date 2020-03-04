using ImageProcessor;
using ImageProcessor.Imaging.Formats;
using System.Drawing;
using System.IO;

// By Filipe
namespace ImageProcessorLibrary
{
    /// <summary>
    /// Used to do any kind of work related to image processing
    /// such as convert and resize --
    /// Further functionality will be added here in the future --
    /// We will be able to simply call the methods in this 
    /// class to edit the image.
    /// </summary>
    public class ImageProcess : IImageProcess
    {
        private ImageFactory _imageFactory = new ImageFactory(preserveExifData: true);

        /// <summary>
        /// CONVERTS to an Image by providing a path
        /// </summary>
        /// <param name="path">a string; containing the path for a file to be converted to a Drawing.Image</param>
        /// <returns>returns the Image pointed by the path</returns>
        public Image ConvertToImage(string path)
        {
            byte[] photoBytes = File.ReadAllBytes(path);
            // Format is automatically detected though can be changed.
            ISupportedImageFormat format = new JpegFormat { Quality = 70 };

            // We prefer "Using" instead of .Dispose after using MemoryStream
            using (MemoryStream inStream = new MemoryStream(photoBytes))
            {
                using (MemoryStream outStream = new MemoryStream())
                {
                    // Load, format and save the image.
                    _imageFactory.Load(inStream)
                            .Format(format)
                            .Save(outStream);
                }
            }

             return _imageFactory.Image;
        }

        /// <summary>
        /// RESIZE an Image with a specific width and height
        /// </summary>
        /// <param name="image">an Image; the Image to be Resized</param>
        /// <param name="width">an integer; the width the new Image should have</param>
        /// <param name="height">an integer; the height the new Image should have</param>
        /// <returns>the resized Image</returns>
        public Image ResizeImage(Image image, int width, int height)
        {
            // Set the size to be the provided by the parameters
            Size size = new Size(width, height);
            using (MemoryStream outStream = new MemoryStream())
            {
                // Load, resize and save the image.
                _imageFactory.Load(image)
                            .Resize(size)
                            .Save(outStream);
            }

            return _imageFactory.Image;
        }
    }
}
