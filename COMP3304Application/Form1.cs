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
        private OpenFileDialog fileDialog;
        private int _currentIndex;
        private CurrentImage _currentImage;
        private Load _load;
        private Dictionary<int, Image> _imageFiles;
        private List<string> _filePaths;
        ImageResizer imageResizer;

        public Form1()
        {
            InitializeComponent();
            imageResizer = new ImageResizer();
            _imageFiles = new Dictionary<int, Image>();
            _currentImage = CurrentImage;
            _load = LoadNewImage;
            try {
                _filePaths = Directory.GetFiles("../../FishAssets", "*.*", SearchOption.AllDirectories).ToList();
            }
            catch (Exception e) {
                Console.WriteLine("Error: {0}", e.ToString());
            }
                        
            for (int i = 0; i < _filePaths.Count; i++)
            {
                _imageFiles.Add(i, imageResizer.ConvertToImage(_filePaths[i]));
            }
            CurrentImage(0);
        }


        public void CurrentImage(int increment)
        {
            _currentIndex += increment;
            if (_currentIndex > _imageFiles.Count - 1) { _currentIndex = 0; }
            else if (_currentIndex < 0) { _currentIndex = _imageFiles.Count - 1; }
            pbImage.Image = imageResizer.ResizeImage(_imageFiles[_currentIndex], 150, 150);
        }

        public void LoadNewImage() {
            fileDialog = new OpenFileDialog();
            DialogResult result = fileDialog.ShowDialog();
            try
            {
                string newfile = fileDialog.FileName;
                _imageFiles.Add(_imageFiles.Count, imageResizer.ConvertToImage(newfile));
            }
            catch (Exception a)
            {
                Console.WriteLine("Error with importing image: {0}", a);
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            _currentImage(1);
        }

        private void btnPrevious_Click(object sender, EventArgs e)
        {
            _currentImage(-1);
        }
        
        private void btnLoad_Click(object sender, EventArgs e)
        {
            _load();
        }
        
        private void pbImage_Click(object sender, EventArgs e)
        {

        }
    }
}
