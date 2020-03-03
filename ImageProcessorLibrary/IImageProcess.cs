using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImageProcessorLibrary
{
    interface IImageProcess
    {
        /// <summary>
        /// CONVERT to an Image by providing a path
        /// and saving it to the ImageFactory --
        /// RETURN that Image at the end.
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        Image ConvertToImage(string path);

        /// <summary>
        /// RESIZE an Image by providing that Image
        /// and a new width and height --
        /// RETURN that Image at the end.
        /// </summary>
        /// <param name="image"></param>
        /// <param name="width"></param>
        /// <param name="height"></param>
        /// <returns></returns>
        Image ResizeImage(Image image, int width, int height);
    }
}
