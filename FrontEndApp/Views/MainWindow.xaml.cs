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
using FrontEndApp.Commands;
using FrontEndApp.ViewModels;

namespace FrontEndApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        MainWindowViewModel vm;
        public MainWindow()
        {
            vm = new MainWindowViewModel();
            DataContext = vm;
            vm.CloseWindow = new AlwaysExecutableCommand( this.Close );
            vm.ViewGenerateColumns = GenerateColumns;

            InitializeComponent();
        }

        // Unfortunately this method is necessary in code, meaning no ZERO code-behind in this class
        internal void GenerateColumns(DataObjectMetadataViewModel[] metadataArray)
        {
            dataGridDisplay.Columns.Clear();
            for (int i = 0; i < metadataArray.Length; i++)
            {
                DataGridTextColumn column = new DataGridTextColumn();
                column.Binding = new Binding(String.Format("Columns[{0}]", i));
                column.Header = metadataArray[i].ColumnName;
                dataGridDisplay.Columns.Add(column);
            }
        }
    }
}
