using Microsoft.AspNetCore.Mvc;
using PlumbingRepairClientApp;
using System.Diagnostics;
using UniversityClientAppWorker.Models;
using UniversityContracts.BindingModels;
using UniversityContracts.ViewModels;
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
		[HttpGet]
		public IActionResult Index()
        {
            if (APIClient.User == null)
            {
                return Redirect("~/Home/Enter");
            }
            return View(APIClient.GetRequest<List<PlanOfStudyViewModel>>($"api/planofstudys/getplanofstudys?userId={APIClient.User.Id}"));
        }
        [HttpPost]
        public void CreatePlanOfStudy(string profile, string formOfStudy)
        {
            if (APIClient.User == null)
            {
                throw new Exception("Вход только авторизованным пользователям");
            }
            if (string.IsNullOrEmpty(formOfStudy) || string.IsNullOrEmpty(profile))
            {
                throw new Exception("Введите данные профиля и формы обучения");
            }
            APIClient.PostRequest("api/planofstudys/createplanofstudy", new PlanOfStudyBindingModel
            {
                Profile = profile,
                FormOfStudy = formOfStudy,
                UserId = APIClient.User.Id
            });
            Response.Redirect("Index");
        }
		[HttpGet]
		public IActionResult Privacy()
        {
			if (APIClient.User == null)
			{
				return Redirect("~/Home/Enter");
			}
			return View(APIClient.User);
        }
        [HttpPost]
        public void Privacy(string login, string password, string email)
        {
            if (APIClient.User == null)
            {
                throw new Exception("Вход только авторизованным пользователям");
            }
            if (string.IsNullOrEmpty(login) || string.IsNullOrEmpty(password) || string.IsNullOrEmpty(email))
            {
                throw new Exception("Введите логин, пароль и почту");
            }
            APIClient.PostRequest("api/user/updatedata", new UserViewModel
            {
                Id = APIClient.User.Id,
                Email = email,
                Login = login,
                Password = password
            });

            APIClient.User.Login = login;
            APIClient.User.Email = email;
            APIClient.User.Password = password;
            Response.Redirect("Index");
        }
        [HttpGet]
		public IActionResult Attestations()
        {
			if (APIClient.User == null)
			{
				return Redirect("~/Home/Enter");
			}
			ViewBag.AttestationScore = Enum.GetValues(typeof(AttestationScore)).Cast<AttestationScore>();
            return View();
        }
		[HttpGet]
		public IActionResult Students()
        {
			if (APIClient.User == null)
			{
				return Redirect("~/Home/Enter");
			}
			return View();
        }
		[HttpGet]
		public IActionResult Enter()
        {
            return View();
        }
		[HttpGet]
		public IActionResult Register()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
		[HttpPost]
		public void Enter(string login, string password)
		{
			if (string.IsNullOrEmpty(login) || string.IsNullOrEmpty(password))
			{
				throw new Exception("Введите логин и пароль");
			}
			APIClient.User = APIClient.GetRequest<UserViewModel>($"api/user/loginworker?login={login}&password={password}");
			if (APIClient.User == null)
			{
				throw new Exception("Неверный логин/пароль");
			}
			Response.Redirect("Index");
		}
		[HttpPost]
        public void Register(string login, string password, string email)
        {
			if (string.IsNullOrEmpty(login) || string.IsNullOrEmpty(password) || string.IsNullOrEmpty(email))
			{
				throw new Exception("Введите логин, пароль и почту");
			}
			APIClient.PostRequest("api/user/registerworker", new UserBindingModel
			{
				Email = email,
				Login = login,
				Password = password
			});
			Response.Redirect("Enter");
			return;
		}
	}
}
