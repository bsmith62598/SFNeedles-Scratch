using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using NeedlesAndScratch.DATA.EF;

namespace NeedlesAndScratch.Controllers
{
    public class StudiosController : Controller
    {
        private NeedlesAndScratchEntities db = new NeedlesAndScratchEntities();

        // GET: Studios
        public ActionResult Index()
        {
            return View(db.Studios.ToList());
        }

        #region Default CRUD
        // GET: Studios/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Studio studio = db.Studios.Find(id);
            if (studio == null)
            {
                return HttpNotFound();
            }
            return View(studio);
        }

        // GET: Studios/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Studios/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,StudioName,StudioState,StudioCity,StudioCountry,YearFounded")] Studio studio)
        {
            if (ModelState.IsValid)
            {
                db.Studios.Add(studio);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(studio);
        }

        // GET: Studios/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Studio studio = db.Studios.Find(id);
            if (studio == null)
            {
                return HttpNotFound();
            }
            return View(studio);
        }

        // POST: Studios/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,StudioName,StudioState,StudioCity,StudioCountry,YearFounded")] Studio studio)
        {
            if (ModelState.IsValid)
            {
                db.Entry(studio).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(studio);
        }

        // GET: Studios/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Studio studio = db.Studios.Find(id);
            if (studio == null)
            {
                return HttpNotFound();
            }
            return View(studio);
        }

        // POST: Studios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Studio studio = db.Studios.Find(id);
            db.Studios.Remove(studio);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        #endregion

        #region AJAX CRUD
        //AJAX DELETE
        [AcceptVerbs(HttpVerbs.Post)]
        public JsonResult AjaxDelete(int ID)
        {
            Studio studio = db.Studios.Find(ID);
            db.Studios.Remove(studio);
            db.SaveChanges();

            string confirmMessage = string.Format("Deleted Studio '{0}' from the database.", studio.StudioName);

            return Json(new { id = ID, message = confirmMessage });
        }

        //AJAX DETAILS
        [HttpGet]
        public PartialViewResult StudioDetails(int id)
        {
            Studio studio = db.Studios.Find(id);
            
            return PartialView(studio);
        }

        //AJAX CREATE
        [HttpPost]
        [ValidateAntiForgeryToken]
        public JsonResult StudioCreate(Studio studio)
        {
            db.Studios.Add(studio);
            db.SaveChanges();
            return Json(studio);
        }

        //AJAX EDIT
        [HttpGet]
        public PartialViewResult StudioEdit(int id)
        {
            Studio studio = db.Studios.Find(id);
            return PartialView(studio);
        }

        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public JsonResult AjaxEdit(Studio studio)
        {
            db.Entry(studio).State = EntityState.Modified;
            db.SaveChanges();
            return Json(studio);
        }
        #endregion

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
