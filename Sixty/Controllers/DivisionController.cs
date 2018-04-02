using Sixty.ViewModels;
using Sixty.Helpers;
using Sixty.Managers;
using Sixty.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Sixty.Controllers
{
    public class DivisionController : Controller
    {
        [Authorize]
        [HttpGet]
        public ActionResult Index()
        {
            var manager = ManagerProvider.Instance.Get<Division>();
            if (manager == null)
            {
                throw new Exception(TR.T("Менеджер для сущности %1 не зарегистрирован в системе!", "Division"));
            }
            var model = new BaseEntityEdittingViewModel()
            {
                EntityList = manager.GetAll(),
                NewElement = new Division()
            };

            return View(model);
        }

        [Authorize]
        [HttpGet]
        public ActionResult Create()
        {
            var model = new DivisionCreationViewModel();
            return View(model);
        }

        [Authorize]
        [HttpPost]
        public ActionResult Create(DivisionCreationViewModel model)
        {
            var division = new Division()
            {
                Id = Guid.NewGuid(),
                Name = model.Name,
                AvailableForNewbee = model.AvailableForNewbee,
                CurrentSeason = null
            };
            var manager = ManagerProvider.Instance.Get<Division>();
            if (manager == null)
            {
                throw new Exception(TR.T("Менеджер для сущности %1 не зарегистрирован в системе!", "Division"));
            }
            try
            {
                manager.CreateEntity(division);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("AvailableForNewbee", TR.T("Не удалось создать дивизион! %1", ex.Message));
            }

            return View(model);
        }
    }
}