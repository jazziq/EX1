using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using LinqToDB.Mapping;

namespace WebAddressBookTests
{
    [Table(Name = "addressbook")]

    public class ContactData : IEquatable<ContactData>, IComparable<ContactData>
    {     
        //Дата рождения
        private string bday = "1";
        private string bmonth = "January";
        private string byear = "1899";
        //Годовщина
        private string aday = "1";
        private string amonth = "January";
        private string ayear = "1899";
        private string allPhones;
        private string allEmails;

        public ContactData()
        {
        }

        public ContactData(string lastname, string firstname)
        {
            LastName = lastname;
            FirstName = firstname;
        }

        public bool Equals(ContactData other)
        {
            if (Object.ReferenceEquals(other, null))
            {
                return false;
            }

            if (Object.ReferenceEquals(this, other))
            {
                return true;
            }

            return
                (LastName == other.LastName) && 
                    (FirstName == other.FirstName);
        }

        public override int GetHashCode()
        {
            string fullName = LastName + FirstName;
            return fullName.GetHashCode();
        }

        public override string ToString()
        {
            return "lastname = " + LastName + " firstname = " + FirstName;
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

        [Column(Name = "lastname")]
        public string LastName { get; set; }

        [Column(Name = "firstname")]
        public string FirstName { get; set; }

        [Column(Name = "middlename")]
        public string MiddleName { get; set; }

        [Column(Name = "nickname")]
        public string NickName { get; set; }

        [Column(Name = "bday")]
        public string BDay
        {
            get
            {
                return bday;
            }

            set
            {
                bday = value;
            }
        }

        [Column(Name = "bmonth")]
        public string BMonth
        {
            get
            {
                return bmonth;
            }

            set
            {
                bmonth = value;
            }
        }

        [Column(Name = "byear")]
        public string BYear
        {
            get
            {
                return byear;
            }

            set
            {
                byear = value;
            }
        }

        [Column(Name = "aday")]
        public string ADay
        {
            get
            {
                return aday;
            }

            set
            {
                aday = value;
            }
        }

        [Column(Name = "amonth")]
        public string AMonth
        {
            get
            {
                return amonth;
            }

            set
            {
                amonth = value;
            }
        }

        [Column(Name = "ayear")]
        public string AYear
        {
            get
            {
                return ayear;
            }

            set
            {
                ayear = value;
            }
        }

        [Column(Name = "title")]
        public string Title { get; set; }

        [Column(Name = "company")]
        public string Company { get; set; }

        [Column(Name = "address")]
        public string Address { get; set; }

        [Column(Name = "home")]
        public string HomePhone { get; set; }

        [Column(Name = "mobile")]
        public string MobilePhone { get; set; }

        [Column(Name = "work")]
        public string WorkPhone { get; set; }

        public string AllPhones
        {
            get
            {
                if (allPhones != null)
                {
                    return allPhones; 
                }
                else
                {
                    return (FormatPhone(HomePhone) + FormatPhone(MobilePhone) + FormatPhone(WorkPhone)).Trim();
                }                
            }

            set
            {
                allPhones = value;
            }
        }

        private string FormatPhone(string phone)
        {
            if (phone == null || phone == "")
            {
                return "";
            }
            return Regex.Replace(phone, "[ \\-()]", "") + "\r\n";                
        }

        [Column(Name = "fax")]
        public string Fax { get; set; }

        [Column(Name = "email")]
        public string Email { get; set; }

        [Column(Name = "email2")]
        public string Email2 { get; set; }

        [Column(Name = "email3")]
        public string Email3 { get; set; }

        public string AllEmails
        {
            get
            {
                if (allEmails != null)
                {
                    return allEmails;
                }
                else
                {
                    return (FormatEmail(Email) + FormatEmail(Email2) + FormatEmail(Email3)).Trim();
                }
            }

            set
            {
                allEmails = value;
            }
        }

        private string FormatEmail(string email)
        {
            if (email == null || email == "")
            {
                return "";
            }
            return email + "\r\n";
        }

        [Column(Name = "homepage")]
        public string Homepage { get; set; }

        [Column(Name = "address2")]
        public string Address2 { get; set; }

        [Column(Name = "phone2")]
        public string Phone2 { get; set; }

        [Column(Name = "notes")]
        public string Notes { get; set; }

        [Column(Name = "id"), PrimaryKey, Identity]
        public string Id { get; set; }

        [Column(Name = "deprecated")]
        public string Deprecated { get; set; }

        public static List<ContactData> GetAll()
        {
            using (AddressBookDB db = new AddressBookDB())
            {
                return (from g in db.Contacts.Where(x => x.Deprecated == "0000-00-00 00:00:00") select g).ToList();
            }
        }

    }
}
