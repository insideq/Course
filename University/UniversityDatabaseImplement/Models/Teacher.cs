﻿using System;
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
    public class Teacher : ITeacherModel
    {
        public int Id { get; private set; }
        [Required]
        public int StorekeeperId { get; private set; }
        [Required]
        public string Name { get; private set; } = string.Empty;
        [Required]
        public string AcademicDegree { get; private set; } = string.Empty;
        [Required]
        public string Position { get; private set; } = string.Empty;
        public virtual Storekeeper Storekeeper { get;  set; } = new ();
        [ForeignKey("TeacherId")]
        public virtual List<Statement> Statements { get; set; } = new();
        [ForeignKey("TeacherId")]
        public virtual List<Discipline> Disciplines { get; set; } = new();
        [ForeignKey("TeacherId")]
        public virtual List<PlanOfStudyTeacher> PlanOfStudyTeachers { get; set; } = new();
        public static Teacher? Create(TeacherBindingModel model)
        {
            if (model == null)
            {
                return null;
            }
            return new Teacher()
            {
                Id = model.Id,
                StorekeeperId = model.StorekeeperId,
                Name = model.Name,
                AcademicDegree = model.AcademicDegree,
                Position = model.Position,
            };
        }
        public static Teacher Create(TeacherViewModel model)
        {
            return new Teacher()
            {
                Id = model.Id,
                StorekeeperId = model.StorekeeperId,
                Name = model.Name,
                AcademicDegree = model.AcademicDegree,
                Position = model.Position,
            };
        }
        public void Update(TeacherBindingModel model)
        {
            if (model == null)
            {
                return;
            }
            Id = model.Id;
            StorekeeperId = model.StorekeeperId;
            Name = model.Name;
            AcademicDegree = model.AcademicDegree;
            Position = model.Position;
        }
        public TeacherViewModel GetViewModel => new()
        {
            Id = Id,
            StorekeeperId = StorekeeperId,
            Name = Name,
            AcademicDegree = AcademicDegree,
            Position = Position,
        };
    }
}
