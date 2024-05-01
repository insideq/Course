using AbstractLawFirmContracts.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniversityContracts.BindingModels;

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
        void SaveTeachersToWord(ReportBindingModel option);

        void SaveTeachersToExcel(ReportBindingModel option);

        void SendDisciplinesToEmail(ReportDateRangeBindingModel option, string email);
    }
}
