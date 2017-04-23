using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;


namespace WebAddressBookTests
{
    [TestFixture]
    public class ContactModificationTests : ContactTestBase
    {
        [Test]
        public void ContactModificationTest()
        {
            if (! app.Contacts.IsContactPresent())
            {
                //Создание контакта
                ContactCreationTests newContact = new ContactCreationTests();
                newContact.SetupApplicationManager();

                IEnumerable<ContactData> contactData = ContactCreationTests.RandomContactDataProvider();
                newContact.ContactCreationTest(contactData.ElementAt(1));
            }
            
            //Текущущий лист контактов
            List<ContactData> oldContacts = ContactData.GetAll();
            ContactData oldData = oldContacts[0];

            //Изменение контакта
            ContactData newData = new ContactData(GenerateRandomString(20), GenerateRandomString(15))
                { MiddleName = GenerateRandomString(15) };
                
            app.Contacts.Modify(oldData, newData);
            Assert.AreEqual(oldContacts.Count, app.Contacts.GetContactCount());

            //Новый лист контактов
            List<ContactData> newContacts = ContactData.GetAll();
            oldContacts[0].LastName = newData.LastName;
            oldContacts[0].FirstName = newData.FirstName;
            oldContacts[0].MiddleName = newData.MiddleName;
            oldContacts.Sort();
            newContacts.Sort();
            Assert.AreEqual(oldContacts, newContacts);

            foreach (ContactData contact in newContacts)
            {
                if (contact.Id == oldData.Id)
                {
                    Assert.AreEqual(newData.LastName, contact.LastName);
                    Assert.AreEqual(newData.FirstName, contact.FirstName);
                }
            }

        }
    }
}
