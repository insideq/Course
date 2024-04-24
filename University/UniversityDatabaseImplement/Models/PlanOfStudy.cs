﻿using System;
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
    public class PlanOfStudy : IPlanOfStudyModel
    {
        public int Id { get; private set; }
        public int WorkerId { get; private set; }
        [Required]
        public string Profile { get; private set; } = string.Empty;
        [Required]
        public string FormOfStudy { get; private set; } = string.Empty;
        private Dictionary<int, ITeacherModel>? _planOfStudyTeachers = null;
        [NotMapped]
        public Dictionary<int, ITeacherModel> PlanOfStudyTeachers
        {
            get
            {
                if (_planOfStudyTeachers == null)
                {
                    _planOfStudyTeachers = Teachers
                    .ToDictionary(recPC => recPC.TeacherId, recPC => recPC.Teacher as ITeacherModel);
                }
                return _planOfStudyTeachers;
            }
        }
        [ForeignKey("PlanOfStudyId")]
        public virtual List<PlanOfStudyTeacher> Teachers { get; set; } = new();
        public virtual Worker Worker { get; set; } = new();
        public static PlanOfStudy Create(UniversityDatabase context, PlanOfStudyBindingModel model)
        {
            return new PlanOfStudy()
            {
                Id = model.Id,
                WorkerId = model.WorkerId,
                Profile = model.Profile,
                FormOfStudy = model.FormOfStudy,
                Teachers = model.PlanOfStudyTeachers.Select(x => new
                    PlanOfStudyTeacher
                {
                    Teacher = context.Teachers.First(y => y.Id == x.Key)
                }).ToList()
            };
        }
        public void Update(PlanOfStudyBindingModel model)
        {
            if (model == null)
            {
                return;
            }
            Id = model.Id;
            WorkerId = model.WorkerId;
            Profile = model.Profile;
            FormOfStudy = model.FormOfStudy;
        }
        public void UpdateTeachers(UniversityDatabase context,
            PlanOfStudyBindingModel model)
        {
            var planOfStudyTeachers = context.PlanOfStudyTeachers
                .Where(rec => rec.PlanOfStudyId == model.Id).ToList();
            if (planOfStudyTeachers != null && planOfStudyTeachers.Count > 0)
            { // удалили те, которых нет в модели
                context.PlanOfStudyTeachers.RemoveRange(planOfStudyTeachers.Where(rec
               => !model.PlanOfStudyTeachers.ContainsKey(rec.TeacherId)));
                context.SaveChanges();
                // обновили количество у существующих записей
                foreach (var updateTeacher in planOfStudyTeachers)
                {
                    model.PlanOfStudyTeachers.Remove(updateTeacher.TeacherId);
                }
                context.SaveChanges();
            }
            var planOfStudy = context.PlanOfStudys.First(x => x.Id == Id);
            foreach (var pc in model.PlanOfStudyTeachers)
            {
                context.PlanOfStudyTeachers.Add(new PlanOfStudyTeacher
                {
                    PlanOfStudy = planOfStudy,
                    Teacher = context.Teachers.First(x => x.Id == pc.Key)
                });
                context.SaveChanges();
            }
            _planOfStudyTeachers = null;
        }
        public PlanOfStudyViewModel GetViewModel => new()
        {
            Id = Id,
            WorkerId = WorkerId,
            Profile = Profile,
            FormOfStudy = FormOfStudy,
            PlanOfStudyTeachers = PlanOfStudyTeachers,
        };
    }
}
