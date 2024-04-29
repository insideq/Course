using System;
using System.Collections.Generic;
using System.ComponentModel;
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
    public class Student : IStudentModel
    {
        public int Id { get; private set; }
        public int UserId { get; private set; }
        public int? PlanOfStudyId { get; private set; }
        [Required]
        public string Name { get; set; } = string.Empty;
        [Required]
        public string PhoneNumber { get; private set; } = string.Empty;
        [ForeignKey("StudentId")]
        public virtual List<StudentDiscipline> StudentDiscipline { get; set; } = new();
        [ForeignKey("StudentId")]
        public virtual List<Attestation> Attestations { get; set; } = new();
        public virtual PlanOfStudy PlanOfStudy { get; set; } = new();
        public virtual User User { get; set; } = new();
        public static Student? Create(UniversityDatabase context, StudentBindingModel model)
        {
            return new Student()
            {
                Id = model.Id,
                UserId = model.UserId,
                User = context.Users.First(x => x.Id == model.UserId),
                PlanOfStudyId = model.PlanOfStudyId,
                PlanOfStudy = model.PlanOfStudyId.HasValue ? context.PlanOfStudys.First(x => x.Id == model.PlanOfStudyId) : null,
                Name = model.Name,
                PhoneNumber = model.PhoneNumber
            };
        }
        public void Update(StudentBindingModel model)
        {
            if (model == null)
            {
                return;
            }
            PhoneNumber = model.PhoneNumber;
            Name = model.Name;
            PlanOfStudyId = model.PlanOfStudyId;
        }
        public StudentViewModel GetViewModel => new()
        {
            Id = Id,
            PlanOfStudyId = PlanOfStudyId,
            Name = Name,
            PhoneNumber = PhoneNumber
        };
    }
}
