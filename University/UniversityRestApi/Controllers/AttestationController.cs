using Microsoft.AspNetCore.Mvc;
using UniversityContracts.BindingModels;
using UniversityContracts.BusinessLogicsContracts;
using UniversityContracts.SearchModels;
using UniversityContracts.ViewModels;
using UniversityDataModels.Enums;

namespace UniversityRestApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class AttestationController : Controller
    {
        private readonly ILogger _logger;
        private readonly IAttestationLogic _logic;
        public AttestationController(IAttestationLogic logic, ILogger<AttestationController> logger)
        {
            _logic = logic;
            _logger = logger;
        }

        [HttpGet]
        public List<AttestationViewModel>? GetAttestations(int studentId)
        {
            try
            {
                return _logic.ReadList(new AttestationSearchModel { StudentId = studentId });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Ошибка получения аттестаций студента id={Id}", studentId);
                throw;
            }
        }
        [HttpPost]
        public void CreateAttestation(AttestationBindingModel model)
        {
            try
            {
                _logic.CreateAttestation(model);
            } catch (Exception ex)
            {
                _logger.LogError(ex, "Ошибка создания аттестации");
                throw;
            }
        }
        [HttpPut]
        public void UpdateAttestation(AttestationBindingModel model)
        {
            try
            {
                _logic.UpdateAttestation(model);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Ошибка обновления аттестации");
                throw;
            }
        }
        [HttpDelete]
        public void DeleteAttestation(AttestationBindingModel model)
        {
            try
            {
                _logic.DeleteAttestation(model);
            }
            catch(Exception ex)
            {
                _logger.LogError(ex, "Ошибка удаления аттестации");
                throw;
            }
        }
    }
}
