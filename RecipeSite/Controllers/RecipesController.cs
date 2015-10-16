using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using RecipeSite.Models;
using RecipeSite.DAL;
using Microsoft.AspNet.Identity;

namespace RecipeSite.Controllers
{
    public class RecipesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        //[Authorize(Roles = "admin")]
        // GET: Recipes
        public ActionResult Index()
        {
            var recipes = db.Recipes;//.Include(r => r.author);
            return View(recipes.ToList());
        }

        public ActionResult IndexByCategory(int? categoryId)
        {
            var recipes = db.Categories.Find(categoryId).Recipes;
            return View("Index", recipes.ToList());
        }

        // GET: Recipes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Recipe recipe = db.Recipes.Find(id);
            //db.Entry(recipe)
            //    .Collection(x => x.Categories)
            //    .Load();

            if (recipe == null)
            {
                return HttpNotFound();
            }

            return View(recipe);
        }

        // GET: Recipes/Create
        public ActionResult Create()
        {
            ViewBag.userId = User.Identity.GetUserId();
            ViewBag.allCategories = db.Categories.ToList();
            return View();
        }

        // POST: Recipes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,userId,title,content,image,likeAmount")] Recipe recipe, HttpPostedFileBase upload, string selectedCategories)
        {
            if (ModelState.IsValid)
            {
                if (upload != null && upload.ContentLength > 0)
                {
                    string imageName = System.IO.Path.GetFileName(upload.FileName);
                    string imagePath = System.IO.Path.Combine(
                       Server.MapPath("~/Upload/Images/recipes"), imageName);
                    upload.SaveAs(imagePath);
                    recipe.image = "/Upload/Images/recipes/" + imageName;
                }
                else
                {
                    recipe.image = "/Content/images/no-image.png";
                }

                if (selectedCategories != null && !selectedCategories.Equals(""))
                {
                    string[] categoriesId = selectedCategories.Split(',');
                    recipe.Categories = new List<Category>();
                    foreach (var currentCategoryId in categoriesId)
                    {
                        var categoryToAdd = db.Categories.Find(int.Parse(currentCategoryId.ToString()));

                        db.Categories.Attach(categoryToAdd);
                        recipe.Categories.Add(categoryToAdd);
                    }
                }

                db.Recipes.Add(recipe);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.userId = new SelectList(db.Users, "ID", "firstName", recipe.userId);
            return View(recipe);
        }

        // GET: Recipes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Recipe recipe = db.Recipes.Find(id);
            if (recipe == null)
            {
                return HttpNotFound();
            }
            ViewBag.userId = new SelectList(db.Users, "ID", "firstName", recipe.userId);
            ViewBag.allCategories = db.Categories.ToList();
            string idsArr = "";
            foreach (var item in recipe.Categories)
	        {
		        idsArr += item.ID + ",";
	        }

            if (idsArr.Length > 0)
            {
                idsArr = idsArr.Remove(idsArr.Length-1);
            }
            //List<int> ids = recipe.Categories
            //                        .Select(x => x.ID)
            //                        .ToList();
            ////ViewBag.selectedIdsList = recipe.Categories
            //                        .Select(x => x.ID)
            //                        .ToList(); 
            ViewBag.selectedIdsList = idsArr.ToString();
            return View(recipe);
        }

        // POST: Recipes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,userId,title,content,image,likeAmount")] Recipe recipe)
        {
            if (ModelState.IsValid)
            {
                db.Entry(recipe).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.userId = new SelectList(db.Users, "ID", "firstName", recipe.userId);
            return View(recipe);
        }

        // GET: Recipes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Recipe recipe = db.Recipes.Find(id);
            if (recipe == null)
            {
                return HttpNotFound();
            }
            return View(recipe);
        }

        // POST: Recipes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Recipe recipe = db.Recipes.Find(id);
            db.Recipes.Remove(recipe);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        // POST: Recipes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        public ActionResult AddLike(int? id, string actionName)
        {
            Recipe recipe = db.Recipes.Find(id);
            recipe.likeAmount++;
            db.Entry(recipe).State = EntityState.Modified;
       
            db.Entry(recipe).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction(actionName, new { id = id });
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

