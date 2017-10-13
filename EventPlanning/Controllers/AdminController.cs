using EventPlanning.Interfaces;
using EventPlanning.Models.EntitiesModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EventPlanning.Controllers
{
    [Authorize(Roles = "admin")]
    public class AdminController : Controller
    {
        private IRepository<Event> _repoEvent;
        public AdminController(IRepository<Event> repoEvent)
        {
            _repoEvent = repoEvent;
        }
        public ActionResult AddEvent()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddEvent(Event model)
        {
            if (ModelState.IsValid)
            {
                _repoEvent.Create(model);
                ViewBag.AddEvent = "Событие добавлено!!! Перейдите на главную страницу";
                ModelState.Clear();
                return View();
            }
            return View(model);
        }
    }
}
