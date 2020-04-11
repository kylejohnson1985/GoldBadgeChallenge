using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using static GoldBadgeChallenge_02.ClaimContent;

namespace GoldBadgeChallenge_02
{
    class ProgramUI
    {
        private readonly Queue<ClaimContent> _claimDirectory = new Queue<ClaimContent>();

        public void Run()
        {
            RunMenu();
        }


        private void RunMenu()
        {
            bool programIsRunning = true;
            while (programIsRunning)
            {
                Console.Clear();
                Console.WriteLine("Select a menu item:\n" +
                    "1. See All Claims\n" +
                    "2. Take Care of Next Claim\n" +
                    "3. Enter a New Claim\n" +
                    "4. Exit");

                string userInput = Console.ReadLine();
                switch (userInput)
                {
                    case "1":
                        ShowAllClaims();
                        break;
                    case "2":
                        NextClaim();
                        break;
                    case "3":
                        AddNewClaim();
                        break;
                    case "4":
                        Console.WriteLine("Please come back soon!");
                        programIsRunning = false;
                        break;
                    default:
                        break;
                }
            }
        }

        private void ShowAllClaims()
        {
            Console.Clear();

            Console.WriteLine($"{"ClaimID",-15} {"Type",-15} {"Description",-30} {"Amount",-15} {"Date of Incident",-25} {"Date of Claim",-25} {"Is Valid",-10}");
            Console.WriteLine(new string('-', 150));

            int index = 1;

            Queue<ClaimContent> contents = _claimDirectory;
            foreach (ClaimContent content in contents)
            {
                Console.WriteLine($"{index++, -15} {content.TypeOfClaim, -15} {content.Description, -30} {content.AmountOfDamage, -15} {content.DateOfIncident, -25} {content.DateOfClaim, -25} {content.IsValid, -10}");
            }
            Console.WriteLine("Press any key to continue....");
            Console.ReadLine();
        }

        private void AddNewClaim()
        {
            Console.Clear();
            Console.WriteLine("Enter the claim ID:");
            string claimIDInput = Console.ReadLine();
            int claimID = Convert.ToInt32(claimIDInput);

            Console.WriteLine("Select claim type\n" +
                "1. Car\n" +
                "2. House\n" +
                "3. Theft");
            string claimChoice = Console.ReadLine();

            ClaimType typeOfClaim = ClaimType.Car;

            switch (claimChoice)
            {
                case "1":
                    typeOfClaim = ClaimType.Car;
                    break;
                case "2":
                    typeOfClaim = ClaimType.House;
                    break;
                case "3":
                    typeOfClaim = ClaimType.Theft;
                    break;
                default:
                    Console.WriteLine("Please pick a valid claim type");
                    break;
            }

            Console.WriteLine("Enter a description of the claim:");
            string description = Console.ReadLine();

            Console.WriteLine("Enter a dollar value for the damage:");
            string dollarAmount = Console.ReadLine();
            decimal amountOfDamage = Convert.ToDecimal(dollarAmount);

            Console.WriteLine("Enter the date of the incident (mm/dd/yyyy):");
            string dateOfIncidentString = Console.ReadLine();
            DateTime dateOfIncident = DateTime.Parse(dateOfIncidentString);

            Console.WriteLine("Enter the date of the claim (mm/dd/yyyy)");
            string dateOfClaimString = Console.ReadLine();
            DateTime dateOfClaim = DateTime.Parse(dateOfClaimString);

            if (dateOfClaim > dateOfIncident.AddDays(30))
            {
                bool isValid = true;
            }
            else
            {
                bool isValid = false;
            }

            ClaimContent newClaim = new ClaimContent(claimID, typeOfClaim, description, amountOfDamage, dateOfIncident, dateOfClaim);

            _claimDirectory.Enqueue(newClaim);
  
        }

        private void NextClaim()
        {

        }
    }
}
