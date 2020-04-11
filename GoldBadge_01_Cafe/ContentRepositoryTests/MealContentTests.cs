using System;
using System.Collections.Generic;
using GoldBadge_01_Cafe;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ContentRepositoryTests
{
    [TestClass]
    public class MealContentTests
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

        [TestMethod]
        public void SetDescription()
        {
            MealContent content = new MealContent();

            content.Description = "Tasty burger with cheese";

            string expected = "Tasty burger with cheese";
            string actual = content.Description;

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void SetIngredients()
        {

        }

        [TestMethod]
        public void SetPrice()
        {

        }
    }
}
