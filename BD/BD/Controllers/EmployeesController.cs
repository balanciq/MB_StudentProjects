using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using BD.Data;
using BD.Models.HR;

namespace BD.Controllers
{
    public class EmployeesController : Controller
    {
        private HRDContext db = new HRDContext();

        // GET: Employees
        public ActionResult Index()
        {
            var employees = db.Employees.Include(e => e.Department);
            return View(employees.ToList());
        }

        // GET: Employees/Details/5
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

        // GET: Employees/Create
        public ActionResult Create()
        {
            ViewBag.DepartmentId = new SelectList(db.Departments, "DepartmentId", "DepartmentCity");
            return View();
        }

        // POST: Employees/Create
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "EmployeeId,Name,Surname,MiddleName,PasportData,PhoneNumber,Graduate,BirthDate,Address,Languages,LastJob,СomeDate,ContractTerm,DepartmentId")] Employee employee)
        {
            if (ModelState.IsValid)
            {
                Department c = new Department();

                int? cid = employee.DepartmentId;
                c = db.Departments.Find(cid);
                c.EmplQuant++;
                db.Departments.AddOrUpdate(c);
                db.Employees.Add(employee);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.DepartmentId = new SelectList(db.Departments, "DepartmentId", "DepartmentCity", employee.DepartmentId);
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
            ViewBag.DepartmentId = new SelectList(db.Departments, "DepartmentId", "DepartmentCity", employee.DepartmentId);
            return View(employee);
        }

        // POST: Employees/Edit/5
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "EmployeeId,Name,Surname,MiddleName,PasportData,PhoneNumber,Graduate,BirthDate,Address,Languages,LastJob,СomeDate,ContractTerm,DepartmentId")] Employee employee)
        {
            if (ModelState.IsValid)
            {
                db.Entry(employee).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.DepartmentId = new SelectList(db.Departments, "DepartmentId", "DepartmentCity", employee.DepartmentId);
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
            Department c = new Department();
            
            int? cid = employee.DepartmentId;
            c = db.Departments.Find(cid);
            c.EmplQuant--;

            db.Employees.Remove(employee);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        // GET: Employees/Delete/5
        public ActionResult Save(int? id)
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
        [HttpPost,ActionName("Save")]
        [ValidateAntiForgeryToken]
        public ActionResult Save([Bind(Include = "EmployeeId,Name,Surname,MiddleName,PasportData,PhoneNumber,Graduate,BirthDate,Address,Languages,LastJob,СomeDate,ContractTerm,DepartmentId")] Employee employee)
        {
            Dismissal dis = new Dismissal();
            if (ModelState.IsValid)
            {
    
                dis.Address = employee.Address;
                dis.BirthDate = employee.BirthDate;
                dis.ContractTerm = employee.ContractTerm;
                dis.Employee = employee;
                dis.Graduate = employee.Graduate;
                dis.Languages = employee.Languages;
                dis.MiddleName = employee.MiddleName;
                dis.Name = employee.Name;
                dis.PasportData = employee.PasportData;
                dis.PhoneNumber = employee.PhoneNumber;
                dis.Surname = employee.Surname;
                dis.СomeDate = employee.СomeDate;
                dis.LastJob = employee.LastJob;

                dis.DisDate = new DateTime(2018, 12, 12);
                db.Dismissals.Add(dis);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.DepartmentId = new SelectList(db.Departments, "DepartmentId", "DepartmentCity", dis.EmployeeId);
            return View(dis);
        }

        public ActionResult Oldi()
        {
            var employees = db.Employees.Include(e => e.Department);
            return View(employees.ToList());

        }
        public ActionResult EndContract()
        {
            DateTime startDate = DateTime.Now;
            DateTime date = DateTime.Now.AddMonths(-2) ;
            TimeSpan date3 = startDate.Subtract(date);
            
           
            var employees = db.Employees.Include(e => e.Department);
            ViewBag.TwoMonths = date;
             
            return View(employees.ToList());

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
