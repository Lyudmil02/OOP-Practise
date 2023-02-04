using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManegementSystem
{
    public class Librarians
    {
        private Library library;

        public Librarians(Library library)
        {
            this.library = library;
        }

        public void AddBook(string title, int isbn, string author, DateTime publicationDate)
        {
            Book book = new Book(title, isbn, author, publicationDate);
            library.Books.Add(book);
        }

        public void UpdateBook(Book book, string newTitle, int newIsbn, string newAuthor, DateTime newDueDate)
        {
            book.Title = newTitle;
            book.ISBN = newIsbn;
            book.Author = newAuthor;
            book.DueDate = newDueDate;
        }

        public void DeleteBook(Book book)
        {
            library.Books.Remove(book);
        }

        public void AddAuthor(string name, string nationality, DateTime dateOfBirth)
        {
            Author author = new Author(name, nationality, dateOfBirth);
            library.Authors.Add(author);
        }

        public void UpdateAuthor(Author author, string newName, string newNationality, DateTime newDateOfBirth)
        {
            author.Name = newName;
            author.Nationality = newNationality;
            author.DateOfBirth = newDateOfBirth;
        }

        public void DeleteAuthor(Author author)
        {
            library.Authors.Remove(author);
        }

        public void AddMember(string name, string address, string phoneNumber, int memId)
        {
            Member member = new Member(name, address, phoneNumber, memId);
            library.Members.Add(member);
        }

        public void UpdateMember(Member member, string newName, string newAddress, string newPhoneNumber, int newMemId)
        {
            member.Name = newName;
            member.Address = newAddress;
            member.PhoneNumber = newPhoneNumber;
            member.MembershipID = newMemId;
        }

        public void DeleteMember(Member member)
        {
            library.Members.Remove(member);
        }
    }
}
