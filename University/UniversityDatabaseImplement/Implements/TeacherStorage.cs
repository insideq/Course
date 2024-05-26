using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniversityContracts.BindingModels;
using UniversityContracts.SearchModels;
using UniversityContracts.StorageContracts;
using UniversityContracts.ViewModels;
using UniversityDatabaseImplement.Models;

namespace UniversityDatabaseImplement.Implements
{
    public class TeacherStorage: ITeacherStorage
    {
        public List<TeacherViewModel> GetFullList()
        {
            using var context = new UniversityDatabase();
            return context.Teachers
            .Select(x => x.GetViewModel)
           .ToList();
        }
        public List<TeacherViewModel> GetFilteredList(TeacherSearchModel model)
        {
            using var context = new UniversityDatabase();
            if (!string.IsNullOrEmpty(model.Name) || !string.IsNullOrEmpty(model.AcademicDegree) || !string.IsNullOrEmpty(model.Position))
            {
                return context.Teachers
            .Where(x => x.Name.Contains(model.Name))
            .Where(x => x.Position.Contains(model.Position))
            .Where(x => x.AcademicDegree.Contains(model.AcademicDegree))
            .Include(x => x.User)
           .Select(x => x.GetViewModel)
           .ToList();
            }
            else { return context.Teachers.Include(x => x.User).Select(x => x.GetViewModel)
           .ToList();
            }

            return new();

        }
        public TeacherViewModel? GetElement(TeacherSearchModel model)
        {
            if (string.IsNullOrEmpty(model.Name) && string.IsNullOrEmpty(model.AcademicDegree) && string.IsNullOrEmpty(model.Position) && !model.Id.HasValue)
            {
                return null;
            }
            using var context = new UniversityDatabase();
            return context.Teachers
            // стоит ли проверять по Position и Degree?
            .FirstOrDefault(x => (!string.IsNullOrEmpty(model.Name) && x.Name == model.Name) ||  (model.Id.HasValue && x.Id == model.Id))?.GetViewModel;
        }
        public TeacherViewModel? Insert(TeacherBindingModel model)
        {
            var newTeacher = Teacher.Create(model);
            if (newTeacher == null)
            {
                return null;
            }
            using var context = new UniversityDatabase();
            context.Teachers.Add(newTeacher);
            context.SaveChanges();
            return newTeacher.GetViewModel;
        }
        public TeacherViewModel? Update(TeacherBindingModel model)
        {
            using var context = new UniversityDatabase();
            var component = context.Teachers.FirstOrDefault(x => x.Id == model.Id);
            if (component == null)
            {
                return null;
            }
            component.Update(model);
            context.SaveChanges();
            return component.GetViewModel;
        }
        public TeacherViewModel? Delete(TeacherBindingModel model)
        {
            using var context = new UniversityDatabase();
            var element = context.Teachers.FirstOrDefault(rec => rec.Id == model.Id);
            if (element != null)
            {
                context.Teachers.Remove(element);
                context.SaveChanges();
                return element.GetViewModel;
            }
            return null;
        }
    }
}
