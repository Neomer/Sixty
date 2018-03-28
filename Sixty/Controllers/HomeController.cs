using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Sixty.Models;
using Sixty.Managers;
using Sixty.Helpers;
using Sixty.ViewModels;
using Sixty.Models;

namespace Sixty.Controllers
{
    public class HomeController : Controller
    {
        [Authorize]
        public ActionResult Index()
        {

            return View();
        }

        [Authorize]
        [HttpGet]
        public new ActionResult Profile()
        {
            User user = null;
            try
            {
                user = AppContext.Instance.CurrentUser(Guid.Parse(User.Identity.Name));
            }
            catch (Exception)
            {
                return RedirectToAction("Logout", "Account");
            }
            var profile = new UserProfileViewModel(user);
            return View(profile);
        }
    }
}