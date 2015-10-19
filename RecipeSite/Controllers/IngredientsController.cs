using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using RecipeSite.DAL;
using RecipeSite.Models;
using System.Text;
using System.Web.Script.Serialization;
using Microsoft.AspNet.Identity;

namespace RecipeSite.Controllers
{
    public class IngredientsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Ingredients
        public ActionResult Index(string userId)
        {
            if (userId != null)
            {
                var ingredients = db.Ingredients.Where(r => r.userId.Equals(userId));
                return View(ingredients.ToList());
            }
            else
            {
                var ingredients = db.Ingredients;
                return View(ingredients.ToList());
            }
        }

        [HttpGet]
        public ActionResult Search(string name)
        {
            string ApiUrl = "https://api.nutritionix.com/v1_1/search/" + name + "?fields="
            + "item_name%2Cnf_calories%2Cnf_total_fat&appId=" + Globals.APP_ID + "&appKey=" + Globals.APP_KEY;
            //using (var client = new WebClient())
            //{
            //    client.Headers[HttpRequestHeader.ContentType] = "application/json";
            //    byte[] data = Encoding.Default.GetBytes(name);
            //    byte[] result = client.UploadData(ApiUrl, "GET", data);
            //    return Content(Encoding.Default.GetString(result), "application/json");
            //}

            System.Net.WebRequest req = System.Net.WebRequest.Create(ApiUrl);
            //req.Proxy = new System.Net.WebProxy(ProxyString, true); //true means no proxy
            System.Net.WebResponse resp = req.GetResponse();
            System.IO.StreamReader sr = new System.IO.StreamReader(resp.GetResponseStream());
            string response = sr.ReadToEnd().Trim();
            JavaScriptSerializer js = new JavaScriptSerializer();

            var d = js.Deserialize<dynamic>(response);

            Ingredient i;
                try{
                    i = new Ingredient() { Name = d["hits"][0]["fields"]["item_name"], Calories = d["hits"][0]["fields"]["nf_calories"], Fat = d["hits"][0]["fields"]["nf_total_fat"] };
                }
            catch
                {
                    i = new Ingredient();
                }

                

            //using (var client = new HttpClient())
            //{
            //    client.BaseAddress = new Uri("http://localhost:9000/");
            //    client.DefaultRequestHeaders.Accept.Clear();
            //    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            //    // New code:
            //    HttpResponseMessage response = await client.GetAsync("api/products/1");
            //    if (response.IsSuccessStatusCode)
            //    {
            //        Product product = await response.Content.ReadAsAsync>Product>();
            //        Console.WriteLine("{0}\t${1}\t{2}", product.Name, product.Price, product.Category);
            //    }
            //}
            return RedirectToAction("RefreshCreate", new { name = i.Name, calories = i.Calories, fat = i.Fat });
            //return RedirectToAction("Create", new {ingredient = i });
        }

        // GET: Ingredients/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ingredient ingredient = db.Ingredients.Find(id);
            if (ingredient == null)
            {
                return HttpNotFound();
            }
            return View(ingredient);
        }

        // GET: Ingredients/Create
        public ActionResult Create()
        {
            ViewBag.userId = User.Identity.GetUserId();
            return View();
        }


        [ActionName("RefreshCreate")]
        [HttpGet]
        // GET: Ingredients/Create
        public ActionResult Create(string name, decimal calories, decimal fat)
        {
            if(name == null)
            {
                ViewBag.Error = "Product not found";
            }

            ViewBag.userId = User.Identity.GetUserId();
            return View("Create", new Ingredient() { Name = name, Calories = calories, Fat = fat });
        }

        // POST: Ingredients/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,userId,name,calories,fat")] Ingredient ingredient)
        {

            if (ModelState.IsValid)
            {
                db.Ingredients.Add(ingredient);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(ingredient);
        }

        // GET: Ingredients/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ingredient ingredient = db.Ingredients.Find(id);
            if (ingredient == null)
            {
                return HttpNotFound();
            }
            return View(ingredient);
        }

        // POST: Ingredients/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,userId,name,calories,fat")] Ingredient ingredient)
        {
            if (ModelState.IsValid)
            {
                db.Entry(ingredient).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(ingredient);
        }

        // GET: Ingredients/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ingredient ingredient = db.Ingredients.Find(id);
            if (ingredient == null)
            {
                return HttpNotFound();
            }
            return View(ingredient);
        }

        // POST: Ingredients/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Ingredient ingredient = db.Ingredients.Find(id);
            db.Ingredients.Remove(ingredient);
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