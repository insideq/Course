using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniversityContracts.BindingModels;
using UniversityContracts.ViewModels;
using UniversityDataModels.Models;

namespace UniversityDatabaseImplement.Models
{
    public class Discipline : IDisciplineModel
    {
        public int Id { get; private set; }
        [Required]
        public int TeacherId { get; private set; }
        [Required]
        public string Name { get; private set; } = string.Empty;
        [Required]
        public string Description { get; private set; } = string.Empty;
        public virtual Teacher Teacher { get; set; } = new();
        [ForeignKey("DisciplineId")]
        public virtual List<StudentDiscipline> StudentDiscipline { get; set; } = new();
        public static Discipline? Create(DisciplineBindingModel model)
        {
            if (model == null)
            {
                return null;
            }
            return new Discipline()
            {
                Id = model.Id,
                TeacherId = model.TeacherId,
                Name = model.Name,
                Description = model.Description,
            };
        }
        public static Discipline Create(DisciplineViewModel model)
        {
            return new Discipline()
            {
                Id = model.Id,
                TeacherId = model.TeacherId,
                Name = model.Name,
                Description = model.Description,
            };
        }
        public void Update(DisciplineBindingModel model)
        {
            if (model == null)
            {
                return;
            }
            Id = model.Id;
            TeacherId = model.TeacherId;
            Name = model.Name;
            Description = model.Description;
        }
        public DisciplineViewModel GetViewModel => new()
        {
            Id = Id,
            TeacherId = TeacherId,
            Name = Name,
            Description = Description,
        };
    }
}
