using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using University.ViewModels;
using UniversityContracts.BindingModels;
using UniversityContracts.ViewModels;

namespace UniversityContracts.BusinessLogicContracts
{
    public interface IReportLogic
    {
        /// <summary>
        /// Часть кладовщика
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        List<ReportTeacherViewModel> GetTeachers();
        List<ReportDisciplineViewModel> GetDisciplines(ReportBindingModel model);
        List<ReportPlanOfStudyViewModel> GetPlanOfStudyAndDisciplines();
        List<ReportPlanOfStudyAndStudentViewModel> GetPlanOfStudyAndStudents(ReportDateRangeBindingModel model);

		void SaveTeachersToWord(ReportBindingModel option);
        void SavePlanOfStudyToWord(ReportBindingModel option);
		void SaveTeachersToExcel(ReportBindingModel option);
        void SavePlanOfStudyToExcel(ReportBindingModel option);
		void SendDisciplinesToEmail(ReportDateRangeBindingModel option, string email);
        public void SendPlanOfStudyToEmail(ReportDateRangeBindingModel option, string email);

	}
}
