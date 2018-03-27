using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Sixty.Models;
using Sixty.Managers;

namespace Sixty.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            var user = new User()
            {
                Id = Guid.NewGuid(),
                Email = "vin.kirill@gmail.com",
                Password = "",
                LastVisitDate = null,
                Name = "Администратор",
                Surname = "",
                BirthDate = DateTime.Parse("1753-01-01"),
                RegistrationDate = DateTime.Now.Date
            };

            var userManager = ManagerProvider.Instance.Get<User>() as UserManager;
            if (userManager == null)
            {
                throw new Exception("Менеджер сущности User н езарегистрирован в системе!");
            }
            userManager.CreateEntity(user);

            return View();
        }
    }
}