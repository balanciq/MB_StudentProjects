using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using BD.Data;
using BD.Models.HR;

namespace BD.Controllers
{
    public class DismissalsController : Controller
    {
        private HRDContext db = new HRDContext();

        // GET: Dismissals
        public ActionResult Index()
        {
            var dismissals = db.Dismissals.Include(d => d.Employee);
            return View(dismissals.ToList());
        }

        // GET: Dismissals/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Dismissal dismissal = db.Dismissals.Find(id);
            if (dismissal == null)
            {
                return HttpNotFound();
            }
            return View(dismissal);
        }

        // GET: Dismissals/Create
        public ActionResult Create()
        {
            ViewBag.EmployeeId = new SelectList(db.Employees, "EmployeeId", "Name");
            return View();
        }

        // POST: Dismissals/Create
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "DismissalId,Name,Surname,MiddleName,PasportData,PhoneNumber,Graduate,BirthDate,Address,Languages,LastJob,СomeDate,ContractTerm,DisDate,EmployeeId")] Dismissal dismissal)
        {
            if (ModelState.IsValid)
            {
                db.Dismissals.Add(dismissal);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.EmployeeId = new SelectList(db.Employees, "EmployeeId", "Name", dismissal.EmployeeId);
            return View(dismissal);
        }

        // GET: Dismissals/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Dismissal dismissal = db.Dismissals.Find(id);
            if (dismissal == null)
            {
                return HttpNotFound();
            }
            ViewBag.EmployeeId = new SelectList(db.Employees, "EmployeeId", "Name", dismissal.EmployeeId);
            return View(dismissal);
        }

        // POST: Dismissals/Edit/5
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "DismissalId,Name,Surname,MiddleName,PasportData,PhoneNumber,Graduate,BirthDate,Address,Languages,LastJob,СomeDate,ContractTerm,DisDate,EmployeeId")] Dismissal dismissal)
        {
            if (ModelState.IsValid)
            {
                db.Entry(dismissal).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.EmployeeId = new SelectList(db.Employees, "EmployeeId", "Name", dismissal.EmployeeId);
            return View(dismissal);
        }

        // GET: Dismissals/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Dismissal dismissal = db.Dismissals.Find(id);
            if (dismissal == null)
            {
                return HttpNotFound();
            }
            return View(dismissal);
        }

        // POST: Dismissals/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Dismissal dismissal = db.Dismissals.Find(id);
            db.Dismissals.Remove(dismissal);
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
