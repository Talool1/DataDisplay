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
        IImporter importer;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void OpenLoaderWindow(object sender, RoutedEventArgs e)
        {
            LoaderWindow loaderWindow = new LoaderWindow();
            loaderWindow.OnFileLoaded += Load;
            loaderWindow.ShowDialog();
        }

        private void Load(object sender, DisplayViewModel viewModel)
        {
            PopulateColumns(viewModel.dataObjectMetadata);
            PopulateData(viewModel.importer);

        }

        private void PopulateData(IImporter importer)
        {
            var data = importer.LoadAll();
            foreach (var dataItem in data)
            {
                dataGridDisplay.Items.Add(dataItem);
                //dataGridDisplay.ItemsSource = data;

                //for (int i = 0; i < dataItem.Columns.Length; i++)
                //{
                //    dataGridDisplay.Items.Add(dataItem);
                //}
            }
        }

        private void PopulateColumns(IEnumerable<DataObjectMetadata> metadataCollection)
        {
            dataGridDisplay.Columns.Clear();
            foreach (var datacolumn in metadataCollection)
            {
                DataGridTextColumn column = new DataGridTextColumn();
                column.Header = datacolumn.columnName;
                dataGridDisplay.Columns.Add(column);
            }
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
