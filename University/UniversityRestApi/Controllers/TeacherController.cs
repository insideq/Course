using Microsoft.AspNetCore.Mvc;
using UniversityContracts.BindingModels;
using UniversityContracts.BusinessLogicsContracts;
using UniversityContracts.SearchModels;
using UniversityContracts.ViewModels;

namespace UniversityRestApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class TeacherController : Controller
    {
        private readonly ILogger _logger;
        private readonly ITeacherLogic _logic;
        public TeacherController(ITeacherLogic logic, ILogger<TeacherController> logger)
        {
            _logic = logic;
            _logger = logger;
        }
        [HttpGet]
        public List<TeacherViewModel>? GetTeachers(int userId)
        {
            try
            {
                return _logic.ReadList(new TeacherSearchModel { UserId = userId });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Ошибка получения списка преподавателей пользователя id={Id}", userId);
                throw;
            }
        }
        [HttpPost]
        public void CreateTeacher(TeacherBindingModel model)
        {
            try
            {
                _logic.Create(model);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Ошибка создания преподавателя");
                throw;
            }
        }
        [HttpPut]
        public void UpdateTeacher(TeacherBindingModel model)
        {
            try
            {
                _logic.Update(model);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Ошибка обновления преподавателя");
                throw;
            }
        }
        [HttpDelete]
        public void DeleteTeacher(TeacherBindingModel model)
        {
            try
            {
                _logic.Delete(model);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Ошибка удаления преподавателя");
                throw;
            }
        }
    }
}
