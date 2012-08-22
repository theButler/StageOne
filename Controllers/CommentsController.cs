using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using StageOne.Models;

namespace StageOne.Controllers
{ 
    public class CommentsController : Controller
    {
        private UserCommentDBContext db = new UserCommentDBContext();

        //
        // GET: /Comments/

        public ViewResult Index()
        {
            return View(db.UserComments.ToList());
        }

        //
        // GET: /Comments/Details/5

        public ViewResult Details(int id)
        {
            UserComment usercomment = db.UserComments.Find(id);
            return View(usercomment);
        }

        //
        // GET: /Comments/Create

        public ActionResult Create()
        {
            return View();
        } 

        //
        // POST: /Comments/Create

        [HttpPost]
        public ActionResult Create(UserComment usercomment)
        {
            if (ModelState.IsValid)
            {
                db.UserComments.Add(usercomment);
                db.SaveChanges();
                return RedirectToAction("Index");  
            }

            return View(usercomment);
        }
        
        //
        // GET: /Comments/Edit/5
 
        public ActionResult Edit(int id)
        {
            UserComment usercomment = db.UserComments.Find(id);
            return View(usercomment);
        }

        //
        // POST: /Comments/Edit/5

        [HttpPost]
        public ActionResult Edit(UserComment usercomment)
        {
            if (ModelState.IsValid)
            {
                db.Entry(usercomment).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(usercomment);
        }

        //
        // GET: /Comments/Delete/5
 
        public ActionResult Delete(int id)
        {
            UserComment usercomment = db.UserComments.Find(id);
            return View(usercomment);
        }

        //
        // POST: /Comments/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {            
            UserComment usercomment = db.UserComments.Find(id);
            db.UserComments.Remove(usercomment);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}