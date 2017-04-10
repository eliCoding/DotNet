using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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

namespace RegisterPeopleEli
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<String> petList = new List<string>();
        public MainWindow()
        {
            InitializeComponent();
        }

        private void NumberValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]$");
            e.Handled = regex.IsMatch(e.Text);
        }
        private void btnRegisterperson_Click(object sender, RoutedEventArgs e)
        {
            Regex regex = new Regex("[^A-Za-z]$");
            if (tbName.Text.Length < 2 || tbName.Text.Length > 50)
            {

                MessageBoxResult result = MessageBox.Show("Name length must be between 2 to 50", "Name Error",MessageBoxButton.OK, MessageBoxImage.Error);
                return;


            }
            string personInfo = "";
            personInfo = tbName.Text + ";";
            personInfo += tbAge.Text + ";";

            //radio button
            if (rbgenderFemale.IsChecked == true) { personInfo += rbgenderFemale.Content+";"; }
            if (rbgenderMale.IsChecked == true) { personInfo += rbgenderMale.Content + ";"; }
            if (rbgenderNA.IsChecked == true) { personInfo += rbgenderNA.Content + ";"; }

            //check box

            if (cbPetsCats.IsChecked == true) {petList.Add(cbPetsCats.Content.ToString() +";"); }
            if (cbPetsDogs.IsChecked == true) { petList.Add(cbPetsDogs.Content.ToString() + ";"); }
            if (cbPetsOthers.IsChecked == true) { petList.Add(cbPetsOthers.Content.ToString() + ";"); }

            foreach (string s in petList)
            {

                personInfo += s + ",";
            }
            personInfo = personInfo.TrimEnd(',');
            
            // Combo  Contonents
            personInfo += comboContinents.Text;

            try
            {
                string path = @"..\..\People.txt";
                if (!File.Exists(path))
                {
                    // Create a file to write to.
                    using (StreamWriter sw = File.CreateText(path))
                    {
                        // This text is added only once to the file.
                        sw.Write(personInfo + "\r\n");
                        sw.Close();
                    }
                }

                // This text is always added, making the file longer over time
                // if it is not deleted.
                using (StreamWriter sw = File.AppendText(path))
                {
                    sw.Write(personInfo + "\r\n");
                    sw.Close();
                }
                // Referesh the window after add a person to the file
                tbName.Clear();
                tbAge.Clear();
                rbgenderNA.IsChecked = true;
                cbPetsCats.IsChecked = false;
                cbPetsDogs.IsChecked = false;
                cbPetsOthers.IsChecked = false;
                comboContinents.SelectedIndex = 0;
            }
            catch (IOException er)
            {
                MessageBoxResult result = MessageBox.Show("There is an Error in Opening or Finding the File!", "Confirmation", MessageBoxButton.OK, MessageBoxImage.Question);
                if (result == MessageBoxResult.OK)
                {
                    return;
                }
            }
          
            
              

             /*    SaveFileDialog saveFileDialog = new SaveFileDialog();
                 if (saveFileDialog.ShowDialog() == true)
                 File.WriteAllText(saveFileDialog.FileName, personInfo);*/
                 
        }

      

       

       
    }
}
