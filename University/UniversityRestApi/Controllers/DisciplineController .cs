using Microsoft.AspNetCore.Mvc;
using UniversityBusinessLogic.MailWorker;
using UniversityContracts.BindingModels;
using UniversityContracts.BusinessLogicContracts;
using UniversityContracts.BusinessLogicsContracts;
using UniversityContracts.SearchModels;
using UniversityContracts.ViewModels;

namespace UniversityRestApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class DisciplineController : Controller
    {
        private readonly ILogger _logger;
        private readonly IDisciplineLogic _logic;
		private readonly IReportLogic _reportLogic;
        private readonly AbstractMailWorker _mailWorker;
        public DisciplineController(IDisciplineLogic logic, ILogger<DisciplineController> logger, IReportLogic reportLogic, AbstractMailWorker mailWorker)
        {
            _logic = logic;
            _logger = logger;
            _reportLogic = reportLogic;
            _mailWorker = mailWorker;
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
        [HttpGet]
        public List<ReportDisciplineViewModel> GetReportDisciplines(DateOnly dateFrom, DateOnly dateTo)
        {
            try
            {
                return _reportLogic.GetDisciplines(new ReportDateRangeBindingModel { DateFrom = dateFrom, DateTo = dateTo });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Ошибка получения списка дисциплин");
                throw;
            }
        }

        [HttpPost]
        public List<ReportDisciplineViewModel> GetReportDisciplines()
        {
            try
            {
                return _reportLogic.GetDisciplines(new ReportDateRangeBindingModel { DateFrom = DateOnly.MinValue, DateTo = DateOnly.MaxValue });
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


        [HttpPost]
        public void CreateReportToPDFFile(ReportDateRangeBindingModel model, DateOnly dateFrom, DateOnly dateTo)
        {
            try
            {
                System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);
                model.DateTo = dateTo;
                model.DateFrom = dateFrom;
                _reportLogic.SendDisciplinesToEmail(model);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Ошибка создания отчета");
                throw;
            }
        }
        [HttpPost]
        public void SendPDFToMail(MailSendInfoBindingModel model)
        {
            try
            {
                _mailWorker.MailSendAsync(model);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Ошибка отправки письма");
                throw;
            }
        }
    }
}

