using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoldBadge_05_Greet
{
    class CustomerContentRepository
    {
        protected List<CustomerInformation> _customerDirectory = new List<CustomerInformation>();

        public bool AddGreetingToDirectory(CustomerInformation greeting)
        {
            int startingCount = _customerDirectory.Count;

            _customerDirectory.Add(greeting);

            bool wasAdded = (_customerDirectory.Count > startingCount);

            return wasAdded;
        }

        public bool RemoveGreetingFromDirectory(string customerName)
        {
            int startingCount = _customerDirectory.Count;

            int index = -1;

            string firstName = "";
            string lastName = "";

            foreach (CustomerInformation greeting in _customerDirectory)
            {
                if (greeting.FirstName == firstName && greeting.LastName == lastName)
                {
                    index = _customerDirectory.IndexOf(greeting);
                }
            }
            if(index > -1)
            {
                _customerDirectory.RemoveAt(index);
            }

            bool wasRemoved = (_customerDirectory.Count < startingCount);
            return wasRemoved;
        }

        public List<CustomerInformation> GetCustomers()
        {
            return _customerDirectory;
        }


        public void UpdateGreeting()
        {
        }

        public List<CustomerInformation> GetCustomersAlphabetically()
        {
            return _customerDirectory;
        }
    }
}
