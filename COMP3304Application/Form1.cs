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
using ImageResizerLibrary;

namespace COMP3304Application
{
    public partial class Form1 : Form
    {
        private Next _next;
        private Dictionary<int, Image> _imageFiles;
        private List<string> _filePaths;

        public Form1()
        {
            InitializeComponent();
            _next = NextPreviousImage;
            try {
                _filePaths = Directory.GetFiles("../../FishAssets", "*.*", SearchOption.AllDirectories).ToList();
            }
            catch (Exception e) {
                Console.WriteLine("Error: {0}", e.ToString());
            }
            foreach () {
            }

            _imageFiles = new Dictionary<int, Image>();
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

        public void ConvertToImage() {
            ImageResizer _imageResizer = new ImageResizer(_filePaths[1], 150, 100);
            pbImage.Image = _imageResizer.GetResizedImage();
        }
    }
}
