using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniversityContracts.BindingModel;
using UniversityContracts.SearchModels;
using UniversityContracts.ViewModels;

namespace UniversityContracts.BusinessLogicsContracts
{
    internal interface IPlanOfStudyLogic
    {
        List<PlanOfStudyViewModel>? ReadList(PlanOfStudySearchModel? model);
        PlanOfStudyViewModel? ReadElement(PlanOfStudySearchModel model);
        bool Create(PlanOfStudyBindingModel model);
        bool Update(PlanOfStudyBindingModel model);
        bool Delete(PlanOfStudyBindingModel model);
    }
}
