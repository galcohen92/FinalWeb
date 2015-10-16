using RecipeSite.DAL;
using RecipeSite.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RecipeSite.Controllers
{
    [RequireHttps]
    public class HomeController : Controller
    {
        ApplicationDbContext db = new ApplicationDbContext();
        
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            //ViewBag.Message = "Your contact page.";

            //IList<ApplicationUser> users = new List<ApplicationUser>();
            //var query = from r in db.Recipes
            //            join u in db.Users on r.userId equals u.Id
            //            orderby r.likeAmount descending
            //            select u.UserName;
            ////var UserRole = db.Users.Join(db.Roles, u => u.Id, r => r, new UserRoleView() { UserID = item.Id, Email = item.Email, Role = item.Role, UserName = item.Name });
            //foreach (var item in query.ToList().Distinct().Take(5))
            //{
            //    users.Add(new ApplicationUser(){UserName = item});
            //}


            IList<ApplicationUser> users = new List<ApplicationUser>();

            var query = from r in db.Recipes
                        group r by r.userId into m
                        orderby m.Count() descending
                        join u in db.Users on m.Key equals u.Id
                        select u.UserName;
            //var UserRole = db.Users.Join(db.Roles, u => u.Id, r => r, new UserRoleView() { UserID = item.Id, Email = item.Email, Role = item.Role, UserName = item.Name });
            foreach (var item in query.ToList().Distinct().Take(5))
            {
                users.Add(new ApplicationUser() { UserName = item });
            }

            return View(users.ToList());
        }
    }
}