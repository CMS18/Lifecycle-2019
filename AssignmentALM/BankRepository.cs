using AssignmentALM.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AssignmentALM
{
    public class BankRepository
    {

        public List<Customers> Customers { get; set; } = new List<Customers>();
        public List<Accounts> Accounts { get; set; } = new List<Accounts>();

        //public BankRepository()
        //{
        //    this.Initialize();
        //}

        public Customers AddCustomer(string firstName, string lastName)
        {
            var customer = new Customers
            {

                CustomerId = Customers.Any() ? Customers.Max(a => a.CustomerId) + 1 : 0,
                FirstName = firstName,
                LastName = lastName
            };
            Customers.Add(customer);
            return customer;
        }

        
        }
    }
}
