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

        public JsonResult ValidateNamberOfParticipants(string NamderOfParticipants)
        {
            int parsedInt;

            if (Int32.TryParse(NamderOfParticipants, out parsedInt))
            {
                if (parsedInt < 0)
                {
                    return Json("Отрицательное число", JsonRequestBehavior.AllowGet);
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
