using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookLibDB
{
    class Book
    {

        string _Author;

        public string Author
        {
            get { return _Author; }
            set {
                if (value.Length < 2 || value.Length > 150)
                {

                    throw new ArgumentException();
                }
                _Author = value; }
        }
        string _Title;

        public string Title
        {
            get { return _Title; }
            set {
                if (value.Length < 2 || value.Length > 150)
                {

                    throw new ArgumentException();
                }
                _Title = value; }
        }
        int _GenreId;

        public int GenreId
        {
            get { return _GenreId; }
            set { _GenreId = value; }
        }

        decimal _Price;

        public decimal Price
        {
            get { return _Price; }
            set { _Price = value; }
        }
        DateTime _PublishDate;

        public DateTime PublishDate
        {
            get { return _PublishDate; }
            set { _PublishDate = value; }
        }
        string _Description;

        public string Description
        {
            get { return _Description; }
            set {
                if (value.Length < 2 || value.Length > 150)
                {

                    throw new ArgumentException();
                }
                
                _Description = value; }
        }
        int _Id;

        public int Id
        {
            get { return _Id; }
            set { _Id = value; }
        }

        public Book(int id ,string author, string title ,int genreId,decimal price, DateTime publishDate, string description)
        {
            Id = id;
            Author = author;
            Title = title;
            GenreId = genreId;
            Price = price;
            PublishDate = publishDate;
            Description = description;
        }

        public override string ToString()
        {
            return string.Format("{0}: {1}  {2} ", Id, Author, Title);
        }
    }
}
