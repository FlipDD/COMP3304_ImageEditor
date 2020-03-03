using ImageProcessor;
using ImageProcessor.Imaging.Formats;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// By Filipe Ribeiro
namespace ImageResizerLibrary
{
    /// <summary>
    /// Used to do any kind of work related to image processing
    /// such as convert and resize --
    /// Further functionality will be added here in the future --
    /// We will be able to simply call the methods in this 
    /// class to edit the image.
    /// </summary>
    public class ImageProcess
    {
        private ImageFactory imageFactory;

        // CONVERT to an Image by providing a path
        // and saving it to the ImageFactory --
        // RETURN that Image at the end.
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

        // RESIZE an Image by providing that Image
        // and a new width and height --
        // RETURN that Image at the end.
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
