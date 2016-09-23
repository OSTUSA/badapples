using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using BadApples.Model;
using FunctionLevelAccessControlApple.Base;

namespace FunctionLevelAccessControlApple.Controllers
{
    //[Authorize(Roles = "Admin")]
    //https://docs.asp.net/en/latest/security/authorization/index.html
    [Authorize]
    public class EmployeesController : BaseController
    {
        public ActionResult Index()
        {
            var employees = CurrentEmployee.Employees1;
            return View(employees.ToList());
        }

        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var employee = Db.Employees.Find(id);

            if (employee == null)
            {
                return HttpNotFound();
            }

            if (employee.ReportsTo != CurrentEmployee.EmployeeID)
            {
                throw new HttpException((int)HttpStatusCode.Forbidden, "Forbidden"); //setup custom page in web.config
            }

            return View(employee);
        }

        // GET: Employees/Create
        public ActionResult Create()
        {
            ViewBag.ReportsTo = new SelectList(Db.Employees, "EmployeeID", "Username");
            return View();
        }

        // POST: Employees/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "EmployeeID,Username,LastName,FirstName,Title,TitleOfCourtesy,BirthDate,HireDate,Address,City,Region,PostalCode,Country,HomePhone,Extension,Photo,Notes,ReportsTo,PhotoPath,EncryptedPassword,PlainTextPassword")] Employee employee)
        {
            if (ModelState.IsValid)
            {
                Db.Employees.Add(employee);
                Db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ReportsTo = new SelectList(Db.Employees, "EmployeeID", "Username", employee.ReportsTo);
            return View(employee);
        }

        //[Authorize(Roles = "Admin")]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Employee employee = Db.Employees.Find(id);
            if (employee == null)
            {
                return HttpNotFound();
            }
            ViewBag.ReportsTo = new SelectList(Db.Employees, "EmployeeID", "Username", employee.ReportsTo);
            return View(employee);
        }

        // POST: Employees/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        //[Authorize(Roles = "Admin")]
        public ActionResult Edit([Bind(Include = "EmployeeID,Username,LastName,FirstName,Title,TitleOfCourtesy,BirthDate,HireDate,Address,City,Region,PostalCode,Country,HomePhone,Extension,Photo,Notes,ReportsTo,PhotoPath,EncryptedPassword,PlainTextPassword")] Employee employee)
        {
            if (ModelState.IsValid)
            {
                Db.Entry(employee).State = EntityState.Modified;
                Db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ReportsTo = new SelectList(Db.Employees, "EmployeeID", "Username", employee.ReportsTo);
            return View(employee);
        }

        // GET: Employees/Delete/5
        //[Authorize(Roles = "Admin")]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Employee employee = Db.Employees.Find(id);
            if (employee == null)
            {
                return HttpNotFound();
            }
            return View(employee);
        }

        // POST: Employees/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        //[Authorize(Roles = "Admin")]
        public ActionResult DeleteConfirmed(int id)
        {
            Employee employee = Db.Employees.Find(id);
            Db.Employees.Remove(employee);
            Db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                Db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
