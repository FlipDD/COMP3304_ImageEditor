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
        private ImageProcess imageProcess;

        public Form1()
        {
            InitializeComponent();
            // INITIALIZE the Dictionary that will 
            // hold the original Images in memory.
            _imageFiles = new Dictionary<int, Image>();
            _next = NextPreviousImage;

            // GET the path to all Images in a directory
            // and assign them to the _filePaths List
            List<string> _filePaths = new List<string>();
            try {
                _filePaths = Directory.GetFiles("../../FishAssets", "*.*", SearchOption.AllDirectories).ToList();
            }
            catch (Exception e) {
                Console.WriteLine("Error: {0}", e.ToString());
            }

            // INSTANTIATE the image process class --
            // Used to convert paths into images
            // and format them, i.e. scale, rotate.
            imageProcess = new ImageProcess();

            // CONVERT all Image paths (string) to Images
            // and ADD them to the _imageFiles Dictionary.
            for (int i = 0; i < _filePaths.Count; i++) {
                _imageFiles.Add(i, imageProcess.ConvertToImage(_filePaths[i]));
            }

            // ASSIGN a RESIZED image to the picture box.
            pbImage.Image = imageProcess.ResizeImage(_imageFiles[0], 200, 200);
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

        // By Filipe Ribeiro
        private void btnLoad_Click(object sender, EventArgs e)
        {
            // Display a dialog box to prompt the user to select a file
            OpenFileDialog dialogBox = new OpenFileDialog();
            // Filter the results to only allow specific file types
            dialogBox.Filter = "Image Files(*.BMP; *.JPG; *.GIF; *.PNG;)| *.BMP; *.JPG; *.GIF *.PNG | All files(*.*) | *.*";
            dialogBox.FilterIndex = 1;
            // TODO Maybe add this later? - Select multiple images
            // dialogBox.Multiselect = true;

            if (dialogBox.ShowDialog() == DialogResult.OK)
            {
                int index = _imageFiles.Count;
                Image newImage = imageProcess.ConvertToImage(dialogBox.FileName);
                _imageFiles.Add(index, newImage);
                //string[] allImages = dialogBox.FileNames; // if Multiselect = true           
            }
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
