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
            _imageFiles = new Dictionary<int, Image>();
            _next = NextPreviousImage;
            try {
                _filePaths = Directory.GetFiles("../../FishAssets", "*.*", SearchOption.AllDirectories).ToList();
            }
            catch (Exception e) {
                Console.WriteLine("Error: {0}", e.ToString());
            }

            ImageResizer imageResizer = new ImageResizer();
            for (int i = 0; i < _filePaths.Count; i++)
            {
                _imageFiles.Add(i, imageResizer.ConvertToImage(_filePaths[i]));
            }

            pbImage.Image = imageResizer.ResizeImage(_imageFiles[2], 50, 50);

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
