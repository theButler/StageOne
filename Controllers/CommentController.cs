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
    public class CommentController : Controller
    {
        private UserCommentDBContext db = new UserCommentDBContext();

        //
        // GET: /Comment/

        public ViewResult Index()
        {
            return View(db.UserComments.ToList());
        }

        //
        // GET: /Comment/Details/5

        public ViewResult Details(int id)
        {
            UserComment usercomment = db.UserComments.Find(id);
            return View(usercomment);
        }

        //
        // GET: /Comment/Create

        public ActionResult Create()
        {
            return View();
        } 

        //
        // POST: /Comment/Create

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
        // GET: /Comment/Edit/5
 
        public ActionResult Edit(int id)
        {
            UserComment usercomment = db.UserComments.Find(id);
            return View(usercomment);
        }

        //
        // POST: /Comment/Edit/5

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
        // GET: /Comment/Delete/5
 
        public ActionResult Delete(int id)
        {
            UserComment usercomment = db.UserComments.Find(id);
            return View(usercomment);
        }

        //
        // POST: /Comment/Delete/5

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