using DataFirstApprochEF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DataFirstApprochEF.Controllers
{
    public class HomeController : Controller
    {
        DataBaseFirstApproachEFEntities db = new DataBaseFirstApproachEFEntities();
        // GET: Home
        public ActionResult Index()
        {
            var data = db.Employees.ToList();
            return View(data);
        }

        public ActionResult Create()
        {

            return View();
        }
        [HttpPost]
        public ActionResult Create(Employee s)
        {
            if (ModelState.IsValid == true)
            {

                db.Employees.Add(s);
                int a = db.SaveChanges();
                if (a > 0)
                {
                    TempData["InsertMessage"] = "<script>alert('Inserted !!')</script>";
                    return RedirectToAction("Index");

                }

                else
                {
                    TempData["InsertMessage"] = "<script>alert('Not Inserted !!')</script>";


                }

            }
            return View();
        }

        public ActionResult Edit(int id)
        {
            var row = db.Employees.Where(model => model.Id == id).FirstOrDefault();
            return View(row);

        }
        [HttpPost]
        public ActionResult Edit(Employee s)
        {
            if (ModelState.IsValid == true)
            {
                db.Entry(s).State = System.Data.Entity.EntityState.Modified;
                int a = db.SaveChanges();
                if (a > 0)
                {
                    TempData["UpdatedMessage"] = "<script>alert('Updated !!')</script>";
                    return RedirectToAction("Index");

                }
                else
                {
                    TempData["UpdatedMessage"] = "<script>alert('Not Updated !!')</script>";
                }

            }
            return View();
        }

        public ActionResult Delete(int id)
        {
            var DeletedRow = db.Employees.Where(model => model.Id == id).FirstOrDefault();
            return View(DeletedRow);
        }
        [HttpPost]
        public ActionResult Delete(Employee s)
        {
            db.Entry(s).State = System.Data.Entity.EntityState.Deleted;
            int a = db.SaveChanges();
            if (a > 0)

            {
                TempData["DeletedMessage"] = "<script>alert('Deleted')</script>";
                return RedirectToAction("Index");

            }
            else
            {
                TempData["DeletedMessage"] = "<script>alert(' Not Deleted')</script>";
            }
            return View();

        }

        public ActionResult Details(int id)
        {
            var row = db.Employees.Where(model => model.Id == id).FirstOrDefault();
            return View(row);
        }

    }
}
