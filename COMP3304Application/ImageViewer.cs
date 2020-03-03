using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;
using ImageProcessorLibrary;

namespace COMP3304Application
{
    public partial class ImageViewer : Form
    {
        private ImageHandler _imageHandler;

        public ImageViewer()
        {
            InitializeComponent();

            // Initialization
            _imageHandler = new ImageHandler(new ImageLoader(), new ImagePicker());

            // SET the background image to be the first in the dictionary
            string key = _imageHandler.ChangeImage(0);
            picturePanel.BackgroundImage = _imageHandler.GetImage(key, 128, 128);
        }

        // EVENTS for when buttons are clicked
        // NEXT image button click
        private void btnNext_Click(object sender, EventArgs e)
        {
            picturePanel.BackgroundImage = _imageHandler.GetImage(
                _imageHandler.ChangeImage(1),
                picturePanel.Width,
                picturePanel.Height);
        }

        // PREVIOUS image button click
        private void btnPrevious_Click(object sender, EventArgs e)
        {
            picturePanel.BackgroundImage = _imageHandler.GetImage(
                _imageHandler.ChangeImage(-1),
                picturePanel.Width,
                picturePanel.Height);
        }

        // LOAD new image button click
        private void btnLoad_Click(object sender, EventArgs e)
        {
            _imageHandler.AddNewImages();
        }

        private void ImageViewer_Resize(object sender, EventArgs e)
        {
            picturePanel.BackgroundImage = _imageHandler.GetImage(
               _imageHandler.ChangeImage(0),
               picturePanel.Width,
               picturePanel.Height);
        }
    }
}
