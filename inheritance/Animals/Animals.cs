using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Animals
{
    public class Animal
    {
        public Animal(string name, int age, string gender)
        {
            this.Name = name;
            this.Age = age;
            this.Gender = gender;
        }

        public string Name 
        {
            get
            {
                return this.Name;
            }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Invalid input!");
                }
            }
        }

        public int Age 
        {
            get
            {
                return this.Age;
            }
            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Invalid input!");
                }
            }
        }

        public string Gender 
        {
            get
            {
                return this.Gender;
            }
            private set
            {
                if (value != "Male" && value != "Female")
                {
                    throw new ArgumentException("Invalid input!");
                }
            }
        }

        public virtual string ProduceSound()
        {
            return GetType().Name + ": ";
        }

        public override string ToString()
        {
            return this.Name + ' ' +  this.Age + ' ' + this.Gender;
        }
    }
}
