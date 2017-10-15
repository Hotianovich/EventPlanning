using EventPlanning.Interfaces;
using EventPlanning.Models;
using EventPlanning.Models.EntitiesModel;
using EventPlanning.Repository;
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
        private IRepositoryForReg<RegForEvent> _regForEvent;
        public HomeController(IRepository<Event> repoEvent, IRepositoryForReg<RegForEvent> regForEvent)
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

        public PartialViewResult CountSeats(int eventId)
        {
            
            ViewBag.Count = _regForEvent.CountReg(eventId);
            return PartialView();
        }

        public PartialViewResult DisButton(int eventId)
        {
            bool regEvent = true;
            var count = _regForEvent.CountReg(eventId);
            ApplicationDbContext context = new ApplicationDbContext();
            var users = context.Users.Where(us => us.UserName.Equals(User.Identity.Name));
            var user = users.FirstOrDefault();
            if (user != null)
            {
                regEvent = _regForEvent.Get(user.Id, eventId);
            }
           

            if (count == 0)
            {
                if (regEvent)
                    return PartialView("_RegistrationEnd");
                else
                    return PartialView("_NoReg");
            }
            else if (regEvent)
            {
                ViewBag.EvId = eventId;
                return PartialView("_RegPerson");
            }
            else
            {
                return PartialView("_NoReg");
            }

           
        }

    }
}