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
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddEvent(Event model)
        {
            if (ModelState.IsValid)
            {
                _repoEvent.Create(model);
                ModelState.Clear();
                return PartialView(model);
            }
            return RedirectToAction("Index");
        }

        public JsonResult ValidateDate(string DateEvent)
        {
            DateTime parsedDate;

            if (DateTime.TryParse(DateEvent, out parsedDate))
            {
                if (DateTime.Now > parsedDate)
                {
                    return Json("Старая дата", JsonRequestBehavior.AllowGet);
                }
                else
                {
                    return Json(true, JsonRequestBehavior.AllowGet);
                }
            }
            return Json("Ошибка", JsonRequestBehavior.AllowGet);
        }
    }
}
