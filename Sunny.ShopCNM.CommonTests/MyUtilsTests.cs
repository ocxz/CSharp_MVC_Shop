using Microsoft.VisualStudio.TestTools.UnitTesting;
using Sunny.ShopCNM.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sunny.ShopCNM.Common.Tests
{
    [TestClass()]
    public class MyUtilsTests
    {
        [TestMethod()]
        public void SerializeDictionaryToJsonStringTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void UpdateNewTest()
        {
            Person p1 = new Person { Id = 1, Name = "张三", IsGood = true };
            Person p2 = new Person();
            MyUtils.UpdateNew<Person>(p2, p1);
            Assert.AreEqual(p2.Id, p1.Id);
            Assert.AreEqual(p2.Name, p1.Name);
            Assert.AreEqual(p2.IsGood, p1.IsGood);
        }
    }

    public class Person
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool IsGood { get; set; }
    }
}