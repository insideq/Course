using Microsoft.AspNetCore.Mvc;
using UniversityContracts.BindingModels;
using UniversityContracts.BusinessLogicsContracts;
using UniversityContracts.SearchModels;
using UniversityContracts.ViewModels;
using UniversityDatabaseImplement.Models;
using UniversityDataModels.Enums;

namespace UniversityRestApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class StatementController : Controller
    {
        private readonly ILogger _logger;
        private readonly IStatementLogic _logic;
        public StatementController(IStatementLogic logic, ILogger<StatementController> logger)
        {
            _logic = logic;
            _logger = logger;
        }

        [HttpGet]
        public List<StatementViewModel>? GetStatements(int teacherId)
        {
            try
            {
                if (teacherId == 0)
                {
                    return _logic.ReadList(null);
                }
                return _logic.ReadList(new StatementSearchModel { TeacherId = teacherId });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Ошибка получения ведомости id={Id}", teacherId);
                throw;
            }
        }


        [HttpPost]
        public void CreateStatement(StatementBindingModel model)
        {
            try
            {
                _logic.Create(model);
            } catch (Exception ex)
            {
                _logger.LogError(ex, "Ошибка создания ведомости");
                throw;
            }
        }
        [HttpPut]
        public void UpdateStatement(StatementBindingModel model)
        {
            try
            {
                _logic.Update(model);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Ошибка обновления ведомости");
                throw;
            }
        }
        [HttpDelete]
        public void DeleteStatement(StatementBindingModel model)
        {
            try
            {
                _logic.Delete(model);
            }
            catch(Exception ex)
            {
                _logger.LogError(ex, "Ошибка удаления ведомости");
                throw;
            }
        }
    }
}
