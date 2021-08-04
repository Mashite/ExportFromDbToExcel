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

namespace ExportFromDbToExcel
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        BikeStoresEntities context = new BikeStoresEntities();
        public MainWindow()
        {
            InitializeComponent();            

        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            //Get Tables name from entityframework
            List<string> tableNames = new List<string>();

            foreach (var propertyInfo in context.GetType().GetProperties())
            {
                tableNames.Add(propertyInfo.Name);
                lbxTables.Items.Add(propertyInfo.Name);
            }


        }

        private void btnExport_Click(object sender, RoutedEventArgs e)
        {
            string tblName = lbxTables.SelectedValue.ToString();

            List<string> results = context.Database.SqlQuery<string>("SELECT * FROM "+tblName).ToList();

         
            

        }
    }
}
