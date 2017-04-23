using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace WebAddressBookTests
{
    public class AddingContactToGroupTests : AuthTestBase
    {
        [Test]
        public void TestAddingContactToGroup()
        {
            GroupData group = GroupData.GetAll()[0];
            List<ContactData> oldListContacts = group.GetContacts();
            ContactData contact = ContactData.GetAll().Except(oldListContacts).First();

            app.Contacts.AddContactToGroup(contact, group);

            //actions
            List<ContactData> newListContacts = group.GetContacts();
            oldListContacts.Add(contact);
            oldListContacts.Sort();
            newListContacts.Sort();

            Assert.AreEqual(oldListContacts, newListContacts);
        }

        [Test]
        public void TestRemovingContactFromGroup()
        {
            GroupData group = GroupData.GetAll()[0];
            List<ContactData> oldListContacts = group.GetContacts();
            ContactData contact = ContactData.GetAll().First();

            app.Contacts.RemoveContactFromGroup(contact, group);

            //actions
            List<ContactData> newListContacts = group.GetContacts();
            oldListContacts.Remove(contact);
            oldListContacts.Sort();
            newListContacts.Sort();

            Assert.AreEqual(oldListContacts, newListContacts);
        }
    }
}
