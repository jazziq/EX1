using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAddressBookTests
{
    class GroupData
    {
        //Имя группы
        private string name = "";
        //Заголовок группы
        private string header = "";
        //Футер группы
        private string footer = "";

        public string Name
        //Имя группы
        {
            get
            {
                return name;
            }

            set
            {
                name = value;
            }
        }

        public string Header
        //Заголовок группы
        {
            get
            {
                return header;
            }

            set
            {
                header = value;
            }
        }

        public string Footer
        //Футер группы
        {
            get
            {
                return footer;
            }

            set
            {
                footer = value;
            }
        }


    }
}
