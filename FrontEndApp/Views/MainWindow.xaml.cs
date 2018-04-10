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
using System.Windows.Navigation;
using System.Windows.Shapes;
using DataDisplay;
using FrontEndApp.ViewModels;

namespace FrontEndApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void OpenLoaderWindow(object sender, RoutedEventArgs e)
        {
            LoaderViewModel viewModel = new LoaderViewModel();
            
            LoaderWindow loaderWindow = new LoaderWindow(viewModel);
            loaderWindow.DataContext = viewModel;
            loaderWindow.OnFileLoaded += Load;
            loaderWindow.ShowDialog();
        }

        private void Load(object sender, MainWindowViewModel viewModel)
        {
            PopulateColumns(viewModel.Metadatas);
            DataContext = viewModel;
        }

        private void PopulateColumns(IEnumerable<DataObjectMetadata> metadataCollection)
        {
            dataGridDisplay.Columns.Clear();
            int i = 0;
            foreach (var datacolumn in metadataCollection)
            {
                DataGridTextColumn column = new DataGridTextColumn();
                column.Binding = new Binding(String.Format("Columns[{0}]", i));
                column.Header = datacolumn.columnName;
                dataGridDisplay.Columns.Add(column);
                i++;
            }
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
