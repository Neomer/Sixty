using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Sixty.ViewModels;
using Sixty.Managers;
using Sixty.Models;
using Sixty.Helpers;
using System.Web.Security;

namespace Sixty.Controllers
{
    public class AccountController : Controller
    {
        // GET: Account
        [HttpGet]
        public ActionResult Index()
        {
            if (User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Index", "Home");
            }
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(SignInViewModel model)
        {
            if (ModelState.IsValid)
            {
                var manager = ManagerProvider.Instance.Get<User>() as UserManager;
                var user = manager.GetByEmailPassword(model.Email, model.Password);
                if (user == null)
                {
                    ModelState.AddModelError("Password", TR.T("Пользователь с указанными данными не найден!"));
                    return View(model);
                }
                FormsAuthentication.SetAuthCookie(user.Id.ToString(), true);
                return RedirectToAction("Index", "Home");
            }
            return View(model);
        }

    }
}