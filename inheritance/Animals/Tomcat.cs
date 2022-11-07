using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Animals
{
    public class Tomcat : Cat
    {
        private const string catGender = "Male";

        public Tomcat(string name, int age, string gender)
            :base(name, age, catGender)
        {

        }


        public override string ProduceSound()
        {
            return base.ProduceSound() + "MEOW";
        }
    }
}
