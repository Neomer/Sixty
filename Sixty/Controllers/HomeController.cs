using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Sixty.Models;
using Sixty.Managers;
using Sixty.Helpers;
using Sixty.ViewModels;

namespace Sixty.Controllers
{
    public class HomeController : Controller
    {
        [Authorize]
        public ActionResult Index()
        {
            User user = null;
            try
            {
                user = AppContext.Instance.CurrentUser(this);
            }
            catch (Exception)
            {
                return RedirectToAction("Logout", "Account");
            }

            if (string.IsNullOrEmpty(user.Name))
            {
                return RedirectToAction("Profile");
            }

            return View();
        }

        [Authorize]
        [HttpGet]
        public new ActionResult Profile()
        {
            User user = null;
            try
            {
                user = AppContext.Instance.CurrentUser(this);
            }
            catch (Exception)
            {
                return RedirectToAction("Logout", "Account");
            }
            var profile = new UserProfileViewModel(user);
            return View(profile);
        }

        [Authorize]
        [HttpPost]
        public new ActionResult Profile(UserProfileViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            User user = null;
            try
            {
                user = AppContext.Instance.CurrentUser(this);
            }
            catch (Exception)
            {
                return RedirectToAction("Logout", "Account");
            }
            user.BirthDate = model.BirthDate;
            user.Name = model.Name;
            user.Surname = model.Surname;

            var manager = ManagerProvider.Instance.
                Get<User>();

            if (manager == null)
            {
                throw new Exception(TR.T("Менеджер для сущности %1 не зарегистрирован в системе!", "User"));
            }

            try
            {
                manager.CreateEntity(user);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("Photo", TR.T("Не удалось обновить данные профиля! %1", ex.Message));
            }
            return RedirectToAction("Index");
        }

    }
}