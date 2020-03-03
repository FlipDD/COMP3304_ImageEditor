using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace COMP3304Application
{
    public partial class Form1 : Form
    {
        private ImageHandler _imageHandler;

        public Form1()
        {
            InitializeComponent();

            _imageHandler = new ImageHandler();
            picturePanel.BackgroundImage = _imageHandler.GetCurrentImage(0);
        }

        // Events for when buttons are clicked
        // NEXT image button click
        private void btnNext_Click(object sender, EventArgs e)
        {
            picturePanel.BackgroundImage = _imageHandler.GetCurrentImage(1);
        }

        // PREVIOUS image button click
        private void btnPrevious_Click(object sender, EventArgs e)
        {
            picturePanel.BackgroundImage = _imageHandler.GetCurrentImage(-1);
        }

        // LOAD new image button click
        private void btnLoad_Click(object sender, EventArgs e) => _imageHandler.BrowseNewImages();
    }
}
