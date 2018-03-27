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
            CreateTeam();   

            return View();
        }

        private void CreateUser()
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
        }

        private void CreateTeam()
        {
            var userManager = ManagerProvider.Instance.Get<User>() as UserManager;
            if (userManager == null)
            {
                throw new Exception("Менеджер сущности User н езарегистрирован в системе!");
            }
            var user = userManager.GetById(Guid.Parse("988367A5-ACEC-4FD4-BF6A-9963080E7FE4")) as User;

            var userList = new List<User>();
            userList.Add(user);

            var team = new Team()
            {
                Id = Guid.NewGuid(),
                Name = "Команда чемпионов",
                Division = TeamDivision.A,
                Users = userList
            };
            var teamManager = ManagerProvider.Instance.Get<Team>() as UserManager;
            if (teamManager == null)
            {
                throw new Exception("Менеджер сущности User н езарегистрирован в системе!");
            }
            teamManager.CreateEntity(team);

        }
    }
}