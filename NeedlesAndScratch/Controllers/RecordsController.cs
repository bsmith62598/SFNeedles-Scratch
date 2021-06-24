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
    public class RecordsController : Controller
    {
        private NeedlesAndScratchEntities db = new NeedlesAndScratchEntities();

        // GET: Records
        public ActionResult Index()
        {
            var records = db.Records.Include(r => r.Band).Include(r => r.Genre).Include(r => r.StockStatu).Include(r => r.Studio);
            return View(records.ToList());
        }

        // GET: Records/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Record record = db.Records.Find(id);
            if (record == null)
            {
                return HttpNotFound();
            }
            return View(record);
        }

        // GET: Records/Create
        public ActionResult Create()
        {
            ViewBag.BandID = new SelectList(db.Bands, "ID", "BandName");
            ViewBag.GenreID = new SelectList(db.Genres, "ID", "GenreName");
            ViewBag.StockStatus = new SelectList(db.StockStatus, "ID", "Status");
            ViewBag.StudioID = new SelectList(db.Studios, "ID", "StudioName");
            return View();
        }

        // POST: Records/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,RecordName,Tracks,Length,YearRecorded,RecordCover,StockStatus,GenreID,BandID,StudioID")] Record record)
        {
            if (ModelState.IsValid)
            {
                db.Records.Add(record);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.BandID = new SelectList(db.Bands, "ID", "BandName", record.BandID);
            ViewBag.GenreID = new SelectList(db.Genres, "ID", "GenreName", record.GenreID);
            ViewBag.StockStatus = new SelectList(db.StockStatus, "ID", "Status", record.StockStatus);
            ViewBag.StudioID = new SelectList(db.Studios, "ID", "StudioName", record.StudioID);
            return View(record);
        }

        // GET: Records/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Record record = db.Records.Find(id);
            if (record == null)
            {
                return HttpNotFound();
            }
            ViewBag.BandID = new SelectList(db.Bands, "ID", "BandName", record.BandID);
            ViewBag.GenreID = new SelectList(db.Genres, "ID", "GenreName", record.GenreID);
            ViewBag.StockStatus = new SelectList(db.StockStatus, "ID", "Status", record.StockStatus);
            ViewBag.StudioID = new SelectList(db.Studios, "ID", "StudioName", record.StudioID);
            return View(record);
        }

        // POST: Records/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,RecordName,Tracks,Length,YearRecorded,RecordCover,StockStatus,GenreID,BandID,StudioID")] Record record)
        {
            if (ModelState.IsValid)
            {
                db.Entry(record).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.BandID = new SelectList(db.Bands, "ID", "BandName", record.BandID);
            ViewBag.GenreID = new SelectList(db.Genres, "ID", "GenreName", record.GenreID);
            ViewBag.StockStatus = new SelectList(db.StockStatus, "ID", "Status", record.StockStatus);
            ViewBag.StudioID = new SelectList(db.Studios, "ID", "StudioName", record.StudioID);
            return View(record);
        }

        // GET: Records/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Record record = db.Records.Find(id);
            if (record == null)
            {
                return HttpNotFound();
            }
            return View(record);
        }

        // POST: Records/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Record record = db.Records.Find(id);
            db.Records.Remove(record);
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
