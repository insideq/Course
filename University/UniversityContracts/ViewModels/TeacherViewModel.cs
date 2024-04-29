using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniversityDataModels.Models;

namespace UniversityContracts.ViewModels
{
    public class TeacherViewModel : ITeacherModel
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int StorekeeperId { get; set; }
        [DisplayName("ФИО")]
        public string Name { get; set; } = string.Empty;
        [DisplayName("Учёная степень")]
        public string AcademicDegree { get; set; } = string.Empty;
        [DisplayName("Должность")]
        public string Position { get; set; } = string.Empty;
    }
}
