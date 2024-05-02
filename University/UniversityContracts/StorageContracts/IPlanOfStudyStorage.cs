using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniversityContracts.BindingModels;
using UniversityContracts.SearchModels;
using UniversityContracts.ViewModels;

namespace UniversityContracts.StorageContracts
{
    public interface IPlanOfStudyStorage
    {
        List<PlanOfStudyViewModel> GetFullList();
        List<PlanOfStudyViewModel> GetFilteredList(PlanOfStudySearchModel model);
        PlanOfStudyViewModel? GetElement(PlanOfStudySearchModel model);
        PlanOfStudyViewModel? Insert(PlanOfStudyBindingModel model);
        PlanOfStudyViewModel? Update(PlanOfStudyBindingModel model);
        PlanOfStudyViewModel? Delete(PlanOfStudyBindingModel model);
    }
}
