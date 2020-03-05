using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;
using ImageProcessorLibrary;

// By Filipe and Nathan
namespace COMP3304Application
{
    public partial class ImageViewer : Form
    {
        // Declaring a private ImageHandler named _imageHandler
        private ImageHandler _imageHandler;
        // Declaring a instance of the Logger called logger
        private Logger logger = Logger.Instance;

        public ImageViewer()
        {
            // Form initialization
            InitializeComponent();

            // Instantiating the ImageHandler
            // Responsible for loading, browsing and editing images
            _imageHandler = new ImageHandler(new ImageLoader(), new ImageBrowser(), new ImagePicker());

            // Set the background image to be the first in the dictionary
            // and Resize it to be the width and height of the Panel
            picturePanel.BackgroundImage = _imageHandler.GetInitialImages(
                picturePanel.Width,
                picturePanel.Height);
        }

        private void ImageViewer_Resize(object sender, EventArgs e)
        {
            // Resize Image when the window size of the program changes
            // to the width and height of the container Panel
            picturePanel.BackgroundImage = _imageHandler.GetImage(
               _imageHandler.GetCurrentImageKey(),
               picturePanel.Width,
               picturePanel.Height);
        }

        // EVENTS for when buttons are clicked
        private void btnNext_Click(object sender, EventArgs e)
        {
            logger.PrintMessage("Clicked on the next button");

            // Show and resize the next Image in the _imageFiles Dictionary
            picturePanel.BackgroundImage = _imageHandler.GetImage(
                _imageHandler.GetNextImageKey(),
                picturePanel.Width,
                picturePanel.Height);
        }

        private void btnPrevious_Click(object sender, EventArgs e)
        {
            logger.PrintMessage("Clicked on the previous button");

            // Show and resize the previous Image in the _imageFiles Dictionary
            picturePanel.BackgroundImage = _imageHandler.GetImage(
                _imageHandler.GetPreviousImageKey(),
                picturePanel.Width,
                picturePanel.Height);
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            logger.PrintMessage("Clicked on the load images button");

            // Open the browse window to search for new Images to add
            bool addedAnyImaged = _imageHandler.AddNewImages();
            if (addedAnyImaged)
            {
                picturePanel.BackgroundImage = _imageHandler.GetImage(
                     _imageHandler.GetCurrentImageKey(),
                    picturePanel.Width,
                    picturePanel.Height);
            }
        }
    }
}
