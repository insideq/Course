using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniversityContracts.BindingModels;
using UniversityContracts.ViewModels;
using UniversityDataModels.Models;

namespace UniversityDatabaseImplement.Models
{
    public class Worker : IWorkerModel
    {
        public int Id { get; private set; }
        [Required]
        public string FirstName { get; private set; } = string.Empty;
        [Required]
        public string LastName { get; private set; } = string.Empty;
        [Required]
        public string MiddleName { get; private set; } = string.Empty;
        [Required]
        public string PhoneNumber { get; private set; } = string.Empty;
        [Required]
        public string Email { get; private set; } = string.Empty;
        [ForeignKey("WorkerId")]
        public virtual List<PlanOfStudy> PlanOfStudys { get; set; } = new();
        public static Worker? Create(WorkerBindingModel model)
        {
            if (model == null)
            {
                return null;
            }
            return new Worker()
            {
                Id = model.Id,
                FirstName = model.FirstName,
                LastName = model.LastName,
                MiddleName = model.MiddleName,
                PhoneNumber = model.PhoneNumber,
                Email = model.Email,

            };
        }
        public static Worker Create(WorkerViewModel model)
        {
            return new Worker
            {
                Id = model.Id,
                FirstName = model.FirstName,
                LastName = model.LastName,
                MiddleName = model.MiddleName,
                PhoneNumber = model.PhoneNumber,
                Email = model.Email,
            };
        }
        public void Update(WorkerBindingModel model)
        {
            if (model == null)
            {
                return;
            }
            Id = model.Id;
            FirstName = model.FirstName;
            LastName = model.LastName;
            MiddleName = model.MiddleName;
            PhoneNumber = model.PhoneNumber;
            Email = model.Email;
        }
        public WorkerViewModel GetViewModel => new()
        {
            Id = Id,
            FirstName = FirstName,
            LastName = LastName,
            MiddleName = MiddleName,
            PhoneNumber = PhoneNumber,
            Email = Email,
        };
    }
}
