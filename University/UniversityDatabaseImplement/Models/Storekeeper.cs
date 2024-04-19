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
    public class Storekeeper : IStorekeeperModel
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
        [ForeignKey("StorekeeperId")]
        public virtual List<Teacher> Teachers { get; set; } = new();
        public static Storekeeper? Create(StorekeeperBindingModel model)
        {
            if (model == null)
            {
                return null;
            }
            return new Storekeeper()
            {
                Id = model.Id,
                FirstName = model.FirstName,
                LastName = model.LastName,
                MiddleName = model.MiddleName,
                PhoneNumber = model.PhoneNumber,
                Email = model.Email,

            };
        }
        public static Storekeeper Create(StorekeeperViewModel model)
        {
            return new Storekeeper
            {
                Id = model.Id,
                FirstName = model.FirstName,
                LastName = model.LastName,
                MiddleName = model.MiddleName,
                PhoneNumber = model.PhoneNumber,
                Email = model.Email,
            };
        }
        public void Update(StorekeeperBindingModel model)
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
        public StorekeeperViewModel GetViewModel => new()
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
