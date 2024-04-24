using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniversityContracts.BindingModels;
using UniversityContracts.ViewModels;
using UniversityDataModels.Enums;
using UniversityDataModels.Models;
using static System.Formats.Asn1.AsnWriter;

namespace UniversityDatabaseImplement.Models
{
    public class Attestation : IAttestationModel
    {
        public int Id { get; private set; }
        public int StudentId { get; private set; }
        [Required]
        public string FormOfEvaluation { get; private set; } = string.Empty;
        [Required]
        public AttestationScore Score { get; private set; } = AttestationScore.Неявка;
        public virtual Student Student { get; set; } = new();
        public static Attestation? Create(AttestationBindingModel model)
        {
            if (model == null)
            {
                return null;
            }
            return new Attestation()
            {
                Id = model.Id,
                StudentId = model.StudentId,
                FormOfEvaluation = model.FormOfEvaluation,
                Score = model.Score
            };
        }
        public static Attestation Create(AttestationViewModel model)
        {
            return new Attestation
            {
                Id = model.Id,
                StudentId = model.StudentId,
                FormOfEvaluation = model.FormOfEvaluation,
                Score = model.Score
            };
        }
        public void Update(AttestationBindingModel model)
        {
            if (model == null)
            {
                return;
            }
            StudentId = model.StudentId;
            FormOfEvaluation = model.FormOfEvaluation;
            Score = model.Score;
        }
        public AttestationViewModel GetViewModel => new()
        {
            Id = Id,
            StudentId = StudentId,
            FormOfEvaluation = FormOfEvaluation,
            Score = Score
        };
    }
}
