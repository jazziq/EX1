using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace WebAddressBookTests
{
    public class ContactRemovalTests : ContactTestBase
    {

        [Test]
        public void ContactRemovalTest()
        {
            if (! app.Contacts.IsContactPresent())
            {
                //Создание контакта
                ContactCreationTests newContact = new ContactCreationTests();
                newContact.SetupApplicationManager();

                IEnumerable<ContactData> contactData = ContactCreationTests.RandomContactDataProvider();
                newContact.ContactCreationTest(contactData.ElementAt(1));
            }

            List<ContactData> oldContacts = app.Contacts.GetContactList();
            ContactData toBeRemoved = oldContacts[0];
            //Удаление контакта
            app.Contacts.Remove(toBeRemoved);
            Assert.AreEqual(oldContacts.Count - 1, app.Contacts.GetContactCount());

            List<ContactData> newContacts = app.Contacts.GetContactList();
            
            oldContacts.RemoveAt(0);
            oldContacts.Sort();
            newContacts.Sort();
            Assert.AreEqual(oldContacts, newContacts);

            foreach (ContactData contact in newContacts)
            {
                Assert.AreNotEqual(contact.Id, toBeRemoved.Id);
            }

        }

    }
}
