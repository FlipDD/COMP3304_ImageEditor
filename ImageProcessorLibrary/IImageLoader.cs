using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImageProcessorLibrary
{
    public interface IImageLoader
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="imageProcess"></param>
        /// <param name="imageFiles"></param>
        IList<string> LoadInitalImages();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="imageFiles"></param>
        IList<string> BrowseNewImages();
    }
}
