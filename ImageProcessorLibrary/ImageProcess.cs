using ImageProcessor;
using ImageProcessor.Imaging.Formats;
using System.Drawing;
using System.IO;

// By Filipe Ribeiro
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
        private ImageFactory imageFactory;

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
                    imageFactory = new ImageFactory(preserveExifData: true);
                    // Load, format and save an image.
                    imageFactory.Load(inStream)
                                .Format(format)
                                .Save(outStream);
                }
            }

            return imageFactory.Image;
        }

        public Image ResizeImage(Image image, int width, int height)
        {
            Size size = new Size(width, height);
            using (MemoryStream outStream = new MemoryStream())
            {
                imageFactory = new ImageFactory(preserveExifData: true);
                // Load, resize and save an image.
                imageFactory.Load(image)
                            .Resize(size)
                            .Save(outStream);
            }

            return imageFactory.Image;
        }
    }
}
