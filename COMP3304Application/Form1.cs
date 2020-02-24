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
        private int _currentIndex;
        private CurrentImage _currentImage;
        private Load _load;
        private Dictionary<int, Image> _imageFiles;
        private List<string> _filePaths;
        private ImageProcess imageProcess;

        public Form1()
        {
            InitializeComponent();
            imageProcess = new ImageProcess();
            //Dictionary and list for image file data
            _imageFiles = new Dictionary<int, Image>();
            List<string> _filePaths = new List<string>();            
            // delegate assignment
            _currentImage = CurrentImage;
            _load = LoadNewImage;            

            // Search and add all image filenames to  list
            try {
                _filePaths = Directory.GetFiles("../../FishAssets", "*.*", SearchOption.AllDirectories).ToList();
            }
            catch (Exception e) {
                Console.WriteLine("Error: {0}", e.ToString());
            }

            // Populate Dictionary with converted images from List            
            for (int i = 0; i < _filePaths.Count; i++)
            {
                _imageFiles.Add(i, imageProcess.ConvertToImage(_filePaths[i]));
            }
            CurrentImage(0);
        }


        public void CurrentImage(int increment)
        {
            _currentIndex += increment;
            if (_currentIndex > _imageFiles.Count - 1) { _currentIndex = 0; }
            else if (_currentIndex < 0) { _currentIndex = _imageFiles.Count - 1; }
            pbImage.Image = imageProcess.ResizeImage(_imageFiles[_currentIndex], 150, 150);
        }

        public void LoadNewImage() {
            // creates new dialog box 
            OpenFileDialog fileDialog = new OpenFileDialog();
            fileDialog.Title = "Select Images";
            // Filters image extensions only
            fileDialog.Filter = "Image files (*.jpg, *.jpeg, *.jpe, *.jfif, *.png) | *.jpg; *.jpeg; *.jpe; *.jfif; *.png";
            // ensures multiselect is enabled
            fileDialog.Multiselect = true;
            DialogResult result = fileDialog.ShowDialog(); 
            try
            {
                // Iterates through all selected files adding them to dictionary
                foreach (string newFile in fileDialog.FileNames)
                {
                    _imageFiles.Add(_imageFiles.Count, imageProcess.ConvertToImage(newFile));
                }                
               
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
