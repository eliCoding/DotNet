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

namespace PeopleBindingEli
{

    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>


    public partial class MainWindow : Window
    {
        List<Person> person = new List<Person>();
        public MainWindow()
        {

            InitializeComponent();
            person.Add(new Person("John Doe", 42));
            person.Add(new Person("Jane Doe", 39));
            person.Add(new Person("Sammy Doe", 7));
            LvPersons.ItemsSource = person;

        }


        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            int index;
            if (!Int32.TryParse(LvPersons.SelectedIndex.ToString(), out  index) || index == -1)
            {
                MessageBox.Show("object does not exist, out of range " + index);
            }
            else
            {
                Person p = person[index];
                p.Name1 = tbName.Text;
                int age;
                if (Int32.TryParse(tbAge.Text, out age))
                {
                    p.Age1 = age;
                }
                else
                {
                    MessageBox.Show("Please enter digits for age.");
                    return;
                }
                // aading new person p to the list and the end of the list always - when you add to the list you add at the end of the list
                person.Add(p);
                //remove the person at the index #index
                person.RemoveAt(index);
                //sort the list by the ID
                person.Sort(delegate(Person x, Person y)
                {
                    if (x.ID1 == null && y.ID1 == null) return 0;
                    else if (x.ID1 == null) return -1;
                    else if (y.ID1 == null) return 1;
                    else return x.ID1.CompareTo(y.ID1);
                });

                //refresh the list of items on display
                LvPersons.ItemsSource = null;
                LvPersons.ItemsSource = person;
                // MessageBox.Show("Oject was updated at the " + index);
            }


        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {


            //instantiate the object
            Person p = new Person(tbName.Text, Convert.ToInt32(tbAge.Text));
            int age;
            if (!int.TryParse(tbAge.Text, out age))
            {
                MessageBox.Show("Age must be an integer");
                return;
            } try
            {
                //add the object to the list
                person.Add(p);
                //refresh the list of items on display
                LvPersons.Items.Refresh();

                //or refresh this way
                /* LvPersons.ItemsSource = null;
                 LvPersons.ItemsSource = person;*/

                //clear the field of textboxes
                tbAge.Clear();
                tbName.Clear();
            }
            catch (ArgumentException ex)
            {
                MessageBox.Show(ex.StackTrace);
            }




        }

        private void LvPersons_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {

            lblIDValue.Content = person.ElementAt(LvPersons.SelectedIndex).ID1.ToString();
            tbName.Text = person.ElementAt(LvPersons.SelectedIndex).Name1;
            tbAge.Text = person.ElementAt(LvPersons.SelectedIndex).Age1.ToString();

        }

        private void LvPersons_MouseRightButtonUp(object sender, MouseButtonEventArgs e)
        {

        }

        private void MenuItemDelete_Click(object sender, RoutedEventArgs e)
        {

            var result = MessageBox.Show("Are u sure you want to delete the entry?", "Deleting Entry?", MessageBoxButton.OKCancel,
             MessageBoxImage.Question);
            if (result.ToString() == "OK")
            {
                int index;
                if (Int32.TryParse(LvPersons.SelectedIndex.ToString(), out  index))
                {

                    person.RemoveAt(index);
                    //refresh the list of items on display
                    LvPersons.Items.Refresh();


                /*  LvPersons.ItemsSource = null;
                    LvPersons.ItemsSource = person;*/

                    //clear the field of the text boxes after the item is deleted
                    //tbID.Text = "";
                    tbAge.Text = "";
                    tbName.Text = "";

                }




            }
        }





    }
}
