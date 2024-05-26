using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using UniversityClientApp.Models;
using UniversityClientAppStorekeeper;
using UniversityContracts.BindingModels;
using UniversityContracts.ViewModels;
using UniversityDataModels.Enums;

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

		[HttpGet]
		public IActionResult Enter()
		{
			return View();
		}
		[HttpPost]
		public void Enter(string login, string password)
		{
			if (string.IsNullOrEmpty(login) || string.IsNullOrEmpty(password))
			{
				throw new Exception("Введите логин и пароль");
			}
			APIStorekeeper.Client = APIStorekeeper.GetRequest<UserViewModel>($"api/user/loginstorekeeper?login={login}&password={password}");
			if (APIStorekeeper.Client == null)
			{
				throw new Exception("Неверный логин/пароль");
			}
			Response.Redirect("Index");
		}
		[HttpGet]
		public IActionResult Register()
		{
			return View();
		}
		[HttpPost]
		public void Register(string login, string password, string email)
		{
			if (string.IsNullOrEmpty(login) || string.IsNullOrEmpty(password) || string.IsNullOrEmpty(email))
			{
				throw new Exception("Введите логин, пароль и ФИО");
			}
			APIStorekeeper.PostRequest("api/user/registerstorekeeper", new UserBindingModel
			{
				Login = login,
				Email = email,
				Password = password,
				Role = UserRole.Кладовщик
			});
			Response.Redirect("Enter");
			return;
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

		[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
