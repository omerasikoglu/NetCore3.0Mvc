using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using NetCore3._0Mvc.helper;
using NetCore3._0Mvc.Models;

namespace NetCore3._0Mvc.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private GamesContext gameContext;

       
        public HomeController(ILogger<HomeController> logger, GamesContext _context)
        {
            _logger = logger;
            gameContext = _context;
        }

        public async Task<IActionResult> Index()
        {
            
            var gameList = gameContext.GamesTable.ToListAsync();

            return View(await gameList);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
