using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using DataDisplay;

namespace FrontEndApp
{
    /// <summary>
    /// Interaction logic for LoaderWindow.xaml
    /// </summary>
    public partial class LoaderWindow : Window
    {
        private string openFileDialogueTitle = "Select File";
        private string fileType = "CSV Files | *.csv";
        private string fileDoesntExistMessage = "The File you are trying to load doesn't exist.";
        private string errorMessageCaption = "Error";
        private readonly bool checkContinuously = true;
        private OpenFileDialog openFileDialogue;
        internal event EventHandler<IImporter> OnFileLoaded;

        public LoaderWindow()
        {
            InitializeComponent();
            if (checkContinuously)
                OK_Btn.IsEnabled = false;
        }

        private void OK_Btn_Click(object sender, RoutedEventArgs e)
        {
            string filePath = Filepath_Textbox.Text;
            if (!ValidateFilepath())
            {
                MessageBox.Show(fileDoesntExistMessage, errorMessageCaption, MessageBoxButton.OK ,MessageBoxImage.Error);
                return;
            }

            OnFileLoaded(this, null);
            DialogResult = true;
        }

        private void Cancel_Btn_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
        
        private void Browse_Btn_Click(object sender, RoutedEventArgs e)
        {
            openFileDialogue = new OpenFileDialog();
            openFileDialogue.Title = openFileDialogueTitle;
            openFileDialogue.Filter = fileType;
            openFileDialogue.FileOk += BrowseToFile;
            openFileDialogue.CheckPathExists = true;
            openFileDialogue.ShowDialog();
            openFileDialogue = null;
        }

        private void BrowseToFile(object sender, System.ComponentModel.CancelEventArgs e)
        {
            // Direct to Uri
            Filepath_Textbox.Text = openFileDialogue.FileName; 
        }

        private void Filepath_Textbox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (checkContinuously)
                OK_Btn.IsEnabled = ValidateFilepath();
        }

        private bool ValidateFilepath()
        {
            string path = Filepath_Textbox.Text;
            return System.IO.File.Exists(path);
        }
    }
}
