using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// By Filipe
namespace ImageProcessorLibrary
{
    public interface IImageBrowser
    {
        /// <summary>
        /// Browse for new images with the Windows Explorer
        /// </summary>
        /// <returns>a vector of strings containing the path for each image selected</returns>
        IList<string> BrowseNewImages();
    }
}
