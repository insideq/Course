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
    public class Statement : IStatementModel
    {
        public int Id { get; private set; }
        [Required]
        public int TeacherId { get; private set; }
        [Required]
        public string Name { get; private set; } = string.Empty;
        [Required]
        public DateTime Date { get; private set; }
        public virtual Teacher Teacher { get; set; } = new ();
        public static Statement? Create(StatementBindingModel model)
        {
            if (model == null)
            {
                return null;
            }
            return new Statement()
            {
                Id = model.Id,
                TeacherId = model.TeacherId,
                Name = model.Name,
                Date = model.Date,
            };
        }
        public static Statement Create(StatementViewModel model)
        {
            return new Statement()
            {
                Id = model.Id,
                TeacherId = model.TeacherId,
                Name = model.Name,
                Date = model.Date,
            };
        }
        public void Update(StatementBindingModel model)
        {
            if (model == null)
            {
                return;
            }
            Id = model.Id;
            TeacherId = model.Id;
            Name = model.Name;
            Date = model.Date;
        }
        public StatementViewModel GetViewModel => new()
        {
            Id = Id,
            TeacherId = TeacherId,
            Name = Name,
            Date = Date,
        };
    }
}
