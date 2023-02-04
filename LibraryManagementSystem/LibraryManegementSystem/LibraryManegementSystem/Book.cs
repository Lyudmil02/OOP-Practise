using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManegementSystem
{
    public class Book
    {
        private int isbn;

        public string Title { get; set; }

        public int ISBN 
        {
            get
            {
                return isbn;
            }
            set
            {
                if (value > 0)
                {
                    isbn = value;
                }
                else
                {
                    throw new ArgumentException("Invalid ISBN Number");
                }
            }
        }

        public string Author { get; set; }

        public DateTime DueDate { get; set; }

        public bool IsCheckedOut { get; set; }

        public Book(string title, int isbn, string author, DateTime dateTime)
        {
            Title = title;
            ISBN = isbn;
            Author = author;
            DueDate = dateTime;

        }

        public void CheckedOut()
        {
            if (!IsCheckedOut)
            {
                IsCheckedOut = true;
                Console.WriteLine("Book check out successfully!");
            }
            else
            {
                Console.WriteLine("Book is already checked out.");
            }
        }
    }
}
