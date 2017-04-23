using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using TestStack.White;
using TestStack.White.InputDevices;
using TestStack.White.UIItems;
using TestStack.White.WindowsAPI;
using TestStack.White.UIItems.Finders;
using TestStack.White.UIItems.TreeItems;
using TestStack.White.UIItems.WindowItems;
using System.Windows.Automation;

namespace Addressbook_Tests_White
{
    public class GroupHelper : HelperBase
    {
        public static string GROUPWINTITLE = "Group editor";
        public static string DELETEGROUPWINTITLE = "Delete group";

        public GroupHelper(ApplicationManager manager) : base(manager) { }

        public List<GroupData> GetGroupList()
        {
            List<GroupData> list = new List<GroupData>();

            Window dlgGroups = OpenGroupsDialog();
            Tree tree = dlgGroups.Get<Tree>("uxAddressTreeView");
            //TreeNode root = tree.Nodes[0];
            foreach (TreeNode item in tree.Nodes[0].Nodes)
            {
                list.Add(new GroupData()
                {
                    Name = item.Text
                });
            }

            CloseGroupsDialog(dlgGroups);

            return list;
        }

        public void Add(GroupData newGroup)
        {
            Window dlgGroups = OpenGroupsDialog();
            dlgGroups.Get<Button>("uxNewAddressButton").Click();
            TextBox textBox = (TextBox) dlgGroups.Get(SearchCriteria.ByControlType(ControlType.Edit));
            textBox.Enter(newGroup.Name);
            Keyboard.Instance.PressSpecialKey(KeyboardInput.SpecialKeys.RETURN);
            CloseGroupsDialog(dlgGroups);
        }

        public void Remove()
        {
            Window dlgGroups = OpenGroupsDialog();
            SelectGroup(dlgGroups);
            dlgGroups.Get<Button>("uxDeleteAddressButton").Click();
            Window dlgCommitRemoveGroups = OpenGroupsRemovalDialog(dlgGroups);
            dlgCommitRemoveGroups.Get<Button>("uxOKAddressButton").Click();
            CloseGroupsDialog(dlgGroups);
        }

        public Window OpenGroupsDialog()
        {
            manager.mainWND.Get<Button>("groupButton").Click();
            return manager.mainWND.ModalWindow(GROUPWINTITLE);
        }

        public void CloseGroupsDialog(Window dlgGroups)
        {
            dlgGroups.Get<Button>("uxCloseAddressButton").Click();
        }

        public void SelectGroup(Window dlgGroups)
        {
            Tree tree = dlgGroups.Get<Tree>("uxAddressTreeView");
            int cntNodes = tree.Nodes[0].Nodes.Count;
            TreeNode node = tree.Nodes[0].Nodes[cntNodes-1]; //tree.Nodes[tree.Nodes.Count-1];

            node.Select();
        }

        public Window OpenGroupsRemovalDialog(Window dlgGroups)
        {
            return dlgGroups.ModalWindow(DELETEGROUPWINTITLE);
        }

    }
}