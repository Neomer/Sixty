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
            TeamInfoViewModel model = null;
            var user = Sixty.Helpers.AppContext.Instance.CurrentUser(User.Identity);
            if (user == null)
            {
                throw new Exception(TR.T("Ошибка доступа!"));
            }
            if (user.Team != null)
            {
                model = new TeamInfoViewModel(user.Team);
            }
            return View(model);
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
            var user = Sixty.Helpers.AppContext.Instance.CurrentUser(User.Identity);
            if (user == null)
            {
                throw new Exception(TR.T("Ошибка доступа!"));
            }
            if (user.Team != null)
            {
                return RedirectToAction("Index", "Team");
            }
            var team = new Team()
            {
                Id = Guid.NewGuid(),
                Name = model.Name
            };
            var manager = ManagerProvider.Instance.Get<Team>();
            if (manager == null)
            {
                throw new Exception(TR.T("Менеджер для сущности %1 не зарегистрирован в системе!", "Division"));
            }
            try
            {
                var tr = NHibernateHelper.Instance.BeginTransaction();
                manager.SaveEntity(team);
                user.Team = team;
                manager.UpdateEntity(user);
                NHibernateHelper.Instance.Commit(tr);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("Error", TR.T("Не удалось создать команду! %1", ex.Message));
            }
            return View(model);
        }

    }
}