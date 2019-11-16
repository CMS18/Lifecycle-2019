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

            return View("Index", model);

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("Bank")]
        public IActionResult Index(NewBalanceViewModel model)

        {

            if (ModelState.IsValid)
            {
                if (model.updateBalance == "withdraw")
                {

                    model.dispalyAlert = _repository.Withdraw(model.Amount, model.Account);
                }

                if (model.updateBalance == "deposit")
                {
                    model.dispalyAlert = _repository.Deposit(model.Account, model.Amount);

                }
            }

            return View(model);

        }

        [HttpGet]
        public IActionResult Transfer()
        {
            var model = new TransferViewModel();
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Transfer(TransferViewModel model)
        {
            if (ModelState.IsValid)
            {
                var fromAcc = _repository.Accounts.FirstOrDefault(a => a.AccountNumber == model.FromAcc);
                if (fromAcc == null)
                {
                    model.Message = $"The account {model.FromAcc} does not exist.";
                }
                else
                {
                    model.Message = fromAcc.Transfer(model.ToAcc, model.Amount, _repository);
                }
            }
            return View(model);
        }
    }
}
