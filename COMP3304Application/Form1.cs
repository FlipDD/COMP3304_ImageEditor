using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ImageProcessorLibrary;

namespace COMP3304Application
{
    public partial class Form1 : Form
    {
        private ImageHandler _imageHandler;

        public Form1()
        {
            InitializeComponent();

            _imageHandler = new ImageHandler(new ImageLoader(), new ImagePicker());
            //_imageHandler.InitializeHandler();
            picturePanel.BackgroundImage = _imageHandler.ChangeImage(0);
        }

        // EVENTS for when buttons are clicked
        // NEXT image button click
        private void btnNext_Click(object sender, EventArgs e)
        {
            picturePanel.BackgroundImage = _imageHandler.ChangeImage(1);
        }

        // PREVIOUS image button click
        private void btnPrevious_Click(object sender, EventArgs e)
        {
            picturePanel.BackgroundImage = _imageHandler.ChangeImage(-1);
        }

        // LOAD new image button click
        private void btnLoad_Click(object sender, EventArgs e)
        {
            _imageHandler.AddNewImages();
        } 
    }
}
