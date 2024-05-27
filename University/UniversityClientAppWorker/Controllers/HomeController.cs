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
                throw new Exception("¬ход только авторизованным пользовател€м");
            }
            if (string.IsNullOrEmpty(formOfStudy) || string.IsNullOrEmpty(profile))
            {
                throw new Exception("¬ведите данные профил€ и формы обучени€");
            }
            APIClient.PostRequest("api/planofstudys/createplanofstudy", new PlanOfStudyBindingModel
            {
                Profile = profile,
                FormOfStudy = formOfStudy,
                UserId = APIClient.User.Id
            });
            Response.Redirect("Index");
        }
        [HttpPost]
        public void DeletePlanOfStudy(int id)
        {
            if (id == 0)
            {
                throw new Exception("id не может быть равен 0");
            }
            APIClient.PostRequest("api/planofstudys/deleteplanofstudy", new PlanOfStudyBindingModel
            {
                Id = id
            });
            Response.Redirect("Index");
        }
        [HttpPost]
        public void UpdatePlanOfStudy(int id)
        {
            if (id == 0)
            {
                throw new Exception("id не может быть равен 0");
            }
            APIClient.PostRequest("api/planofstudys/updateplanofstudy", new PlanOfStudyBindingModel
            {
                Id = id
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
                throw new Exception("¬ход только авторизованным пользовател€м");
            }
            if (string.IsNullOrEmpty(login) || string.IsNullOrEmpty(password) || string.IsNullOrEmpty(email))
            {
                throw new Exception("¬ведите логин, пароль и почту");
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
            ViewBag.Students = APIClient.GetRequest<List<StudentViewModel>>($"api/student/getstudents?userId={APIClient.User.Id}");
            ViewBag.AttestationScore = Enum.GetValues(typeof(AttestationScore)).Cast<AttestationScore>();
            return View(APIClient.GetRequest<List<AttestationViewModel>>($"api/attestation/getattestations?userId={APIClient.User.Id}"));
        }
        [HttpPost]
        public void CreateAttestation(string formOfEvaluation, int student, AttestationScore score)
        {
            if (APIClient.User == null)
            {
                throw new Exception("¬ход только авторизованным");
            }
            if (string.IsNullOrEmpty(formOfEvaluation) || student == 0)
            {
                throw new Exception("¬ведите форму оценивани€ и выберите студента");
            }
            APIClient.PostRequest("api/attestation/createattestation", new AttestationBindingModel
            {
                UserId = APIClient.User.Id,
                FormOfEvaluation = formOfEvaluation,
                StudentId = student,
                Score = score
            });
            Response.Redirect("Attestations");
        }
        [HttpGet]
		public IActionResult Students()
        {
			if (APIClient.User == null)
			{
				return Redirect("~/Home/Enter");
			}
            ViewBag.PlanOfStudys = APIClient.GetRequest<List<PlanOfStudyViewModel>>
                ($"api/planofstudys/getplanofstudys?userId={APIClient.User.Id}");
            return View(APIClient.GetRequest<List<StudentViewModel>>($"api/student/getstudents?userId={APIClient.User.Id}"));
        }
        [HttpPost]
        public void CreateStudent(string name, int planOfStudy, string phoneNumber)
        {
            if (APIClient.User == null)
            {
                throw new Exception("¬ход только авторизованным");
            }
            if (string.IsNullOrEmpty(name) || planOfStudy == 0 || string.IsNullOrEmpty(phoneNumber))
            {
                throw new Exception("¬ведите ‘»ќ, план обучени€ и телефон");
            }
            APIClient.PostRequest("api/student/createstudent", new StudentBindingModel
            {
                UserId = APIClient.User.Id,
                Name = name,
                PlanOfStudyId = planOfStudy,
                PhoneNumber = phoneNumber,
                
            });
            Response.Redirect("Students");
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
				throw new Exception("¬ведите логин и пароль");
			}
			APIClient.User = APIClient.GetRequest<UserViewModel>($"api/user/loginworker?login={login}&password={password}");
			if (APIClient.User == null)
			{
				throw new Exception("Ќеверный логин/пароль");
			}
			Response.Redirect("Index");
		}
		[HttpPost]
        public void Register(string login, string password, string email)
        {
			if (string.IsNullOrEmpty(login) || string.IsNullOrEmpty(password) || string.IsNullOrEmpty(email))
			{
				throw new Exception("¬ведите логин, пароль и почту");
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
