using System;
using System.Collections.Generic;
using System.Data.SqlClient;
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

namespace LocalPeopleDBEli
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Database db;
       
        public MainWindow()
        {
            try
            {
                db = new Database();
            }
            catch (SqlException e)
            {
                Console.WriteLine(e.StackTrace);
                MessageBox.Show("Error openning database connection" + e.Message);
                Environment.Exit(1);
            }
            InitializeComponent();
            
            RefreshPeopleList();
        }
        public void RefreshPeopleList()
        {
            lbPeople.ItemsSource = db.GetAllPeople();

            
        }
        

        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string name = tbName.Text;
                int age = int.Parse(tbAge.Text);
                Person p = new Person(0, name, age);
                db.AddPerson(p);
                RefreshPeopleList();
            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex.StackTrace);
                MessageBox.Show("Error openning database connection" + ex.Message);
                Environment.Exit(1);
            }
        }
    }
}
