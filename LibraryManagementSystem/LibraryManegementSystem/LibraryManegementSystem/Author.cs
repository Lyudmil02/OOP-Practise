using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManegementSystem
{
    public class Author
    {
        public string Name { get; set; }

        public string Nationality { get; set; }

        public DateTime DateOfBirth { get; set; }

        public Author(string name, string nationality, DateTime dateOfBirth)
        {
            Name = name;
            Nationality = nationality;
            DateOfBirth = dateOfBirth;
        }
    }
}
