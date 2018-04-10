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
        private string unnamedFieldMessage = "The Field must have a name.";
        private string UnselectedFieldToRemoveMessage = "Please select the field you would like to remove.";
        private readonly bool checkContinuously = true;
        private OpenFileDialog openFileDialogue;
        internal event EventHandler<ViewModels.DisplayViewModel> OnFileLoaded;
        internal ViewModels.LoaderViewModel ViewModel { get; private set; }

        internal LoaderWindow(ViewModels.LoaderViewModel viewModel)
        {
            this.ViewModel = viewModel;
            InitializeComponent();
            if (checkContinuously)
                OK_Btn.IsEnabled = false;

            // Temp
            DataTypePropBox.Items.Add(typeof(DateTime));
            DataTypePropBox.Items.Add(typeof(int));
            DataTypePropBox.SelectedIndex = 0;
        }

        private void OK_Btn_Click(object sender, RoutedEventArgs e)
        {
            string filePath = Filepath_Textbox.Text;
            if (!ValidateFilepath())
            {
                MessageBox.Show(fileDoesntExistMessage, "Error", MessageBoxButton.OK ,MessageBoxImage.Error);
                return;
            }

            // TEMP
            DataObjectMetadata[] meta = new DataObjectMetadata[6];
            Type[] dataTypes = new Type[]
            {
                typeof(DateTime),
                typeof(int),
                typeof(int),
                typeof(int),
                typeof(int),
                typeof(int),
            };

            string[] dataNames = new string[]
            {
                "The Time!",
                "The Num1!",
                "The Num2!",
                "The Num3!",
                "The Num4!",
                "The Num5!",
            };

            for (int i = 0; i < meta.Length; i++)
            {
                meta[i] = new DataObjectMetadata(dataNames[i], dataTypes[i]);
            }

            IImporter importer = new NewCsvImporter(filePath, dataTypes);

            var viewModel = new ViewModels.DisplayViewModel(meta, importer);
            
            OnFileLoaded(this, viewModel);
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
            //openFileDialogue.FileOk += BrowseToFile;
            openFileDialogue.FileOk += (s, args) => { ViewModel.FilePath = openFileDialogue.FileName; };
            openFileDialogue.CheckPathExists = true;
            openFileDialogue.ShowDialog();
            openFileDialogue = null;
        }

        private void BrowseToFile(object sender, System.ComponentModel.CancelEventArgs e)
        {
            // Direct to Uri
            //Filepath_Textbox.Text = openFileDialogue.FileName; 
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

        private void AddBtn_Click(object sender, RoutedEventArgs e)
        {
            string dataFieldName = FieldNameTextBox.Text;
            // Validate Input
            if (dataFieldName == string.Empty)
            {
                MessageBox.Show(unnamedFieldMessage,"Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
            }

            // Add!
            DataObjectMetadata metadata = new DataObjectMetadata(FieldNameTextBox.Text, DataTypePropBox.SelectedItem as Type);
            MetadataConfigurationTable.Items.Add(metadata);
        }

        private void RemoveBtn_Click(object sender, RoutedEventArgs e)
        {
            int selectedItemIndex = MetadataConfigurationTable.SelectedIndex;
            // Validate
            if (selectedItemIndex < 0)
            {
                MessageBox.Show(UnselectedFieldToRemoveMessage, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            // Remove
            MetadataConfigurationTable.Items.RemoveAt(selectedItemIndex);
        }
    }
}
