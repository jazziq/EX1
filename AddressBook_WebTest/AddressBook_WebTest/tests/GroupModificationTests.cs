using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using NUnit.Framework;

namespace WebAddressBookTests
{
    [TestFixture]
    public class GroupModificationTests : GroupTestBase
    {
        [Test]
        public void GroupModificationTest()
        {
            if (! app.Groups.IsGroupPresent())
            {
                //Создание группы
                GroupCreationTests newGroup = new GroupCreationTests();
                newGroup.SetupApplicationManager();

                IEnumerable<GroupData> grData = GroupCreationTests.RandomGroupDataProvider();
                newGroup.GroupCreationTest(grData.ElementAt(1));
            }

            List<GroupData> oldGroups = GroupData.GetAll();
            GroupData oldData = oldGroups[0];

            //Изменение группы
            GroupData newData = new GroupData(GenerateRandomString(5))
            {
                Header = GenerateRandomString(10),
                Footer = GenerateRandomString(10)
            };
            app.Groups.Modify(oldData, newData);
            Assert.AreEqual(oldGroups.Count, app.Groups.GetGroupCount());

            List<GroupData> newGroups = GroupData.GetAll();
            oldGroups[0].Name = newData.Name;
            oldGroups.Sort();
            newGroups.Sort();
            Assert.AreEqual(oldGroups, newGroups);
            
            foreach (GroupData group in newGroups)
            {
                if (group.Id == oldData.Id)
                {
                    Assert.AreEqual(newData.Name, group.Name);
                }
            }
        }

    }
}
