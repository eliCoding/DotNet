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

namespace CustomSandwichEli
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


        private void ButtonMakeSandwich_Click(object sender, RoutedEventArgs e)
        {


            CustomDialog inputDialog = new CustomDialog();
            if (inputDialog.ShowDialog() == true)
            {
                //combo box
                LblBread.Content = inputDialog.comboBread.Text;

                //check box
                if (inputDialog.ckLetuce.IsChecked == true)
                {
                    LblVeggies.Content = inputDialog.ckLetuce.Content;
                }
                else if (inputDialog.ckTomato.IsChecked == true)
                {
                    LblVeggies.Content = inputDialog.ckTomato.Content;
                }
                else if (inputDialog.ckCucomber.IsChecked == true)
                {
                    LblVeggies.Content = inputDialog.ckCucomber.Content;
                }

                //radio button
                if (inputDialog.rbChicken.IsChecked == true)
                {
                    LblMeat.Content = inputDialog.rbChicken.Content;
                }
                else if (inputDialog.rbTufo.IsChecked == true)
                {
                    LblMeat.Content = inputDialog.rbTufo.Content;

                }
                else if (inputDialog.rbTurkey.IsChecked == true)
                {
                    LblMeat.Content = inputDialog.rbTurkey.Content;
                }

            }
           
            
        }
    }
}
