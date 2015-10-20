using RecipeSite.DAL;
using RecipeSite.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RecipeSite.Controllers
{
    [RequireHttps]
    public class HomeController : Controller
    {
        static ApplicationDbContext db = new ApplicationDbContext();
        
        public ActionResult Index()
        {
            return View();
        }

        public static MultiSelectList GetDropDown()
        {
            var categories = new ArrayList();
            categories.Add(new
            {
                CategoryID = -1,
                CategoryName = "All"
            });
            
            categories.AddRange(db.Categories.Select(c => new
            {
                CategoryID = c.ID,
                CategoryName = c.name
            }).ToList());

          
            return new MultiSelectList(categories, "CategoryID", "CategoryName");
        }

        // TODO - make with category object
        public ActionResult Search(string recipeTitle, int[] categories, string userName)
        {
            var recipes = from m in db.Recipes
                         select m;

            if (!String.IsNullOrEmpty(recipeTitle))
            {
                recipes = recipes.Where(s => s.title.Contains(recipeTitle));
            }

            if (!String.IsNullOrEmpty(userName))
            {
                recipes = recipes.Where(s => s.author.UserName.Contains(userName));
            }

            List<Recipe> recipesList = new List<Recipe>();

            if (categories.Count() > 0 )
            {
                if (categories[0] == -1)
                {
                    recipesList.AddRange(recipes.ToList());
                }
                else
                {
                    foreach (int id in categories)
                    {
                        var temp = recipes.Where(x => x.Categories.Any(y => y.ID == id));
                        recipesList.AddRange(temp.ToList());
                    }
                }
           }

            return View("../Recipes/Index", recipesList.ToList());
        }

        public ActionResult About()
        {
            return View();
        }

        [ChildActionOnly]
        public ActionResult Aside()
        {

            IList<ApplicationUser> users = new List<ApplicationUser>();

            // join and groupBy of users and recipes tables - Get the top 5 users with the highes num of recipes in the sites. The query also group by the user id in order to count the recipes for every user
            var query = from r in db.Recipes
                        group r by r.userId into m
                        join u in db.Users on m.Key equals u.Id
                        orderby m.Count() descending
                        select u.UserName;

            foreach (var item in query.ToList().Distinct().Take(5))
            {
                users.Add(new ApplicationUser() { UserName = item });
            }

            return View(users.ToList());
        }

        public ActionResult Contact()
        {
            return View();   
        }
    }
}