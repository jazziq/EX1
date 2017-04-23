using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using System.Text.RegularExpressions;

namespace WebAddressBookTests
{
    [TestFixture]
    public class ContactInformationTests : AuthTestBase
    {
        [Test]
        public void TestContactInformation()
        {
            ContactData fromTable = app.Contacts.GetContactInformationFromTable(0);
            ContactData fromForm = app.Contacts.GetContactInformationFromEditForm();

            //verification
            Assert.AreEqual(fromTable, fromForm);
            Assert.AreEqual(fromTable.Address, fromForm.Address);
            Assert.AreEqual(fromTable.AllEmails, fromForm.AllEmails);
            Assert.AreEqual(fromTable.AllPhones, fromForm.AllPhones);
        }

        [Test]
        public void TestDetailContactInformation()
        {
            ContactData fromForm = app.Contacts.GetContactInformationFromEditForm();

            string fullContactInfo;
            fullContactInfo =
                fromForm.FirstName +
                fromForm.MiddleName +
                fromForm.LastName +
                fromForm.Address;

            if (fromForm.HomePhone != "")
            {
                fromForm.HomePhone = "H:" + fromForm.HomePhone;
            }

            if (fromForm.MobilePhone != "")
            {
                fromForm.MobilePhone = "M:" + fromForm.MobilePhone;
            }

            if (fromForm.WorkPhone != "")
            {
                fromForm.WorkPhone = "W:" + fromForm.WorkPhone;
            }

            fullContactInfo = fullContactInfo +
                fromForm.HomePhone +
                fromForm.MobilePhone +
                fromForm.WorkPhone +
                fromForm.Email +
                fromForm.Email2 +
                fromForm.Email3;
            fullContactInfo = Regex.Replace(fullContactInfo, " ", "");

            //verification
            Assert.AreEqual(fullContactInfo, app.Contacts.GetContactInformationFromDetailForm());

        }

    }
}
