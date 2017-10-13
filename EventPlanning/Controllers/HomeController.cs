using EventPlanning.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EventPlanning.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult NotCorrectLogin(LoginViewModel model)
        {
            return View(model);
        }

        public PartialViewResult GetName()
        {
            ApplicationDbContext context = new ApplicationDbContext();
            var n = context.Users.Where(u => u.Email.Equals(User.Identity.Name));
            var name = n.FirstOrDefault();
            ViewBag.Name = name.NickName;
            return PartialView();
        }
    }
}