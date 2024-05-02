using Microsoft.AspNetCore.Mvc;
using UniversityContracts.BindingModels;
using UniversityContracts.BusinessLogicsContracts;
using UniversityContracts.SearchModels;
using UniversityContracts.ViewModels;

namespace UniversityRestApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class DisciplinesController : Controller
    {
        private readonly ILogger _logger;
        private readonly IDisciplineLogic _logic;
        public DisciplinesController(IDisciplineLogic logic, ILogger<DisciplinesController> logger)
        {
            _logic = logic;
            _logger = logger;
        }
        [HttpGet]
        public List<DisciplineViewModel>? GetDisciplines(int userId)
        {
            try
            {
                return _logic.ReadList(new DisciplineSearchModel { UserId = userId });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Ошибка получения списка дисциплин");
                throw;
            }
        }
        [HttpPost]
        public void CreateDiscipline(DisciplineBindingModel model)
        {
            try
            {
                _logic.Create(model);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Ошибка создания дисциплины");
                throw;
            }
        }
        [HttpPut]
        public void UpdateDiscipline(DisciplineBindingModel model)
        {
            try
            {
                _logic.Update(model);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Ошибка обновления дисциплины");
                throw;
            }
        }
        [HttpDelete]
        public void DeleteDiscipline(DisciplineBindingModel model)
        {
            try
            {
                _logic.Delete(model);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Ошибка удаления дисциплины");
                throw;
            }
        }
    }
}

