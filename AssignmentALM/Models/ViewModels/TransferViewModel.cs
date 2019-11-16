using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AssignmentALM.Models.ViewModels
{
    public class TransferViewModel
    {
        public int FromAcc { get; set; }
        public int ToAcc { get; set; }
        public decimal Amount { get; set; }

        public string Message { get; set; }
    }
}
