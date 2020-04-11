using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoldBadge_05_Greet
{
    public enum CustomerStatus
    {
        Potential = 1, Current, Past
    }


    class CustomerInformation
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public CustomerStatus CustomerStatus { get; set; }
        public string CustomerMessage { get; set; }
        public CustomerInformation() { }
        public CustomerInformation(string firstName, string lastName, CustomerStatus customerStatus, string customerMessage)
        {
            FirstName = firstName;
            LastName = lastName;
            CustomerStatus = customerStatus;
            CustomerMessage = customerMessage;
        }
        public void CustomerFullName(string firstName, string lastName)
        {
            string fullName = firstName + lastName;
        }
    }
}
