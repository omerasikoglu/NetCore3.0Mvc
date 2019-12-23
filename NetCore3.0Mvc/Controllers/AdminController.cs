using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NetCore3._0Mvc.helper;

namespace NetCore3._0Mvc.Controllers
{
    public class AdminController : Controller
    {
        // push github deneme
        public IActionResult Index()
        {
            string userName = HttpContext.Session.GetString(MySessionHelper.SESSION_USER_NAME);

            ViewData["UserName"] = userName;
            return View();
        }
    }
}