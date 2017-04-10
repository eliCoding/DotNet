using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
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

namespace MiniNotePadEli
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private bool unsavedChanges = false;


        public MainWindow()
        {
            InitializeComponent();
        }

        // questions : save file, full path of current file, window title is modified, close window Event Handler

        private void miOpen_Click(object sender, RoutedEventArgs e)
        {

            try
            {
                OpenFileDialog openFileDialog = new OpenFileDialog();
                // add specific filter to the file like .txt
                openFileDialog.Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*";
                if (openFileDialog.ShowDialog() == true)
                    txtEditor.Text = File.ReadAllText(openFileDialog.FileName);

                //have the path of the file in the status bar                         
                lblTextPath.Text = openFileDialog.FileName.ToString();
            }
            catch (IOException ex)
            {
                Console.WriteLine(ex.StackTrace);
                MessageBox.Show(this, "Eror reading file" + ex.Message);
            }

        }


        private void miSave_Click(object sender, RoutedEventArgs e)
        {


        }

        private void miSaveAs_Click(object sender, RoutedEventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            // save as a txt file like .txt
            saveFileDialog.Filter = "Text file (*.txt)|*.txt | All files(*.)|*.*";
            if (saveFileDialog.ShowDialog() == true)
                File.WriteAllText(saveFileDialog.FileName, txtEditor.Text);
        }


        private void miExit_Click(object sender, RoutedEventArgs e)
        {


            if (unsavedChanges)
            {

                MessageBoxResult result = MessageBox.Show("Would you like to save changes before closing \"Note Pad\"?", "My Notw Pad", MessageBoxButton.YesNoCancel);
                switch (result)
                {
                    case MessageBoxResult.Yes:
                        SaveFileDialog saveFileDialog = new SaveFileDialog();
                        // save as a txt file like .txt
                        saveFileDialog.Filter = "Text file (*.txt)|*.txt | All files(*.)|*.*";
                        if (saveFileDialog.ShowDialog() == true)
                            File.WriteAllText(saveFileDialog.FileName, txtEditor.Text);

                        break;
                    case MessageBoxResult.No:
                        Application.Current.Shutdown();

                        break;
                    case MessageBoxResult.Cancel:
                        // e.Cancel
                        break;
                }

            }
        }


        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (unsavedChanges)
            {

                MessageBoxResult result = MessageBox.Show("Would you like to save changes before closing \"Note Pad\"?", "My Notw Pad", MessageBoxButton.YesNoCancel);
                switch (result)
                {
                    case MessageBoxResult.Yes:
                        SaveFileDialog saveFileDialog = new SaveFileDialog();
                        // save as a txt file like .txt
                        saveFileDialog.Filter = "Text file (*.txt)|*.txt | All files(*.)|*.*";
                        if (saveFileDialog.ShowDialog() == true)
                            File.WriteAllText(saveFileDialog.FileName, txtEditor.Text);

                        break;
                    case MessageBoxResult.No:
                        Application.Current.Shutdown();

                        break;
                    case MessageBoxResult.Cancel:
                        // e.Cancel
                        break;
                }

            }
        }
    }
}
