using System;
using System.Text;
using System.Collections.Generic;
using NUnit.Framework;


namespace Addressbook_Tests_White
{
    [TestFixture]
    public class ContactCreationTests : TestBase
    {
        [Test]
        public void  ContactCreationTest()
        {
            List<ContactData> oldContacts = app.Contacts.GetContactList();

            ContactData newContact = new ContactData()
            {
                FirstName = "Firstname " + (oldContacts.Count + 1),
                LastName = "Lastname " + (oldContacts.Count + 1)                
            };

            app.Contacts.Add(newContact);
            
            
            List<ContactData> newContacts = app.Contacts.GetContactList();
            oldContacts.Add(newContact);
            oldContacts.Sort();
            newContacts.Sort();

            Assert.AreEqual(oldContacts, newContacts);
        }
    }
}
