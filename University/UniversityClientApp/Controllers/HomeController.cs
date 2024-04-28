using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using UniversityClientApp.Models;

namespace UniversityClientApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

		public IActionResult Enter()
		{
			return View();
		}

        public IActionResult Disciplines()
        {
            return View();
        }

        public IActionResult Statements()
        {
            return View();
        }

		public IActionResult Teachers()
		{
			return View();
		}

		public IActionResult Report() { 
            return View();
        }

		public IActionResult Register()
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
