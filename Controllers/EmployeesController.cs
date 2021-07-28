using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using DeptEmployeeMVC.Models;

namespace DeptEmployeeMVC.Controllers
{
    public class EmployeesController : Controller
    {
        private DataContext db = new DataContext();

        // GET: Employees
        public ActionResult Index()
        {
            var employees = db.employees.Include(e => e.Department).Include(e => e.salary);
            var result = (from emp in employees
                         orderby emp.salary.SalaryAmount descending, emp.Name
                         select emp ).ToList();
            return View(result);
        }

        // GET: Employees/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Employee employee = db.employees.Find(id);
            if (employee == null)
            {
                return HttpNotFound();
            }
            return View(employee);
        }

        // GET: Employees/Create
        public ActionResult Create()
        {
            ViewBag.DeptId = new SelectList(db.departments, "DeptId", "DeptName");
            ViewBag.EmpId = new SelectList(db.salaries, "id", "id");
            return View();
        }

        // POST: Employees/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,DeptId,Name,DOJ,Mobile,Email,Address,salary")] Employee employee)
        {
            if (ModelState.IsValid)
            {
                db.employees.Add(employee);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.DeptId = new SelectList(db.departments, "DeptId", "DeptName", employee.DeptId);
            ViewBag.EmpId = new SelectList(db.salaries, "id", "id", employee.EmpId);
            return View(employee);
        }

        // GET: Employees/Edit/5
        public ActionResult Edit(int? EmpId)
        {
            if (EmpId == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Employee employee = db.employees.Find(EmpId);
            if (employee == null)
            {
                return HttpNotFound();
            }
            ViewBag.DeptId = new SelectList(db.departments, "DeptId", "DeptName", employee.DeptId);
            ViewBag.EmpId = new SelectList(db.salaries, "EmpId", "EmpId", employee.EmpId);
            return View(employee);
        }

        // POST: Employees/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "EmpId,DeptId,Name,DOJ,Mobile,Email,Address,salary")] Employee employee)
        {
            if (ModelState.IsValid)
            {
                employee.salary.EmpId = employee.EmpId;
                db.Entry(employee).State = EntityState.Modified;
                db.Entry(employee.salary).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.DeptId = new SelectList(db.departments, "DeptId", "DeptName", employee.DeptId);
            ViewBag.EmpId = new SelectList(db.salaries, "id", "id", employee.EmpId);
            return View(employee);
        }

        // GET: Employees/Delete/5
        public ActionResult Delete(int ? EmpId)
        {
            if (EmpId == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Employee employee = db.employees.Find(EmpId);
            if (employee == null)
            {
                return HttpNotFound();
            }
            return View(employee);
        }

        // POST: Employees/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int EmpId)
        {
            Employee employee = db.employees.Find(EmpId);
            Salary salary = db.salaries.Find(EmpId);
            db.salaries.Remove(salary);
            db.employees.Remove(employee);
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
