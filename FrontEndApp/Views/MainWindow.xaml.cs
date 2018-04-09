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
            loaderWindow.OnFileLoaded += LoadFile;
            loaderWindow.ShowDialog();
        }

        void LoadFile(object sender, IImporter importer)
        {
            this.importer = importer;

                // Load
                //var data = importer.LoadAll();

                // Populate Columns
                dataGridDisplay.Columns.Clear();
                var column = new DataGridTextColumn();
                column.Header = "HEADER!";
                dataGridDisplay.Columns.Add(column);

                // Populate with data

        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
