using System.Linq;
using System.Web.Mvc;
using BadApples.Model;
using CrossSiteRequestForgeryApple.Models;

namespace CrossSiteRequestForgeryApple.Controllers
{
    public class BankAccountController : Controller
    {
        readonly Northwind _northwind = new Northwind();

        [Authorize(Roles = "Admin,User")]
        public ActionResult Index()
        {
            var user = _northwind.AspNetUsers.FirstOrDefault(u => u.UserName == User.Identity.Name);

            if (user?.AccountBalance == null) return View("Error");

            var bankAccount = new BankAccountViewModel
            {
                CurrentBalance = user.AccountBalance.Value
            };

            return View(bankAccount);
        }

        //
        // POST: /BankAccount/Withdraw
        [HttpPost]
        [Authorize(Roles = "Admin,User")]
        //[ValidateAntiForgeryToken]
        public ActionResult Withdraw(BankAccountViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View("Index", model);
            }

            var user = _northwind.AspNetUsers.FirstOrDefault(u => u.UserName == User.Identity.Name);

            if (user?.AccountBalance == null) return View("Error");

            user.AccountBalance = user.AccountBalance.Value - model.TransferAmount;

            _northwind.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}