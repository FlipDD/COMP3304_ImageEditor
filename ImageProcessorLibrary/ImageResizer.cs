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
        private string _path;
        public ImageResizer(string path, int width, int height)
        {
            _path = path;

            byte[] photoBytes = File.ReadAllBytes(_path);
            // Format is automatically detected though can be changed.
            ISupportedImageFormat format = new JpegFormat { Quality = 70 };
            //Size size = new Size(150, 0);
            Size size = new Size(width, height);

            using (MemoryStream inStream = new MemoryStream(photoBytes))
            {
                using (MemoryStream outStream = new MemoryStream())
                {
                    imageFactory = new ImageFactory(preserveExifData: true);
                    // Load, resize, set the format and quality and save an image.
                    imageFactory.Load(inStream)
                                .Resize(size)
                                .Format(format)
                                .Save(outStream);
                }
            }
        }

        public Image GetResizedImage() => imageFactory.Image;
    }
}
