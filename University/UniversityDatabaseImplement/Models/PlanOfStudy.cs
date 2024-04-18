using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniversityDataModels.Models;

namespace UniversityDatabaseImplement.Models
{
    public class PlanOfStudy : IPlanOfStudyModel
    {
        public int Id { get; set; }
        public int WorkerId { get; set; }
        [Required]
        public string Profile { get; private set; } = string.Empty;
        [Required]
        public string FormOfStudy { get; private set; } = string.Empty;
    }
}
