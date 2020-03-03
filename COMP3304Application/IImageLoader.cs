using ImageResizerLibrary;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COMP3304Application
{
    interface IImageLoader
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="imageProcess"></param>
        /// <param name="imageFiles"></param>
        void LoadInitalImages(ImageProcess imageProcess, IDictionary<string, Image> imageFiles);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="imageFiles"></param>
        void BrowseNewImages(IDictionary<string, Image> imageFiles);
    }
}
