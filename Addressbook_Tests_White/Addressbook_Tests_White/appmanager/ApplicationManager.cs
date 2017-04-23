using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestStack.White;
using TestStack.White.UIItems;
using TestStack.White.UIItems.WindowItems;

namespace Addressbook_Tests_White
{
    public class ApplicationManager
    {
        public Window mainWND { get; private set; }
        public static string WINTITLE = "Free Address Book";

        private GroupHelper groupHelper;
        private ContactHelper contactHelper;


        public ApplicationManager()
        {
            //Application app = Application.Launch(@"C:\DevLAB\EDUC\FreeAddressBookPortable\AddressBook.exe");
            Application app = Application.Launch(@"E:\DevLab\Test\FreeAddressBookPortable\AddressBook.exe");

            mainWND = app.GetWindow(WINTITLE);
            groupHelper = new GroupHelper(this);
            contactHelper = new ContactHelper(this);
        }

        public void Stop()
        {
            mainWND.Get<Button>("uxExitAddressButton").Click();            
        }

        public GroupHelper Groups
        {
            get { return groupHelper; }            
        }

        public ContactHelper Contacts
        {
            get { return contactHelper; }
        }

    }
}
