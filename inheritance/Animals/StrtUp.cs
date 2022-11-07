using System;
using System.Collections.Generic;

namespace Animals
{
    class StrtUp
    {
        static void Main(string[] args)
        {
            List<Animal> animals = new List<Animal>();
            //Animal animal;
            

            while(true)
            {
                string firstLine = Console.ReadLine();
                if (firstLine == "Beast!")
                {
                    Print(animals);
                    break;
                }

                string[] input = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
                string name = input[0];
                int age = int.Parse(input[1]);
                string gender = input[2];

                switch (firstLine)
                {
                    case "Dog":
                        animals.Add(new Dog(name, age, gender));
                        break;
                    case "Cat":
                        animals.Add(new Cat(name, age, gender));
                        break;
                    case "Frog":
                        animals.Add(new Frog(name, age, gender));
                        break;
                    case "Kitten":
                        animals.Add(new Kitten(name, age, gender));
                        break;
                    case "Tomcat":
                        animals.Add(new Tomcat(name, age, gender));
                        break;
                }
            }
            
        }
        private static void Print(List<Animal> animals)
        {
            foreach (var animal in animals)
            {
                Console.WriteLine(animal.GetType().Name);
                Console.WriteLine(animal.ToString());
                Console.WriteLine(animal.ProduceSound());
            }
        }
    }
}
