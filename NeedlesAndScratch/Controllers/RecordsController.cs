using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using NeedlesAndScratch.DATA.EF;
using NeedlesAndScratch.UI.Secured;
using NeedlesAndScratch.UI.Secured.Models;
using PagedList;
using PagedList.Mvc;

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

        #region Custom Add to Cart functionality (Called from the Details view)
        public ActionResult AddToCart(int qty, int recordID)
        {
            Dictionary<int, CartItemViewModel> shoppingCart = null;
            
            if (Session["cart"] != null)
            {
                shoppingCart = (Dictionary<int, CartItemViewModel>)Session["cart"];
            }
            else
            {
                shoppingCart = new Dictionary<int, CartItemViewModel>();
            }

            Record product = db.Records.Where(r => r.ID == recordID).FirstOrDefault();

            if (product == null)
            {
                return RedirectToAction("Index");
            }
            else
            {
                CartItemViewModel item = new CartItemViewModel(qty, product);
                
                if (shoppingCart.ContainsKey(product.ID))
                {
                    shoppingCart[product.ID].Qty += qty;
                }
                else
                {
                    shoppingCart.Add(product.ID, item);
                }
                

                Session["cart"] = shoppingCart;
                
            }

            return RedirectToAction("Index", "ShoppingCart");
        }
        #endregion

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
        public ActionResult Create([Bind(Include = "ID,RecordName,Tracks,Length,YearRecorded,RecordCover,StockStatus,GenreID,BandID,StudioID")] Record record, HttpPostedFileBase recordCover)
        {
            if (ModelState.IsValid)
            {
                #region File Upload

                //Default image if one isn't provided
                string file = "NoImage.png";
                //Check if the user uploaded an image
                if (recordCover != null)
                {
                    //Preserve the file name for the image
                    file = recordCover.FileName;
                    //Isolate the extention
                    string ext = file.Substring(file.LastIndexOf('.'));
                    //Create an array of good extensions
                    string[] goodExts = { ".jpeg", ".jpg", ".png", ".gif" };

                    //Check taht the uploaded file extension is in our list of extensions and check taht the file size <= 4MB max imposed by ASP.net
                    if (goodExts.Contains(ext.ToLower()) && recordCover.ContentLength <= 4194304)
                    {
                        //Create a new file name (using a GUID)
                        file = Guid.NewGuid() + ext;
                        

                        #region Resize Image                        string savePath = Server.MapPath("~/Content/Images/RecordCovers/");                        Image convertedImage = Image.FromStream(recordCover.InputStream);                        int maxImageSize = 500;                        int maxThumbSize = 100;                        ImageUtility.ResizeImage(savePath, file, convertedImage, maxImageSize, maxThumbSize);                        #endregion

                    }

                    //No matter what, update the image url with the vile of the file variable
                    record.RecordCover = file;
                }

                #endregion

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
        public ActionResult Edit([Bind(Include = "ID,RecordName,Tracks,Length,YearRecorded,RecordCover,StockStatus,GenreID,BandID,StudioID")] Record record, HttpPostedFileBase recordCover)
        {
            if (ModelState.IsValid)
            {

                #region File Upload

                //Default image if one isn't provided
                string file = "NoImage.png";
                //Check if the user uploaded an image
                if (recordCover != null)
                {
                    //Preserve the file name for the image
                    file = recordCover.FileName;
                    //Isolate the extention
                    string ext = file.Substring(file.LastIndexOf('.'));
                    //Create an array of good extensions
                    string[] goodExts = { ".jpeg", ".jpg", ".png", ".gif" };

                    //Check taht the uploaded file extension is in our list of extensions and check taht the file size <= 4MB max imposed by ASP.net
                    if (goodExts.Contains(ext.ToLower()) && recordCover.ContentLength <= 4194304)
                    {
                        //Create a new file name (using a GUID)
                        file = Guid.NewGuid() + ext;




                        #region Resize Image
                        string savePath = Server.MapPath("~/Content/Images/RecordCovers/");                        Image convertedImage = Image.FromStream(recordCover.InputStream);                        int maxImageSize = 500;                        int maxThumbSize = 100;                        ImageUtility.ResizeImage(savePath, file, convertedImage, maxImageSize, maxThumbSize);                        #endregion

                    }

                    //No matter what, update the image url with the vile of the file variable
                    record.RecordCover = file;
                }

                #endregion

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
