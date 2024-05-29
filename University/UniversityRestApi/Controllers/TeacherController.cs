﻿using Microsoft.AspNetCore.Mvc;
using UniversityContracts.BindingModels;
using UniversityContracts.BusinessLogicContracts;
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
        private readonly IReportLogic _reportLogic;
        public TeacherController(ITeacherLogic logic, ILogger<TeacherController> logger, IReportLogic reportLogic)
        {
            _logic = logic;
            _logger = logger;
            _reportLogic = reportLogic;
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
		[HttpGet]
		public List<TeacherViewModel>? GetAllTeachers()
		{
			try
			{
				return _logic.ReadList(null);
			}
			catch (Exception ex)
			{
				_logger.LogError(ex, "Ошибка получения списка преподавателей");
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

        [HttpGet]
        public List<ReportTeacherViewModel>? GetTeachersReport(int userId)
        {
            try
            {
                return _reportLogic.GetTeachers(userId);
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
                _reportLogic.SaveTeachersToWord(model);
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
                _reportLogic.SaveTeachersToExcel(model);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Ошибка создания отчета");
                throw;
            }
        }
    }
}
