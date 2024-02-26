using System;
using System.Collections.Generic;
using System.Data.Odbc;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace finalu
{
    public class Book
    {
        public string Title { get; set; }
        public string Author { get; set; }
        public string ReleaseDate { get; set; }

        public Book(string title, string author, string releaseDate)
        {
            Title = title;
            Author = author;
            ReleaseDate = releaseDate;
        }
        //konstruqtori
        public override string ToString()
        {
            return $"Title: {Title}\nAuthor: {Author}\nPublication Year: {ReleaseDate}";
        }
    }

    public class bookManager
    {
        private List<Book> books = new List<Book>();

        public void AddBook(string title, string author, string releaseDate)//wignis damateba
        {
            Book newBook = new Book(title, author, releaseDate);
            books.Add(newBook);
        }
        public void ShowBooks()//wignis siis chveneba
        {
            Console.WriteLine("Book List");//wignebis chamonatvalis chveneba
            foreach (Book book in books)
            {
                Console.WriteLine(book);
            }
        }
        public Book SearchByBook(string title)//dzieba
        {
            foreach (var book in books)
            {
                if (book.Title == title)//tu saxeli sheefereba vprintavt saxels
                {
                    return book;
                }
            }
            return null;
        }
    }
}
