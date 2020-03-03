namespace ImageProcessorLibrary
{
    public interface IImagePicker
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="increment"></param>
        /// <param name="imageFiles"></param>
        /// <returns></returns>
        int GetImageIndex(int increment, int count);
    }
}
