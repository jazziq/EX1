using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;
using System.Text.RegularExpressions;


namespace WebAddressBookTests
{
    public class ContactHelper : HelperBase
    {
        public ContactHelper(ApplicationManager manager) : base(manager)
        {
        }

        public ContactHelper Create(ContactData contact)
        {
            manager.Navigator.GoToHomePage();
            manager.Contacts.InitContactCreation();
            FillContactForm(contact);
            SubmitContact();
            manager.Navigator.GoToHomePage();

            return this;
        }

        public void AddContactToGroup(ContactData contact, GroupData group)
        {
            manager.Navigator.GoToHomePage();
            ClearGroupFilter();
            SelectContact(contact.Id);
            SelectGroupToAdd(group.Name);
            CommitAddingContactToGroup();
            new WebDriverWait(driver, TimeSpan.FromSeconds(10))
                .Until(d => d.FindElements(By.CssSelector("div.msgbox")).Count > 0);
        }

        public void RemoveContactFromGroup(ContactData contact, GroupData group)
        {
            manager.Navigator.GoToHomePage();
            ClearGroupFilter();
            SelectGroupFilter(group.Name);
            SelectContact(contact.Id);
            CommitRemovingContactFromGroup();
            new WebDriverWait(driver, TimeSpan.FromSeconds(10))
                .Until(d => d.FindElements(By.CssSelector("div.msgbox")).Count > 0);
        }

        private void CommitRemovingContactFromGroup()
        {
            driver.FindElement(By.Name("remove")).Click();
        }

        private void SelectGroupFilter(string name)
        {
            new SelectElement(driver.FindElement(By.Name("group"))).SelectByText(name);
        }

        public void ClearGroupFilter()
        {
            new SelectElement(driver.FindElement(By.Name("group"))).SelectByText("[all]");
        }

        public void SelectGroupToAdd(string name)
        {
            new SelectElement(driver.FindElement(By.Name("to_group"))).SelectByText(name);
        }

        public void CommitAddingContactToGroup()
        {
            driver.FindElement(By.Name("add")).Click();
        }

        public ContactHelper FillContactForm(ContactData contact)
        {
            //Персональные данные
            Type(By.Name("firstname"), contact.FirstName);
            Type(By.Name("middlename"), contact.MiddleName);
            Type(By.Name("lastname"), contact.LastName);
            Type(By.Name("nickname"), contact.NickName);
            //Дата рождения
            new SelectElement(driver.FindElement(By.Name("bday"))).SelectByText(contact.BDay);
            new SelectElement(driver.FindElement(By.Name("bmonth"))).SelectByText(contact.BMonth);
            Type(By.Name("byear"), contact.BYear);
            //Годовщина
            new SelectElement(driver.FindElement(By.Name("aday"))).SelectByText(contact.ADay);
            new SelectElement(driver.FindElement(By.Name("amonth"))).SelectByText(contact.AMonth);
            Type(By.Name("ayear"), contact.AYear);

            //Сведения о работе
            Type(By.Name("title"), contact.Title);
            Type(By.Name("company"), contact.Company);
            Type(By.Name("address"), contact.Address);

            //Контактные данные
            Type(By.Name("home"), contact.HomePhone);
            Type(By.Name("mobile"), contact.MobilePhone);
            Type(By.Name("work"), contact.WorkPhone);
            Type(By.Name("fax"), contact.Fax);
            Type(By.Name("email"), contact.Email);
            Type(By.Name("email2"), contact.Email2);
            Type(By.Name("email3"), contact.Email3);
            Type(By.Name("homepage"), contact.Homepage);

            //Дополнительные данные
            Type(By.Name("address2"), contact.Address2);
            Type(By.Name("phone2"), contact.Phone2);
            Type(By.Name("notes"), contact.Notes);

            return this;
        }

        public ContactHelper Modify(/*int idContac, int idxEdit,*/ ContactData newData)
        {
            manager.Navigator.GoToHomePage();
            SelectContact();
            InitContactModification();
            FillContactForm(newData);
            SubmitContactModification();
            manager.Navigator.GoToHomePage();

            return this;
        }

        public ContactHelper Modify(ContactData oldContact, ContactData newData)
        {
            manager.Navigator.GoToHomePage();
            SelectContact(oldContact.Id);
            InitContactModification();
            FillContactForm(newData);
            SubmitContactModification();
            manager.Navigator.GoToHomePage();

            return this;
        }

        public ContactHelper Remove()
        {
            manager.Navigator.GoToHomePage();
            SelectContact();
            driver.FindElement(By.XPath("//input[@value='Delete']")).Click();
            driver.SwitchTo().Alert().Accept();
            contactCache = null;
            manager.Navigator.GoToHomePage();
            return this;
        }

        public ContactHelper Remove(ContactData contact)
        {
            manager.Navigator.GoToHomePage();
            SelectContact(contact.Id);
            driver.FindElement(By.XPath("//input[@value='Delete']")).Click();
            driver.SwitchTo().Alert().Accept();
            contactCache = null;
            manager.Navigator.GoToHomePage();
            return this;
        }

        public ContactHelper InitContactCreation()
        {
            // Init new group creation
            driver.FindElement(By.LinkText("add new")).Click();
            return this;
        }

        public ContactHelper InitContactModification()
        {
            string idxEdit;

            idxEdit = driver.FindElement(By.TagName("td")).FindElement(By.TagName("input")).GetAttribute("value");
            driver.FindElement(By.XPath("(//img[@alt='Edit'])[1]")).Click();
            return this;
        }

        public ContactHelper InitContactDetailInfo()
        {
            string baseURL = "http://localhost/";
            string idxEdit;
            idxEdit = driver.FindElement(By.TagName("td")).FindElement(By.TagName("input")).GetAttribute("value");
            driver.Navigate().GoToUrl(baseURL + "addressbook/view.php?id=" + idxEdit);
            return this;
        }

        public ContactHelper SelectContact()
        {
            string idContact;

            idContact = driver.FindElement(By.TagName("td")).FindElement(By.TagName("input")).GetAttribute("value");
            driver.FindElement(By.Id("" + idContact + "")).Click();
            return this;
        }

        public ContactHelper SelectContact(String idContact)
        {
            driver.FindElement(By.Id("" + idContact + "")).Click();
            return this;
        }

        public ContactHelper SubmitContact()
        {
            //Сохранение контакта
            driver.FindElement(By.Name("submit")).Click();
            contactCache = null;
            return this;
        }

        public ContactHelper SubmitContactModification()
        {
            //Submit group
            driver.FindElement(By.Name("update")).Click();
            contactCache = null;
            return this;
        }

        public bool IsContactPresent()
        {
            manager.Navigator.GoToHomePage();
            return IsElementPresent(By.TagName("td"));
        }

        private List<ContactData> contactCache = null;

        public List<ContactData> GetContactList()
        {
            if (contactCache == null)
            {
                contactCache = new List<ContactData>();
                manager.Navigator.GoToHomePage();
                ICollection<IWebElement> elements_tr = driver.FindElements(By.CssSelector("tr"));
                foreach (IWebElement element in elements_tr)
                {
                    IList<IWebElement> elements_td = element.FindElements(By.CssSelector("td"));
                    if (elements_td.Count != 0)
                    {
                        string s;
                        s = element.FindElement(By.TagName("input")).GetAttribute("id");

                        contactCache.Add(new ContactData(
                            elements_td.ElementAt(1).Text,
                            elements_td.ElementAt(2).Text
                            ) { Id = element.FindElement(By.TagName("input")).GetAttribute("id") }
                        );
                    }
                }
            }

            return new List<ContactData>(contactCache);
        }

        public int GetContactCount()
        {
            //Первая строка tr Заголовок таблицы
            return driver.FindElements(By.CssSelector("tr")).Count - 1;
        }


        public ContactData GetContactInformationFromTable(int index)
        {
            manager.Navigator.GoToHomePage();
            IList<IWebElement> cells = driver.FindElements(By.Name("entry"))[index]
                .FindElements(By.TagName("td"));

            string lastName = cells[1].Text;
            string firstName = cells[2].Text;
            string address = cells[3].Text;

            string allEmails = cells[4].Text;
            string allPhones = cells[5].Text;

            return new ContactData(lastName, firstName)
            {
                Address = address,
                AllEmails = allEmails,
                AllPhones = allPhones
            };


        }

        public ContactData GetContactInformationFromEditForm()
        {
            manager.Navigator.GoToHomePage();
            SelectContact();
            InitContactModification();
            string lastName = driver.FindElement(By.Name("lastname")).GetAttribute("value");
            string firstName = driver.FindElement(By.Name("firstname")).GetAttribute("value");
            string middleName = driver.FindElement(By.Name("middlename")).GetAttribute("value");
            string address = driver.FindElement(By.Name("address")).GetAttribute("value");

            string email = driver.FindElement(By.Name("email")).GetAttribute("value");
            string email2 = driver.FindElement(By.Name("email2")).GetAttribute("value");
            string email3 = driver.FindElement(By.Name("email3")).GetAttribute("value");

            string homePhone = driver.FindElement(By.Name("home")).GetAttribute("value");
            string mobilePhone = driver.FindElement(By.Name("mobile")).GetAttribute("value");
            string workPhone = driver.FindElement(By.Name("work")).GetAttribute("value");

            return new ContactData(lastName, firstName)
            {
                MiddleName = middleName,
                Address = address,
                HomePhone = homePhone,
                MobilePhone = mobilePhone,
                WorkPhone = workPhone,
                Email = email,
                Email2 = email2,
                Email3 = email3
            };
        }

        public string GetContactInformationFromDetailForm()
        {
            manager.Navigator.GoToHomePage();
            SelectContact();
            InitContactDetailInfo();

            string contactInfo = driver.FindElement(By.Id("content")).Text;
            contactInfo = Regex.Replace(contactInfo, @"[ \r\n]", "");

            return contactInfo.Trim();
        }


        public int GetNumberOfSearchResults()
        {
            manager.Navigator.GoToHomePage();
            string text = driver.FindElement(By.TagName("label")).Text;
            Match m = new Regex(@"\d+").Match(text);
            return Int32.Parse(m.Value);
        }
    }
}
