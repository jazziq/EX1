using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoItX3Lib;

namespace AddressBook_Tests_AutoIt
{
    public class ApplicationManager
    {
        public static string WINTITLE = "Free Address Book";

        private AutoItX3 aux;
        private GroupHelper groupHelper;
        

        public ApplicationManager()
        {
            aux = new AutoItX3();
            //aux.Run(@"C:\DevLAB\EDUC\FreeAddressBookPortable\AddressBook.exe", "", aux.SW_SHOW);
            aux.Run(@"E:\DevLab\Test\FreeAddressBookPortable\AddressBook.exe", "", aux.SW_MAXIMIZE); //SW_SHOW

            aux.WinWait(WINTITLE);
            //aux.WinWait("[CLASS:WindowsForms10.Window.8.app.0.2c908d5]");
            aux.WinActivate(WINTITLE);
            //aux.WinActivate("[CLASS:WindowsForms10.Window.8.app.0.2c908d5]"); 
            //aux.WinActivate("[CLASS:tSkMainForm]");
            aux.WinWaitActive(WINTITLE);
            

            groupHelper = new GroupHelper(this);
        }

        public void Stop()
        {
            aux.ControlClick(WINTITLE, "", "WindowsForms10.BUTTON.app.0.2c908d510");
        }

        public AutoItX3 Aux
        {
            get
            {
                return aux;
            }
        }

        public GroupHelper Groups
        {
            get { return groupHelper; }            
        }
    }
}
