using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniversityDataModels.Models;

namespace UniversityContracts.ViewModels
{
    public class PlanOfStudyViewModel : IPlanOfStudyModel
    {
        public int Id { get; set; }
        public int WorkerId { get; set; }
        [DisplayName("Профиль")]
        public string Profile { get; set; } = string.Empty;
        [DisplayName("Форма обучения")]
        public string FormOfStudy { get; set; } = string.Empty;
        public Dictionary<int, ITeacherModel> PlanOfStudyTeachers
        {
            get;
            set;
        } = new();
    }
}
