using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AssignmentALM.Models
{
    public class Account
    {
      

        public int AccountNumber { get; set; }
        public Customer AccountHolder { get; set; }
        public Decimal Balance { get; set; }

    }
}

