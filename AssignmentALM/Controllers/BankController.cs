using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AssignmentALM.Models;
using AssignmentALM.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AssignmentALM.Controllers
{
    public class BankController : Controller
    {
        private BankRepository _repository;

        public BankController(BankRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var model = new NewBalanceViewModel();

            return View("NewBalance" , model);
           
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("")]
        public IActionResult NewBalance(NewBalanceViewModel model)
        {
            //if(ModelState.IsValid)
            //{
            //    if(model.updateBalance == null)
            //    {
            //        model.dispalyAlert = _repository.Withdraw(model.Account, model.Amount);
            //    }
            //    if(model.updateBalance > )
            //    {

            //    }
            //}

            return View( model);

        }
    }
}
