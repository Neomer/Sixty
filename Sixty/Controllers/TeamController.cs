using Sixty.Helpers;
using Sixty.Managers;
using Sixty.Models;
using Sixty.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Sixty.Controllers
{
    public class TeamController : Controller
    {
        // GET: Team
        [Authorize]
        public ActionResult Index()
        {
            return View();
        }

        [Authorize]
        [HttpGet]
        public ActionResult Find()
        {
            return View();
        }

        [Authorize]
        [HttpGet]
        public ActionResult Create()
        {
            if (Sixty.Helpers.AppContext.Instance.CurrentUser(User.Identity).Team != null)
            {
                return RedirectToAction("Index", "Team");
            }

            var model = new TeamCreationViewModel();
            var divisionManager = ManagerProvider.Instance.Get<Division>() as DivisionManager;
            if (divisionManager == null)
            {
                throw new Exception(TR.T("Менеджер для сущности %1 не зарегистрирован в системе!", "Division"));
            }
            model.AvailableDivisions = divisionManager.GetAvailableForNewbee();
            return View(model);
        }

        [Authorize]
        [HttpPost]
        public ActionResult Create(TeamCreationViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            if (Sixty.Helpers.AppContext.Instance.CurrentUser(User.Identity).Team != null)
            {
                return RedirectToAction("Index", "Team");
            }

            return View(model);
        }

    }
}