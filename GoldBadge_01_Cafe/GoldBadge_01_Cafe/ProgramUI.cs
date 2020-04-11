using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoldBadge_01_Cafe
{
    class ProgramUI
    {

        private readonly MealContentRepository _repo = new MealContentRepository();
        public void Run()
        {
            SeedContent();
            RunMenu();
        }

        private void SeedContent()
        {
            MealContent cheeseBurger = new MealContent("Cheese Burger", "Basic burger with cheese", "Meat, buns, lettuce, tomato, ketchup, cheese, mayo", 10.00m);
            MealContent baconCheeseBurger = new MealContent("Bacon Cheese Burger", "Basic burger with cheese and BACON!!!", "Meat, bun, lettuce, tomato, ketchup, cheese, mayo, BACON!!", 13.00m);
            MealContent chickenFingers = new MealContent("Chicken Fingers", "Strips of chicken", "Chicken", 7.50m);

            _repo.AddMenuItem(cheeseBurger);
            _repo.AddMenuItem(baconCheeseBurger);
            _repo.AddMenuItem(chickenFingers);
        }

        private void RunMenu()
        {
            bool programIsRunning = true;
            while (programIsRunning)
            {
                Console.Clear();
                Console.WriteLine("Please make a selection:\n" +
                    "1. Create Menu Item\n" +
                    "2. Delete Menu Item\n" +
                    "3. List All Menu Items\n" +
                    "4. Exit");

                string userInput = Console.ReadLine();
                switch (userInput)
                {
                    case "1":
                        AddMenuItem();
                        break;
                    case "2":
                        DeleteMenuItem();
                        break;
                    case "3":
                        ListAllMenuItems();
                        break;
                    case "4":
                        Console.WriteLine("Please come back!");
                        programIsRunning = false;
                        break;
                    default:
                        Console.WriteLine("Please enter a valid selection");
                        break;
                }
            }
        }

        private void AddMenuItem()
        {
            Console.Clear();

            Console.WriteLine("Enter a name for this meal:");
            string mealName = Console.ReadLine();

            Console.WriteLine("Enter a description for this meal:");
            string mealDescription = Console.ReadLine();

            Console.WriteLine("Enter the ingredients that are in this meal:");
            string mealIngredients = Console.ReadLine();

            Console.WriteLine("Enter a price for this meal:");
            string mealPriceString = Console.ReadLine();
            decimal mealPrice = Convert.ToDecimal(mealPriceString);

            MealContent newContent = new MealContent(mealName, mealDescription, mealIngredients, mealPrice);

            //  Add meal to directory

            bool mealWasAdded = _repo.AddMenuItem(newContent);
            if (mealWasAdded)
            {
                Console.WriteLine("Meal added to directory");
            }
            else
            {
                Console.WriteLine("There was an error adding the meal");
            }

            Console.WriteLine("Press any key to continue...");
            Console.ReadLine();
        }

        private void DeleteMenuItem()
        {
            Console.Clear();
            Console.WriteLine("Enter the name of the meal to remove: \n");
            string mealName = Console.ReadLine();

            bool wasRemoved = _repo.DeleteMenuItem(mealName);
            if (wasRemoved)
            {
                Console.WriteLine("The item has been removed from the menu.");
            }
            else
            {
                Console.WriteLine("There was an error in removing the item. Please try again.");
            }
            Console.WriteLine("Press any key to continue...");
            Console.ReadLine();
        }

        private void ListAllMenuItems()
        {
            Console.Clear();

            int index = 1;
            List<MealContent> contents = _repo.GetContents();
            foreach (MealContent content in contents)
            {
                Console.WriteLine($"{index++}. {content.MealName}\n" +
                    $"Description: {content.MealDescription}\n" +
                    $"Ingredients: {content.MealIngredients}\n" +
                    $"Price: ${content.MealPrice}\n");
            }
            Console.WriteLine("Press any key to continue...");
            Console.ReadLine();

        }
    }
}
