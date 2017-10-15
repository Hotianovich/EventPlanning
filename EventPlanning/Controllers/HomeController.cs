using EventPlanning.Interfaces;
using EventPlanning.Models;
using EventPlanning.Models.EntitiesModel;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace EventPlanning.Controllers
{
    public class HomeController : Controller
    {
        private IRepository<Event> _repoEvent;
        private IRepository<RegForEvent> _regForEvent;
        public HomeController(IRepository<Event> repoEvent, IRepository<RegForEvent> regForEvent)
        {
            _repoEvent = repoEvent;
            _regForEvent = regForEvent;
        }
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

        public PartialViewResult GetEvent()
        {
            var all = _repoEvent.GetAll();
            return PartialView(all);
        }

        public ActionResult ConfirmRegistration(string userId, string code, int eventId)
        {
            if (userId == null || code == null)
            {
                return View("Error");
            }

            RegForEvent regUserForEvent = new RegForEvent() { EventId = eventId, UserId = userId, RegConfirmed = true };
            _regForEvent.Create(regUserForEvent);
            return View("Index");
        }

    }
}