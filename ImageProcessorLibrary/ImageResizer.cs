using ImageProcessor;
using ImageProcessor.Imaging.Formats;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImageResizerLibrary
{
    public class ImageResizer
    {
        private ImageFactory imageFactory;

        public Image ConvertToImage(string path)
        {
            byte[] photoBytes = File.ReadAllBytes(path);
            // Format is automatically detected though can be changed.
            ISupportedImageFormat format = new JpegFormat { Quality = 70 };

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
                // Load, format and save an image.
                imageFactory.Load(image)
                            .Resize(size)
                            .Save(outStream);
            }

            return imageFactory.Image;
        }
    }
}
