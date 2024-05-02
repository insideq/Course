using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniversityDataModels.Models;

namespace UniversityContracts.ViewModels
{
    public class DisciplineViewModel : IDisciplineModel
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int TeacherId { get; set; }
        [DisplayName("Название дисциплины")]
        public string Name { get; set; } = string.Empty;
        [DisplayName("Описание дисциплины")]
        public string Description { get; set; } = string.Empty;
        public Dictionary<int, IStudentModel> StudentDisciplines
        {
            get;
            set;
        } = new();
    }
}
