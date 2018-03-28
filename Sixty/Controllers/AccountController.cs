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
            if (User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Index", "Home");
            }
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

        [HttpGet]
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();

            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Register()
        {
            if (User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Index", "Home");
            }
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register(RegistrationViewModel model)
        {
            if (User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Index", "Home");
            }

            if (ModelState.IsValid)
            {
                var manager = ManagerProvider.Instance.Get<User>();
                var user = new Models.User()
                {
                    RegistrationDate = DateTime.Now,
                    Email = model.Email,
                    Password = model.Password
                };
                try
                {
                    manager.CreateEntity(user);
                }
                catch (Exception)
                {
                    ModelState.AddModelError("PasswordRetype", TR.T("Не удалось создать пользователя! Возможно, указанная электронная почта уже используется в системе."));
                    return View(model);
                }
                FormsAuthentication.SetAuthCookie(user.Id.ToString(), true);
                return RedirectToAction("Index", "Home");
            }
            return View();
        }
    }
}