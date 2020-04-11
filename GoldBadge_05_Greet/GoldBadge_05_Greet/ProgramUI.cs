using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static GoldBadge_05_Greet.CustomerInformation;

namespace GoldBadge_05_Greet
{
    class ProgramUI
    {
        private readonly CustomerContentRepository _customerRepo = new CustomerContentRepository();

        public void Run()
        {
            SeedContent();
            RunMenu();
        }

        public void SeedContent()
        {
            CustomerInformation johnDoe = new CustomerInformation(
                "John",
                "Doe",
                CustomerStatus.Potential,
                "We currently have the lowest rates on Helicopter Insurance!");

            CustomerInformation janeDoe = new CustomerInformation(
                "Jane",
                "Doe",
                CustomerStatus.Current,
                "Thank you for your work with us. We appreciate your loyalty. Here's a coupon.");

            CustomerInformation bobSmith = new CustomerInformation(
                "Bob",
                "Smith",
                CustomerStatus.Past,
                "It's been a long time since we've heard from you, we want you back.");

            _customerRepo.AddGreetingToDirectory(johnDoe);
            _customerRepo.AddGreetingToDirectory(janeDoe);
            _customerRepo.AddGreetingToDirectory(bobSmith);
        }
        private void RunMenu()
        {
            bool programIsRunning = true;
            while (programIsRunning)
            {
                Console.Clear();
                Console.WriteLine("Enter an option:\n" +
                    "1. Add New Greeting\n" +
                    "2. Show All Greetings\n" +
                    "3. Show All Greetings (Alphabetical)\n" +
                    "4. Update Greeting\n" +
                    "5. Remove Greeting\n" +
                    "6. Exit");

                string userInput = Console.ReadLine();
                switch (userInput)
                {
                    case "1":
                        AddGreeting();
                        break;
                    case "2":
                        ShowAllGreetings();
                        break;
                    case "3":
                        ShowAllGreetingsAlphabetical();
                        break;
                    case "4":
                        UpdateGreeting();
                        break;
                    case "5":
                        RemoveGreeting();
                        break;
                    case "6":
                        Console.WriteLine("Come back soon!");
                        programIsRunning = false;
                        break;
                    default:
                        Console.WriteLine("Please enter a valid selection");
                        break;
                }
            }
        }

        private void AddGreeting()
        {
            Console.Clear();

            Console.WriteLine("Enter Customer's First Name:");
            string firstName = Console.ReadLine();

            Console.WriteLine("Enter Customer's Last Name:");
            string lastName = Console.ReadLine();

            string customerMessage = "";
            CustomerStatus customerStatus=CustomerStatus.Potential;

            Console.WriteLine("Please Select Customer Type:\n" +
                "1. Potential Customer\n" +
                "2. Current Customer\n" +
                "3. Past Customer");
            string customerStatusInput = Console.ReadLine();

            switch (customerStatusInput)
            {
                case "1":
                    customerStatus = CustomerStatus.Potential;
                    customerMessage = "We currently have the lowest rates on Helicopter Insurance!";
                    break;
                case "2":
                    customerStatus = CustomerStatus.Current;
                    customerMessage = "Thank you for your work with us. We appreciate your loyalty. Here's a coupon.";
                    break;
                case "3":
                    customerStatus = CustomerStatus.Past;
                    customerMessage = "It's been a long time since we've heard from you, we want you back";
                    break;
                default:
                    Console.WriteLine("Please enter a valid selection.");
                    break;
            }

            CustomerInformation newGreeting = new CustomerInformation(firstName, lastName, customerStatus, customerMessage);

            bool contentWasAdded = _customerRepo.AddGreetingToDirectory(newGreeting);
            if (contentWasAdded)
            {
                Console.WriteLine("Greeting added successfully!");
            }
            else
            {
                Console.WriteLine("Error adding greeting.");
            }

            Console.WriteLine("Press any key to continue...");
            Console.ReadLine();
        }

        private void ShowAllGreetings()
        {
            Console.Clear();

            int index = 1;
            List<CustomerInformation> customers = _customerRepo.GetCustomers();

            Console.WriteLine($"{"Index #", -15} {"First Name", -20} {"Last Name", -20} {"Customer Status", -20} {"Message", -30}");

            foreach(CustomerInformation greeting in customers)
            {
                Console.WriteLine($" {index++, -15} {greeting.FirstName, -20} {greeting.LastName, -20} {greeting.CustomerStatus, -20} {greeting.CustomerMessage, -30}");
            }
            Console.WriteLine("Press any key to continue..");
            Console.ReadLine();
        }

        private void ShowAllGreetingsAlphabetical()
        {
            Console.Clear();

            int index = 1;
            List<CustomerInformation> customers = _customerRepo.GetCustomers();
            customers.Sort((x, y) => string.Compare(x.LastName, y.LastName));

            Console.WriteLine($"{"Index #",-15} {"Last Name",-20} {"First Name",-20} {"Customer Status",-20} {"Message",-30}");

            foreach (CustomerInformation greeting in customers)
            {
                Console.WriteLine($" {index++,-15} {greeting.LastName,-20} {greeting.FirstName,-20} {greeting.CustomerStatus,-20} {greeting.CustomerMessage,-30}");
            }
            Console.WriteLine("Press any key to continue..");
            Console.ReadLine();
        }

        private void UpdateGreeting()
        {
            List<CustomerInformation> customers = _customerRepo.GetCustomers();

            Console.WriteLine("Enter the full name of the customer greeting to update:");
            string fullName = Console.ReadLine();
        }

        private void RemoveGreeting()
        {
            Console.Clear();
            List<CustomerInformation> customers = _customerRepo.GetCustomers();
        }
    }
}
