using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using UniversityClientAppWorker.Models;
using UniversityDataModels.Enums;

namespace UniversityClientAppWorker.Controllers
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

        public IActionResult Attestations()
        {
            ViewBag.AttestationScore = Enum.GetValues(typeof(AttestationScore)).Cast<AttestationScore>();
            return View();
        }

        public IActionResult Students()
        {
            return View();
        }

        public IActionResult PlanOfStudys()
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
