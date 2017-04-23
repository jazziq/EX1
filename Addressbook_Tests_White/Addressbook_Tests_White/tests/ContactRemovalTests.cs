using System;
using System.Text;
using System.Collections.Generic;
using NUnit.Framework;


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
