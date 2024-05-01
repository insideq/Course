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
        void SaveDisciplinesToWord(ReportBindingModel option);

        void SaveDisciplinesToExcel(ReportBindingModel option);

        void SendAccountsToEmail(ReportDateRangeBindingModel option, string email);
        void SaveClientsToWord(ReportBindingModel option);

        void SaveClientsToExcel(ReportBindingModel option);

        void SendDisciplinesToEmail(ReportDateRangeBindingModel option, string email);
    }
}
