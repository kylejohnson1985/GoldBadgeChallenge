using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoldBadge_01_Cafe
{
    public class MealContent
    {

        public string MealName { get; set; }

        public string MealDescription { get; set; }

        public string MealIngredients { get; set; }

        public decimal MealPrice { get; set; }

        public MealContent() { }

        public MealContent(string mealName, string mealDescription, string mealIngredients, decimal mealPrice)
        {
            MealName = mealName;
            MealDescription = mealDescription;
            MealIngredients = mealIngredients;
            MealPrice = mealPrice;
        }
    }
}
