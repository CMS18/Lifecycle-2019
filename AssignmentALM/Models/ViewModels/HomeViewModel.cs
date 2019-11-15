using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AssignmentALM.Models.ViewModels
{
    public class HomeViewModel
    {
        public List<Customer> Customers { get; set; } = new List<Customer>();

        public List<Account> Accounts { get; set; }
    }
}
