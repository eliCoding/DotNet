using System;
using System.Collections;
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

namespace DataBindingTutorialEli
{

    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            // Get data from somewhere and fill in my local ArrayList
            myDataList = LoadListBoxData();
            // Bind ArrayList with the ListBox
            LeftListBox.ItemsSource = myDataList;

        }
        ArrayList myDataList;
        string currentItemText;
        int currentItemIndex;

        private ArrayList LoadListBoxData()
        {
            ArrayList itemsList = new ArrayList();
            itemsList.Add("Coffe");
            itemsList.Add("Tea");
            itemsList.Add("Orange Juice");
            itemsList.Add("Milk");
            itemsList.Add("Mango Shake");
            itemsList.Add("Iced Tea");
            itemsList.Add("Soda");
            itemsList.Add("Water");
            return itemsList;
        }

        private void ApplyDataBinding()
        {
            LeftListBox.ItemsSource = null;
            // Bind ArrayList with the ListBox
            LeftListBox.ItemsSource = myDataList;
        }
        private void AddBtn_Click(object sender, RoutedEventArgs e)
        {
            // Find the right item and it's value and index
            currentItemText = LeftListBox.SelectedValue.ToString();
            currentItemIndex = LeftListBox.SelectedIndex;

            RightListBox.Items.Add(currentItemText);
            if (myDataList != null)
            {
                myDataList.RemoveAt(currentItemIndex);
            }

            // Refresh data binding
            ApplyDataBinding();
        }

        private void RemoveBtn_Click(object sender, RoutedEventArgs e)
        {
            // Find the right item and it's value and index
            currentItemText = RightListBox.SelectedValue.ToString();
            currentItemIndex = RightListBox.SelectedIndex;
            // Add RightListBox item to the ArrayList
            myDataList.Add(currentItemText);

            RightListBox.Items.RemoveAt(RightListBox.Items.IndexOf(RightListBox.SelectedItem));

            // Refresh data binding
            ApplyDataBinding();

        }
    }

}
