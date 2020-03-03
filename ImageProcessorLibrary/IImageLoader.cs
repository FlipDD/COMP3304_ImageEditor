using System.Collections.Generic;

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
