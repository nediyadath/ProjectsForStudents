using MVCExample.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity.Migrations;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCExample.Controllers
{
    public class CategoriesController : Controller
    {
        CRUD cr = new CRUD();
        EcomContext ec = new EcomContext();
        // GET: Categories
        public ActionResult Index()
        {
            //DataTable dt = cr.FetchCategories();
            //List<Category> clist = new List<Category>();
            //foreach (DataRow drow in dt.Rows)
            //{
            //    Category c = new Category()
            //    {
            //        id = int.Parse(drow["id"].ToString()),
            //        name = drow["name"].ToString()
            //    };
            //    clist.Add(c);
            //}
            return View(ec.categories.ToList());
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Category c)
        {
            //TempData["msg"] = cr.InsertRec(c);
            ec.categories.Add(c);
            ec.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Edit(int id)
        {
            //DataTable dt = cr.FetchCategoryById(id);
            //Category c = new Category()
            //{
            //    id = int.Parse(dt.Rows[0]["id"].ToString()),
            //    name = dt.Rows[0]["name"].ToString()

            //};
            return View(ec.categories.Find(id));
        }
        [HttpPost]
        public ActionResult Edit(Category c)
        {
            //TempData["msg"] = cr.Edit(c);
            //ec.Entry(c).State= System.Data.Entity.EntityState.Modified;
            ec.categories.AddOrUpdate(c);
            ec.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Delete(int id)
        {
            //DataTable dt = cr.FetchCategoryById(id);
            //Category c = new Category()
            //{
            //    id = int.Parse(dt.Rows[0]["id"].ToString()),
            //    name = dt.Rows[0]["name"].ToString()

            //};
            return View(ec.categories.Find(id));

        }

        [HttpPost]
        [ActionName("Delete")]
        public ActionResult DeletePost(int id)
        {
            //TempData["msg"]=cr.Delete(id);
            Category c = ec.categories.Find(id);
            ec.categories.Remove(c);
            return RedirectToAction("Index");
        }
    }
}