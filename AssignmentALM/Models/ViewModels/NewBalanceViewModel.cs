using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AssignmentALM.Models.ViewModels
{
    public class NewBalanceViewModel
    {
        [Display(Name = "Account Number")]
        [Required]
        public int Account { get; set; }

        [Display(Name = "Amount")]
        [Required]
        public decimal Amount { get; set; }


        public string dispalyAlert { get; set; }

        public string updateBalance { get; set; }
    }
}



