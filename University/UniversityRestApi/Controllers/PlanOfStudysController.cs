using Microsoft.AspNetCore.Mvc;
using UniversityContracts.BindingModels;
using UniversityContracts.BusinessLogicContracts;
using UniversityContracts.BusinessLogicsContracts;
using UniversityContracts.SearchModels;
using UniversityContracts.ViewModels;
using UniversityDatabaseImplement.Models;

namespace UniversityRestApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class PlanOfStudysController : Controller
    {
        private readonly ILogger _logger;
        private readonly IPlanOfStudyLogic _logic;
        private readonly IReportLogic _reportLogic;
        public PlanOfStudysController(IPlanOfStudyLogic logic, ILogger<PlanOfStudysController> logger, IReportLogic reportLogic)
        {
            _logic = logic;
            _logger = logger;
            _reportLogic = reportLogic;
        }
        [HttpGet]
        public List<PlanOfStudyViewModel>? GetPlanOfStudys(int userId)
        {
            try
            {
                return _logic.ReadList(new PlanOfStudySearchModel { UserId = userId });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Ошибка получения списка планов обучения");
                throw;
            }
        }
		[HttpGet]
		public PlanOfStudyViewModel? GetPlanOfStudy(int id, int userId)
		{
			try
			{
				return _logic.ReadElement(new PlanOfStudySearchModel { Id = id, UserId = userId });
			}
			catch (Exception ex)
			{
				_logger.LogError(ex, "Ошибка получения списка планов обучения");
				throw;
			}
		}
        [HttpGet]
        public List<ReportPlanOfStudyViewModel>? GetPlanOfStudyAndDisciplines(int userId)
        {
            try
            {
                return _reportLogic.GetPlanOfStudyAndDisciplines(userId);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Ошибка получения списка планов обучения");
                throw;
            }
        }
        [HttpPost]
        public void LoadReportToWord(ReportBindingModel model)
        {
            try
            {
                _reportLogic.SavePlanOfStudyToWord(model);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Ошибка создания отчета");
                throw;
            }
        }
        [HttpPost]
        public void LoadReportToExcel(ReportBindingModel model)
        {
            try
            {
                _reportLogic.SavePlanOfStudyToExcel(model);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Ошибка создания отчета");
                throw;
            }
        }
        [HttpPost]
        public void CreatePlanOfStudy(PlanOfStudyBindingModel model)
        {
            try
            {
                _logic.Create(model);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Ошибка создания плана обучения");
                throw;
            }
        }
        [HttpPost]
        public void UpdatePlanOfStudy(PlanOfStudyBindingModel model)
        {
            try
            {
                _logic.Update(model);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Ошибка обновления плана обучения");
                throw;
            }
        }
        [HttpPost]
        public void DeletePlanOfStudy(PlanOfStudyBindingModel model)
        {
            try
            {
                _logic.Delete(model);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Ошибка удаления плана обучения");
                throw;
            }
        }
	}
}
