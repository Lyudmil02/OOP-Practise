using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManegementSystem
{
    public class Member
    {

        public string Name { get; set; }

        public string Address { get; set; }

        public string PhoneNumber { get; set; }

        public int MembershipID { get; set; }

        public Member(string name, string address, string phoneNumber, int membershipID)
        {
            Name = name;
            Address = address;
            PhoneNumber = phoneNumber;
            MembershipID = membershipID;
        }


    }
}
