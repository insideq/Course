using Microsoft.AspNetCore.Mvc;
using UniversityContracts.BindingModels;
using UniversityContracts.BusinessLogicsContracts;
using UniversityContracts.SearchModels;
using UniversityContracts.ViewModels;

namespace UniversityRestApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class PlanOfStudysController : Controller
    {
        private readonly ILogger _logger;
        private readonly IPlanOfStudyLogic _logic;
        public PlanOfStudysController(IPlanOfStudyLogic logic, ILogger<PlanOfStudysController> logger)
        {
            _logic = logic;
            _logger = logger;
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
        [HttpPut]
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
        [HttpDelete]
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
