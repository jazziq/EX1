using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using TestStack.White;
using TestStack.White.InputDevices;
using TestStack.White.UIItems;
using TestStack.White.UIItems.TableItems;
using TestStack.White.UIItems.Actions;
using TestStack.White.WindowsAPI;
using TestStack.White.UIItems.Finders;
using TestStack.White.UIItems.TreeItems;
using TestStack.White.UIItems.WindowItems;
using System.Windows.Automation;

namespace Addressbook_Tests_White
{
    public class ContactHelper : HelperBase
    {
        public static string CONTACTEDITOR = "Contact Editor";
        public static string DELETECONTACT = "Question";


        public ContactHelper(ApplicationManager manager) : base(manager) { }

        public List<ContactData> GetContactList()
        {
            
            List<ContactData> list = new List<ContactData>();

            Table tContacts = manager.mainWND.Get<Table>(SearchCriteria.ByAutomationId("uxAddressGrid"));
            if (tContacts.Rows.Count != 0)
            {
                tContacts.Rows.First();
                foreach (TableRow record in tContacts.Rows)
                {
                    list.Add(new ContactData()
                    {
                        FirstName = record.Cells[0].Value.ToString(),
                        LastName = record.Cells[1].Value.ToString()
                    });
                }
            }

            return list;
        }

        public void Add(ContactData newContact)
        {
            Window frmContactEditor = OpenContactEditor();
            TextBox edtLastName = (TextBox)frmContactEditor.Get(SearchCriteria.ByAutomationId("ueLastNameAddressTextBox"));
            edtLastName.Enter(newContact.LastName);
            TextBox edtFirstName = (TextBox)frmContactEditor.Get(SearchCriteria.ByAutomationId("ueFirstNameAddressTextBox"));
            edtFirstName.Enter(newContact.FirstName);
            CloseContactEditor(frmContactEditor);
        }

        public void Remove()
        {
            Table tContacts = manager.mainWND.Get<Table>(SearchCriteria.ByAutomationId("uxAddressGrid"));
            tContacts.Rows[tContacts.Rows.Count - 1].Click();
            manager.mainWND.Get<Button>("uxDeleteAddressButton").Click();
            Window dlgQuestion = manager.mainWND.ModalWindow(DELETECONTACT);
            dlgQuestion.Get<Button>(SearchCriteria.ByText("Yes")).Click();
        }

        public Window OpenContactEditor()
        {
            manager.mainWND.Get<Button>("uxNewAddressButton").Click();
            return manager.mainWND.ModalWindow(CONTACTEDITOR);
        }

        public void CloseContactEditor(Window frmContactEditor)
        {
            frmContactEditor.Get<Button>("uxSaveAddressButton").Click();
        }


    }
}