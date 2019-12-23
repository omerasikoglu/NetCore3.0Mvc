using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NetCore3._0Mvc.helper;
using NetCore3._0Mvc.Models;

namespace NetCore3._0Mvc.Controllers
{
    public class LoginController : Controller
    {
        private GamesContext context;

        public LoginController(GamesContext _context)
        {
            context = _context;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult CheckUser(string name,string password)
        {
            var user = context.UserTable.Where(x => x.Name == name).FirstOrDefault();
            if (user != null)
            {
                if (user.Password == password && user.IsAdmin)
                {
                    HttpContext.Session.SetString(MySessionHelper.SESSION_USER_NAME, user.Name);
                    HttpContext.Session.SetString(MySessionHelper.SESSION_USER_AGE, user.Age.ToString());
                    HttpContext.Session.SetString(MySessionHelper.SESSION_USER_MAIL, user.Mail);

                    return RedirectToAction("Index", "Admin");

                }
            }

            return RedirectToAction("Index","Home");
        }

        public async Task<IActionResult> SaveUserAsync(string username, string email,string password)
        {

            var user = context.UserTable.Where(x => x.Name == username).FirstOrDefault();
            if (user == null)
            {
                User newUser = new User();
                newUser.Name = username;
                newUser.Mail = email;
                newUser.Password = password;

                context.UserTable.Add(newUser);
                await context.SaveChangesAsync();

            }
            return RedirectToAction("Index", "Home");
        }
    }
}