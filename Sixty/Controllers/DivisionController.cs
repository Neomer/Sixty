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
        // GET: Division
        public ActionResult Index()
        {
            var manager = ManagerProvider.Instance.Get<Division>();
            if (manager == null)
            {
                throw new Exception(TR.T("Менеджер для сущности %1 не зарегистрирован в системе!", "Division"));
            }
            return View(manager.GetAll());
        }
    }
}