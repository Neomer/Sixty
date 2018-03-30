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

    }
}