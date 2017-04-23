using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;

namespace AddressBook_Tests_AutoIt
{
    [TestFixture]
    public class GroupRemovalTests : TestBase
    {
        [Test]
        public void GroupRemovalTest()
        {
            List<GroupData> oldGroups = app.Groups.GetGroupList();

            if (oldGroups.Count == 1)
            {
                GroupData newGroup = new GroupData()
                {
                    Name = "Group " + (oldGroups.Count + 1)
                };

                app.Groups.Add(newGroup);
                oldGroups.Add(newGroup);
            }

            app.Groups.Remove();
            oldGroups.RemoveAt(oldGroups.Count - 1);
            oldGroups = app.Groups.GetGroupList();

            List<GroupData> newGroups = app.Groups.GetGroupList();
            oldGroups.Sort();
            newGroups.Sort();
            Assert.AreEqual(oldGroups, newGroups);
           
        }
    }
}
