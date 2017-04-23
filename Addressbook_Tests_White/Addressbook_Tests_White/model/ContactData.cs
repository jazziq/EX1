using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Addressbook_Tests_White
{
    public class ContactData : IComparable<ContactData>, IEquatable<ContactData>
    {
        public string LastName { get; set; }
        public string FirstName { get; set; }

        public ContactData()
        {
        }

        public ContactData(string lastname, string firstname)
        {
            LastName = lastname;
            FirstName = firstname;
        }

        public int CompareTo(ContactData other)
        {
            if (Object.ReferenceEquals(other, null))
            {
                return 1;
            }

            int a = LastName.CompareTo(other.LastName);

            if (a == 0)
            {
                return FirstName.CompareTo(other.FirstName);
            }
            else
                return a;
        }

        public bool Equals(ContactData other)
        {
            return this.LastName.Equals(other.LastName);
        }


    }
}
