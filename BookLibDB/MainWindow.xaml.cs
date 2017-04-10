using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
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
using System.Xml;
using System.Xml.XPath;

namespace BookLibDB
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<Book> bookList = new List<Book>();
        Database db;
        private string openFilePath = null;
        public MainWindow()
        {
            try
            {
                db = new Database();


            }
            catch (SqlException e)
            {
                Console.WriteLine(e.StackTrace);
                MessageBox.Show("Error opening database connection: " + e.Message);
                Environment.Exit(1);
            }
            InitializeComponent();
            refreshBookList();
            refreshGenreList();


        }
        private void refreshBookList()
        {
            LvBooks.ItemsSource = db.GetAllBooks();
        }
        private void refreshGenreList()
        {
            ComboGenre.ItemsSource = db.GetAllGenres();
        }

        private void ButtonAdd_Click(object sender, RoutedEventArgs e)
        {

            //instantiate the object
            int genreId = ComboGenre.SelectedIndex + 1;
            try
            {
                Book b = new Book(0, TbAuthor.Text, TbTitle.Text, genreId, decimal.Parse(TbPrice.Text), DateTime.Parse(TbPubDate.Text), TbDescription.Text);
                db.AddBooks(b);
            }
            catch (ArgumentException ex)
            {
                MessageBox.Show("the values are out of range" + ex.StackTrace);
            }
            catch (FormatException ex)
            {
                MessageBox.Show("not A valid Format" + ex.StackTrace);
            }

            refreshBookList();
            LvBooks.Items.Refresh();



            //clear the field of textboxes
            TbAuthor.Clear();
            TbTitle.Clear();
            ComboGenre.SelectedValue = false;
            TbPubDate.Clear();
            TbDescription.Clear();
            TbPrice.Clear();
        }

        private void ButtonDelete_Click(object sender, RoutedEventArgs e)
        {
            int index = LvBooks.SelectedIndex;
            if (index < 0)
            {
                return;
            }
            Book b = (Book)LvBooks.Items[index];
            try
            {
                db.DeleteBookById(b.Id);
                refreshBookList();
            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex.StackTrace);
                MessageBox.Show("Database query error " + ex.Message);
            }
        }

        private void LvBooks_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            List<Genre> genreList = db.GetAllGenres();
             Book b = (Book)LvBooks.SelectedItem;
            foreach (Genre g in genreList)
            {
                if (g.Id == b.GenreId)
                {
                    ComboGenre.SelectedValue = g.Name;
                }
            }
            int index = LvBooks.SelectedIndex;
            if (index < 0)
            {
                return;
            }
           
            TbAuthor.Text = b.Author;
            TbTitle.Text = b.Title;
          
            TbPrice.Text = b.Price.ToString();
            TbPubDate.Text = b.PublishDate.ToString();
            TbDescription.Text =b.Description;




        }

        private void ButtonUpdate_Click(object sender, RoutedEventArgs e)
        {
            int index = LvBooks.SelectedIndex;
            if (index < 0)
            {
                return;
            }
            Book b = (Book)LvBooks.Items[index];
            try
            {
                b.Author = TbAuthor.Text;
                b.Title = TbTitle.Text;
                b.GenreId = ComboGenre.SelectedIndex + 1;
                b.Price = decimal.Parse(TbPrice.Text);
                b.PublishDate = DateTime.Parse(TbPubDate.Text);
                b.Description = TbDescription.Text;
 

             
                db.UpdateBooks(b);
                refreshBookList();
            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex.StackTrace);
                MessageBox.Show("Database query error " + ex.Message);
            }

        }
      

         private void TbFilter_TextChanged(object sender, TextChangedEventArgs e)
         {
             string filter = TbFilter.Text.ToLower();
             if (filter == "")
             {
                 LvBooks.ItemsSource = db.GetAllBooks();
             }
             else
             {
                 List<Book> list = db.GetAllBooks();
                 /* var filteredList = list.Where(b => b.Title.ToLower().Contains(filter)
                                                    || b.Author.ToLower().Contains(filter)); */
                 var filteredList = from b in list
                                    where b.Title.ToLower().Contains(filter) || b.Author.ToLower().Contains(filter)
                                    select b;

                 LvBooks.ItemsSource = filteredList;
             }
         }

         private void MenuItemExit_Click(object sender, RoutedEventArgs e)
         {
             Close();
         }

         private void MenuItemImportXml_Click(object sender, RoutedEventArgs e)
         {
             try
             {
                 OpenFileDialog openFileDialog = new OpenFileDialog();
                 openFileDialog.Filter = "XML files (*.XML)|*.xml|All files (*.*)|*.*";
                 if (openFileDialog.ShowDialog() == true)
                 {
                     
                     XmlDocument xmlDoc = new XmlDocument();
                     xmlDoc.Load(openFileDialog.FileName);

                     try
                     {
                         XmlNodeList dataFile = xmlDoc.SelectNodes("/catalog/book");

                         foreach (XmlNode node in dataFile)
                         {
                             //int author = Convert.ToInt32(node.SelectSingleNode("author").InnerText);
                             string author = node.SelectSingleNode("author").InnerText;
                             string title = node.SelectSingleNode("title").InnerText;
                             string genre = node.SelectSingleNode("genre").InnerText;
                             decimal price = Convert.ToDecimal(node.SelectSingleNode("price").InnerText);
                             DateTime publish_date = Convert.ToDateTime(node.SelectSingleNode("publish_date").InnerText);
                             string description = node.SelectSingleNode("description").InnerText;

                             int genreid = db.GetGenreId(genre);
                             Book b = new Book(0, author, title, genreid, price, publish_date, description);
                          //   Book b = new Book(0, TbAuthor.Text, TbTitle.Text, genreId, decimal.Parse(TbPrice.Text), DateTime.Parse(TbPubDate.Text), TbDescription.Text);

                             db.AddBooks(b);
                         }
                     }
                     catch (XPathException ex)
                     {
                         MessageBox.Show("Read XML Error " + ex.StackTrace);
                     }
                 }
             }
             catch (IOException ex)
             {
                 Console.WriteLine(ex.StackTrace);
                 MessageBox.Show(this, "Error reading file " + ex.Message);
             }

         }
    }
}
