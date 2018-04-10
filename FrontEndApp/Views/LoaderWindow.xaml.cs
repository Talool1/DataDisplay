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
        internal event EventHandler<ViewModels.MainWindowViewModel> OnFileLoaded;
        internal ViewModels.LoaderViewModel ViewModel { get; private set; }

        internal LoaderWindow(ViewModels.LoaderViewModel viewModel)
        {
            DataContext = viewModel;
            this.ViewModel = DataContext as ViewModels.LoaderViewModel;
            InitializeComponent();

            DataTypePropBox.SelectedIndex = 0;
        }

        private void TEMP_GenerateData()
        {
            string filePath = Filepath_Textbox.Text;

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

            IImporter importer = new CsvImporter(filePath, dataTypes);

            var viewModel = new ViewModels.MainWindowViewModel(meta, importer);

            OnFileLoaded(this, viewModel);
            DialogResult = true;
        }

        private void Cancel_Btn_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
        
        private void Browse_Btn_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialogue = new OpenFileDialog();
            openFileDialogue.Title = openFileDialogueTitle;
            openFileDialogue.Filter = fileType;
            openFileDialogue.FileOk += (s, args) => { ViewModel.FilePath = openFileDialogue.FileName; };
            openFileDialogue.CheckPathExists = true;
            openFileDialogue.ShowDialog();
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
