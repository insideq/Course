using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Reflection.Metadata;
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
			if (APIStorekeeper.Client == null)
			{
				return Redirect("~/Home/Enter");
			}
			//return View(APIStorekeeper.GetRequest<List<OrderViewModel>>($"api/main/getorders?clientId={APIClient.Client.Id}"));
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

        [HttpGet]
        public IActionResult Disciplines()
        {
            if (APIStorekeeper.Client == null)
            {
                return Redirect("~/Home/Enter");
            }
            ViewBag.Teachers = APIStorekeeper.GetRequest<List<TeacherViewModel>>($"api/teacher/getteachers?userId={APIStorekeeper.Client.Id}");
            return View(APIStorekeeper.GetRequest<List<DisciplineViewModel>>($"api/discipline/getdisciplines?teacherId={0}"));
        }
        [HttpPost]
        public void Disciplines(string name, string description, DateOnly date, int teacher)
        {
            if (APIStorekeeper.Client == null)
            {
                Redirect("~/Home/Enter");
            }
            APIStorekeeper.PostRequest("api/discipline/creatediscipline", new DisciplineBindingModel
            {
                UserId = APIStorekeeper.Client.Id,
                Name = name,
                Description = description,
                Date = date,
                TeacherId = teacher,
            });
            Response.Redirect("Disciplines");
        }

        [HttpGet]
        public IActionResult Statements()
        {
            if (APIStorekeeper.Client == null)
            {
                return Redirect("~/Home/Enter");
            }
            ViewBag.Teachers = APIStorekeeper.GetRequest<List<TeacherViewModel>>($"api/teacher/getteachers?userId={APIStorekeeper.Client.Id}");
            return View(APIStorekeeper.GetRequest<List<StatementViewModel>>($"api/statement/getstatements?teacherId={0}"));
        }
        [HttpPost]
        public void Statements(string name, DateTime date, int teacher)
        {
            if (APIStorekeeper.Client == null)
            {
                Redirect("~/Home/Enter");
            }
            APIStorekeeper.PostRequest("api/statement/createstatement", new StatementBindingModel
            {
                UserId = APIStorekeeper.Client.Id,
                Name = name,
                Date = date,
                TeacherId = teacher,
            });
            Response.Redirect("Statements");
        }

        [HttpGet]
        public IActionResult Teachers()
		{
            if (APIStorekeeper.Client == null)
            {
                return Redirect("~/Home/Enter");
            }
            //ViewBag.Documents = APIStorekeeper.GetRequest<List<DisciplineViewModel>>("api/main/getdiscipline");
            return View(APIStorekeeper.GetRequest<List<TeacherViewModel>>($"api/teacher/getteachers?userId={APIStorekeeper.Client.Id}"));
        }
        [HttpPost]
        public void Teachers(string name, string position, string academicDegree)
        {
            if (APIStorekeeper.Client == null)
            {
                Redirect("~/Home/Enter");
            }
            APIStorekeeper.PostRequest("api/teacher/createteacher", new TeacherBindingModel
            {
                UserId = APIStorekeeper.Client.Id,
                Name = name,
                Position = position,
                AcademicDegree = academicDegree
            });
            Response.Redirect("Teachers");
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
