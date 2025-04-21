using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using AutoItX3Lib;
using System.Security.Cryptography.X509Certificates;

namespace addressbook_tests_autoit
{
    public class GroupHelper : HelperBase
    {
        public static string GROUPWINTITLE = "Group editor";
        public static string GROUPDELETETILE = "Delete group";
        public GroupHelper(ApplicationManager manager) : base(manager) { }

       
        public List<GroupData> GetGroupList()
        {
            List<GroupData> list = new List<GroupData>();
            OpenGroupsDialogue();
            //Текст названия групп в окне Group editor
            string count = aux.ControlTreeView(GROUPWINTITLE, "", "WindowsForms10.SysTreeView32.app.0.2c908d51",
                "GetItemCount", "#0", "");
            for (int i = 0; i < int.Parse(count); i++)
            {
                string item = aux.ControlTreeView(GROUPWINTITLE, "", "WindowsForms10.SysTreeView32.app.0.2c908d51",
                    "GetText", "#0|#" + i, "");
                list.Add(new GroupData()
                {
                    Name = item
                });
            }
            CloseGroupsDialogue();
            return list;
        }

        public void Add(GroupData newGroup)
        {
            OpenGroupsDialogue();
            //Нажатие на кнопку NEW в окне Group editor
            aux.ControlClick(GROUPWINTITLE, "", "WindowsForms10.BUTTON.app.0.2c908d53");
            aux.Send(newGroup.Name);
            aux.Send("{ENTER}");
            CloseGroupsDialogue();
        }

        public void OpenGroupsDialogue()
        {
            //Нажатие на иконку вызова окна Group editor
            aux.ControlClick(WINTITLE, "", "WindowsForms10.BUTTON.app.0.2c908d512");
            aux.WinWait(GROUPWINTITLE);
        }


        public void CloseGroupsDialogue() 
        {
            //Нажатие на кнопку Close в окне Group editor
            aux.ControlClick(GROUPWINTITLE, "", "WindowsForms10.BUTTON.app.0.2c908d54");
        }

        public void Remove()
        {
            OpenGroupsDialogue();
            aux.Sleep(100);
            aux.ControlTreeView(GROUPWINTITLE, "", "WindowsForms10.SysTreeView32.app.0.2c908d51", "Select", "#0|#0", "");
            aux.Sleep(100);
            aux.ControlClick(GROUPWINTITLE, "", "WindowsForms10.SysTreeView32.app.0.2c908d51");
            aux.Sleep(100);
            aux.Send("{DOWN}");
            OpenDeleteGroupsDialogue();
            ClickRadioButtonDeleteTheSelectedGroup();
            ClickButtonOkGroupDialogue();
            CloseGroupsDialogue();
        }

        public void OpenDeleteGroupsDialogue()
        {
            //Нажатие на иконку Delete окна Group editor
            aux.ControlClick(GROUPWINTITLE, "", "WindowsForms10.BUTTON.app.0.2c908d51");
            aux.WinWait(GROUPDELETETILE);
        }

        public void ClickRadioButtonDeleteTheSelectedGroup()
        {
            //Нажатие на радиобатон удаления в окне Delete group
            aux.ControlClick(GROUPDELETETILE, "", "WindowsForms10.BUTTON.app.0.2c908d51");
        }

        public void ClickButtonOkGroupDialogue()
        {
            //Нажатие на кнопку Ок в окне Delete group
            aux.ControlClick(GROUPDELETETILE, "", "WindowsForms10.BUTTON.app.0.2c908d53");
            aux.WinWait(GROUPWINTITLE);
        }

        public bool GetGroupCheck()
        {
            OpenGroupsDialogue();
            int group = int.Parse(aux.ControlTreeView(GROUPWINTITLE, "", "WindowsForms10.SysTreeView32.app.0.2c908d51",
                "GetItemCount", "#0", ""));
            CloseGroupsDialogue();
            return group > 1;
        }

        public int GetGroupCount()
        {
            OpenGroupsDialogue();
            int group = int.Parse(aux.ControlTreeView(GROUPWINTITLE, "", "WindowsForms10.SysTreeView32.app.0.2c908d51",
                "GetItemCount", "#0", ""));
            CloseGroupsDialogue();
            return group;
        }

    }
}
