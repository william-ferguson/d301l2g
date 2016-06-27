using System;
using Microsoft.VisualStudio.TestPlatform.UnitTestFramework;
using L2Go.Models;
namespace unitTests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            string test = "test";
            Assert.AreEqual("test",test);
        }

        [TestMethod]
        public void TestOrder()
        {
            Meals m = new Meals();
            m.Meal = "Beef";
            Assert.AreEqual("Beef", m.Meal);
        }
    }
}
