using System.Linq;
using System.Web.Mvc;
using BadApples.Model;
using InjectionApple.Models;

namespace InjectionApple.Controllers
{
    public class HomeController : Controller
    {
        Northwind Northwind = new Northwind();

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        //
        // GET: /Home/Employees
        [HttpGet]
        [AllowAnonymous]
        public ActionResult Employees(EmployeesViewModel model, string returnUrl)
        {
            //var employees =
            //    Northwind.Employees.Where(
            //        e => e.FirstName.Contains(model.EmployeeName) || e.LastName.Contains(model.EmployeeName)).ToList();

            var employees =
                Northwind.Employees.SqlQuery("Select * from dbo.employees where FirstName like '%" + model.EmployeeName +
                                             "%'").ToList();

            // ' or 1 = 1--
            // ' UPDATE dbo.employees set PlainTextPassword = 'password' --


            model.Employees = employees;

            return View("Index", model);
        }
    }
}