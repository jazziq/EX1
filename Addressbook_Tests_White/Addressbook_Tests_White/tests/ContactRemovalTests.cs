using System;
using System.Text;
using System.Collections.Generic;
using NUnit.Framework;

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
    [TestFixture]
    public class ContactRemovalTests : TestBase
    {
        [Test]
        public void ContactRemovalTest()
        {
            List<ContactData> oldContacts = app.Contacts.GetContactList();

            if (oldContacts.Count == 0)
            {
                ContactData newContact = new ContactData()
                {
                    LastName = "Lastname " + (oldContacts.Count + 1),
                    FirstName = "Firstname " + (oldContacts.Count + 1)
                };

                app.Contacts.Add(newContact);
                oldContacts.Add(newContact);
            }

            app.Contacts.Remove();
            oldContacts.RemoveAt(oldContacts.Count - 1);
            oldContacts = app.Contacts.GetContactList();

            List<ContactData> newContacts = app.Contacts.GetContactList();
            oldContacts.Sort();
            newContacts.Sort();
            Assert.AreEqual(oldContacts, newContacts);
            
        }
    }
}
