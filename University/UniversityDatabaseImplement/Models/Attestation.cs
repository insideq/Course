using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniversityContracts.BindingModels;
using UniversityContracts.ViewModels;
using UniversityDataModels.Models;

namespace UniversityDatabaseImplement.Models
{
    public class Attestation : IAttestationModel
    {
        public int Id { get; set; }
        public int StudentId { get; set; }
        [Required]
        public string FormOfEvaluation { get; private set; } = string.Empty;
        [Required]
        public string Score { get; private set; } = string.Empty;
    }
    public static Student? Create(StudentBindingModel model)
    {
        if (model == null)
        {
            return null;
        }
        return new Student()
        {
            Id = model.Id,
            PlanOfStudyId = model.PlanOfStudyId,
            Name = model.Name,
            PhoneNumber = model.PhoneNumber
        };
    }
    public static Student Create(StudentViewModel model)
    {
        return new Student
        {
            Id = model.Id,
            PlanOfStudyId = model.PlanOfStudyId,
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
