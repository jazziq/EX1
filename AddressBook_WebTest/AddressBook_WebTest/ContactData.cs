using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAddressBookTests
{
    class ContactData
    {
        //Персональные данные
        private string firstname = ""; 
        private string middlename = "";
        private string lastname = "";
        private string nickname = "0";

        //Дата рождения
        private string bday = "1";
        private string bmonth = "January";
        private string byear = "1899";
        //Годовщина
        private string aday = "1";
        private string amonth = "January";
        private string ayear = "1899";

        //Сведения о работе
        private string title = "0";
        private string company = "0";
        private string address = "0";

        //Контактные данные
        private string home = "0";
        private string mobile = "0";
        private string work = "0";
        private string fax = "0";
        private string email = "0";
        private string email2 = "0";
        private string email3 = "0";
        private string homepage = "0";

        //Дополнительные данные
        private string address2 = "0";
        private string phone2 = "0";
        private string notes = "0";


        public string FirstName
        {
            get
            {
                return firstname;
            }

            set
            {
                firstname = value;
            }
        }

        public string MiddleName
        {
            get
            {
                return middlename;
            }

            set
            {
                middlename = value;
            }
        }

        public string LastName
        {
            get
            {
                return lastname;
            }

            set
            {
                lastname = value;
            }
        }

        public string NickName
        {
            get
            {
                return nickname;
            }

            set
            {
                nickname = value;
            }
        }


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

        public string Title
        {
            get
            {
                return title;
            }

            set
            {
                title = value;
            }
        }

        public string Company
        {
            get
            {
                return company;
            }

            set
            {
                company = value;
            }
        }

        public string Address
        {
            get
            {
                return address;
            }

            set
            {
                address = value;
            }
        }

        public string Home
        {
            get
            {
                return home;
            }

            set
            {
                home = value;
            }
        }

        public string Mobile
        {
            get
            {
                return mobile;
            }

            set
            {
                mobile = value;
            }
        }

        public string Work
        {
            get
            {
                return work;
            }

            set
            {
                work = value;
            }
        }

        public string Fax
        {
            get
            {
                return fax;
            }

            set
            {
                fax = value;
            }
        }

        public string Email
        {
            get
            {
                return email;
            }

            set
            {
                email = value;
            }
        }

        public string Email2
        {
            get
            {
                return email2;
            }

            set
            {
                email2 = value;
            }
        }

        public string Email3
        {
            get
            {
                return email3;
            }

            set
            {
                email3 = value;
            }
        }

        public string Homepage
        {
            get
            {
                return homepage;
            }

            set
            {
                homepage = value;
            }
        }

        public string Address2
        {
            get
            {
                return address2;
            }

            set
            {
                address2 = value;
            }
        }

        public string Phone2
        {
            get
            {
                return phone2;
            }

            set
            {
                phone2 = value;
            }
        }

        public string Notes
        {
            get
            {
                return notes;
            }

            set
            {
                notes = value;
            }
        }


    }
}
