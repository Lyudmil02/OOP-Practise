using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManegementSystem
{
    public class Library
    {
        private List<Book> checkOutBooks;

        public List<Book> Books { get; set; }

        public List<Member> Members { get; set; }

        public List<Author> Authors { get; set; }

        public Library()
        {
            Books = new List<Book>();
            Members = new List<Member>();
            checkOutBooks = new List<Book>();
            Authors = new List<Author>();
        }

        public void AddBook(string title, int isbn, string author, DateTime dateTime)
        {
            Book book = new Book(title, isbn, author, dateTime);
            Books.Add(book);
        }

        public void CheckOutBook(Member member, Book book)
        {
            if (!Books.Contains(book))
            {
                Console.WriteLine("Book not found in the library!");
                return;
            }
            if (!Members.Contains(member))
            {
                Console.WriteLine("Member not found in the library!");
                return;
            }
            checkOutBooks.Add(book);
            Books.Remove(book);
            Console.WriteLine($"{member.Name} has checked out {book.Title}");
        }

        public List<Book> GetCheckOutBooks()
        {
            return checkOutBooks;
        }

        public List<Book> GetOverdueBook()
        {
            List<Book> overdueBooks = new List<Book>();

            foreach (Book book in overdueBooks)
            {
                if (book.DueDate < DateTime.Now)
                {
                    overdueBooks.Add(book);
                }
            }

            return overdueBooks;
        }
    }
}
