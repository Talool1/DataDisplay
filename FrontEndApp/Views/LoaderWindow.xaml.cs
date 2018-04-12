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
        //private string openFileDialogueTitle = "Select File";
        //private string fileType = "CSV Files | *.csv";
        //
        //private string fileDoesntExistMessage = "The File you are trying to load doesn't exist.";
        //private string unnamedFieldMessage = "The Field must have a name.";
        //private string UnselectedFieldToRemoveMessage = "Please select the field you would like to remove.";

        internal ViewModels.LoaderViewModel ViewModel { get; private set; }

        internal LoaderWindow(ViewModels.LoaderViewModel viewModel)
        {
            DataContext = viewModel;
            this.ViewModel = DataContext as ViewModels.LoaderViewModel;
            InitializeComponent();

            DataTypePropBox.SelectedIndex = 0;
        }
    }
}
