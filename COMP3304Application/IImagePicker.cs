using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COMP3304Application
{
    interface IImagePicker
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="increment"></param>
        /// <param name="imageFiles"></param>
        /// <returns></returns>
        Image GetCurrentImage(int increment, IDictionary<string, Image> imageFiles);
    }
}
