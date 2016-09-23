using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using BadApples.Model;
using Microsoft.AspNet.Identity;

namespace InsecureDirectObjectReferenceApple.Controllers
{
    [Authorize]
    public class EmployeesController : Controller
    {
        private Northwind db = new Northwind();

        // BAD
        public ActionResult Index()
        {
            var user = User.Identity.GetUserId();
            var employees = db.Employees.Include(e => e.Employee1);
            return View(employees.ToList());
        }

        //// BETTER
        //public ActionResult Index()
        //{
        //    var userId = User.Identity.GetUserId();
        //    var employees = db.AspNetUsers.First(p => p.Id == userId).Employee.Employees1;
        //    return View(employees.ToList());
        //}

        // BAD
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Employee employee = db.Employees.Find(id);
            if (employee == null)
            {
                return HttpNotFound();
            }
            return View(employee);
        }

        //// BETTER
        //public ActionResult Details(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }

        //    var userId = User.Identity.GetUserId();
        //    var employeeUser = db.AspNetUsers.First(p => p.Id == userId).Employee;
        //    var employee = db.Employees.Find(id);

        //    if (employee == null)
        //    {
        //        return HttpNotFound();
        //    }

        //    if (employee.ReportsTo != employeeUser.EmployeeID)
        //    {
        //        throw new HttpException((int) HttpStatusCode.Forbidden, "Forbidden"); //setup custom page in web.config
        //    }

        //    return View(employee);
        //}

        // GET: Employees/Create
        public ActionResult Create()
        {
            ViewBag.ReportsTo = new SelectList(db.Employees, "EmployeeID", "Username");
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
                db.Employees.Add(employee);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ReportsTo = new SelectList(db.Employees, "EmployeeID", "Username", employee.ReportsTo);
            return View(employee);
        }

        // GET: Employees/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Employee employee = db.Employees.Find(id);
            if (employee == null)
            {
                return HttpNotFound();
            }
            ViewBag.ReportsTo = new SelectList(db.Employees, "EmployeeID", "Username", employee.ReportsTo);
            return View(employee);
        }

        // POST: Employees/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "EmployeeID,Username,LastName,FirstName,Title,TitleOfCourtesy,BirthDate,HireDate,Address,City,Region,PostalCode,Country,HomePhone,Extension,Photo,Notes,ReportsTo,PhotoPath,EncryptedPassword,PlainTextPassword")] Employee employee)
        {
            if (ModelState.IsValid)
            {
                db.Entry(employee).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ReportsTo = new SelectList(db.Employees, "EmployeeID", "Username", employee.ReportsTo);
            return View(employee);
        }

        // GET: Employees/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Employee employee = db.Employees.Find(id);
            if (employee == null)
            {
                return HttpNotFound();
            }
            return View(employee);
        }

        // POST: Employees/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Employee employee = db.Employees.Find(id);
            db.Employees.Remove(employee);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
