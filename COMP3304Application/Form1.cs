using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace COMP3304Application
{
    public partial class Form1 : Form
    {
        private Next _next;
        private Dictionary<int, Image> _ImageFiles;
        private List<string> _FilePaths;

        public Form1()
        {
            InitializeComponent();
            _next = NextPreviousImage;
            _FilePaths = Directory.GetFiles("../../FishAssets","*.*",SearchOption.AllDirectories).ToList();
            _ImageFiles = new Dictionary<int, Image>();


            //TODO - Implement -- Decide to use either image path (string) or image in memory (Image)
            //ImageResizer _imageResizer = new ImageResizer(_imageData._imageDictionary[randomInt], 150, 100);
            //pbImage.Image = _imageResizer.GetResizedImage();

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            _next(1);
        }

        private void btnPrevious_Click(object sender, EventArgs e)
        {
            _next(-1);
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {

        }

        public void NextPreviousImage(int increment) {
            if (increment == 1) {

            }
            else if (increment == -1) {

            }
        }

        private void pbImage_Click(object sender, EventArgs e)
        {

        }
    }
}
