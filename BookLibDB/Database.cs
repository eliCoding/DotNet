using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookLibDB
{
    class Database
    {
        SqlConnection conn;

        public Database()
        {
            conn = new SqlConnection(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=I:\Elmira\Winter Semester\DotNet\C#\BookLibDB\BooksDb.mdf;Integrated Security=True;Connect Timeout=30");
            conn.Open();
        }
        public void AddBooks(Book b)
        {

            string sql = "INSERT INTO books (GenreId, Author,Title,Price,PublishDate,Description) VALUES (@GenreId, @Author,@Title,@Price,@PublishDate,@Description)";
            SqlCommand cmd = new SqlCommand(sql, conn);
            cmd.Parameters.Add("@GenreId", SqlDbType.Int).Value = b.GenreId;
            cmd.Parameters.Add("@Author", SqlDbType.NVarChar).Value = b.Author;
            cmd.Parameters.Add("@Title", SqlDbType.NVarChar).Value = b.Title;
            cmd.Parameters.Add("@Price", SqlDbType.Decimal).Value = b.Price;
            cmd.Parameters.Add("@PublishDate", SqlDbType.DateTime).Value = b.PublishDate;
            cmd.Parameters.Add("@Description", SqlDbType.NVarChar).Value = b.Description;

            cmd.CommandType = CommandType.Text;
            cmd.ExecuteNonQuery();
        }
        public List<Book> GetAllBooks()
        {
            List<Book> result = new List<Book>();
            using (SqlCommand command = new SqlCommand("SELECT * FROM books", conn))
            using (SqlDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    int id = (int)reader["Id"];
                    int genreId = (int)reader["GenreId"];
                    string author = (string)reader["Author"];
                    string title = (string)reader["Title"];
                    decimal price = (decimal)reader["Price"];
                    DateTime publishDate = (DateTime)reader["PublishDate"];
                    string description = (string)reader["Description"];

                    Book b = new Book(id, author, title, genreId, price, publishDate, description);
                    result.Add(b);
                }
            }
            return result;
        }

        public List<Genre> GetAllGenres()
        {
            List<Genre> result = new List<Genre>();
            using (SqlCommand command = new SqlCommand("SELECT * FROM Genres", conn))
            using (SqlDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    int id = (int)reader["Id"];

                    string name = (string)reader["Name"];

                    Genre g = new Genre(id, name);
                    result.Add(g);
                }
            }
            return result;
        }
        public int GetGenreId(string name)
        {
            int result = 0;
            using (SqlCommand command = new SqlCommand("SELECT * FROM Genres", conn))
            using (SqlDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    if ((string)reader["name"] == name)
                    {
                        result = (int)reader["Id"];
                    }
                }
            }
            return result;

        }
        public void DeleteBookById(int id)
        {
            string sql = "DELETE FROM books WHERE Id=@Id";
            SqlCommand cmd = new SqlCommand(sql, conn);
            cmd.Parameters.Add("@Id", SqlDbType.Int).Value = id;
            cmd.CommandType = CommandType.Text;
            cmd.ExecuteNonQuery();
        }
      
        public void UpdateBooks(Book b)
        {
            string sql = "UPDATE books SET GenreId = @GenreId, Author = @Author,Title= @Title,Price =@Price ,PublishDate=@PublishDate,Description=@Description  WHERE Id=@Id";
            SqlCommand cmd = new SqlCommand(sql, conn);
            cmd.Parameters.Add("@Id", SqlDbType.Int).Value = b.Id;
            cmd.Parameters.Add("@GenreId", SqlDbType.Int).Value = b.GenreId;
            cmd.Parameters.Add("@Author", SqlDbType.NVarChar).Value = b.Author;
            cmd.Parameters.Add("@Title", SqlDbType.NVarChar).Value = b.Title;
            cmd.Parameters.Add("@Price",SqlDbType.Money).Value = b.Price;
            cmd.Parameters.Add("@PublishDate", SqlDbType.Date).Value = b.PublishDate;
            cmd.Parameters.Add("@Description", SqlDbType.NVarChar).Value = b.Description;
            cmd.CommandType = CommandType.Text;
            cmd.ExecuteNonQuery();
        }

    }
}
