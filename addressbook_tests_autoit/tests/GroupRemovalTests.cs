using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using NUnit.Framework;
using Assert = NUnit.Framework.Assert;

namespace addressbook_tests_autoit
{
    [TestFixture]
    public class GroupRemovalTests : TestBase
    {
        [Test]
        public void GroupRemovalTest()
        {
            if (!app.Groups.GetGroupCheck())
            {
                GroupData group = new GroupData()
                {
                    Name = "grouptodelete"
                };
                app.Groups.Add(group);
            }
            List<GroupData> oldGroups = app.Groups.GetGroupList();
            //aux.Sleep(100);
            app.Groups.Remove();
            Assert.AreEqual(oldGroups.Count - 1, app.Groups.GetGroupCount());
            List<GroupData> newGroups = app.Groups.GetGroupList();
            oldGroups.RemoveAt(0);
            Assert.AreEqual(oldGroups, newGroups);
        }
    }
}
