using System;
using GoldBadge_01_Cafe;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ContentRepositoryTests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void SetMealName()
        {
            MealContent content = new MealContent();

            content.MealName = "Cheese Burger";

            string expected = "Cheese Burger";
            string actual = content.MealName;

            Assert.AreEqual(expected, actual);
        }
    }
}
