using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniversityContracts.BindingModels;
using UniversityContracts.SearchModels;
using UniversityContracts.StorageContracts;
using UniversityContracts.ViewModels;
using UniversityDatabaseImplement.Models;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace UniversityDatabaseImplement.Implements
{
    public class StudentStorage : IStudentStorage
    {
        public List<StudentViewModel> GetFullList()
        {
            using var context = new UniversityDatabase();

            return context.Students.Select(x => x.GetViewModel).ToList();
        }

        public List<StudentViewModel> GetFilteredList(StudentSearchModel model)
        {
            if (string.IsNullOrEmpty(model.Name))
            {
                return new();
            }

            using var context = new UniversityDatabase();

            return context.Students
                .Include(x => x.User)
                .Where(x => x.Name
                .Contains(model.Name))
                .Select(x => x.GetViewModel)
                .ToList();
        }

        public StudentViewModel? GetElement(StudentSearchModel model)
        {
            if (string.IsNullOrEmpty(model.Name) && !model.Id.HasValue)
            {
                return null;
            }

            using var context = new UniversityDatabase();

            return context.Students.FirstOrDefault(x => (!string.IsNullOrEmpty(model.Name) 
                && x.Name == model.Name) || (model.Id.HasValue && x.Id == model.Id))?.GetViewModel;
        }

        public StudentViewModel? Insert(StudentBindingModel model)
        {
            using var context = new UniversityDatabase();

            var newStudent = Student.Create(context, model);

            if (newStudent == null)
            {
                return null;
            }

            context.Students.Add(newStudent);
            context.SaveChanges();

            return newStudent.GetViewModel;
        }

        public StudentViewModel? Update(StudentBindingModel model)
        {
            using var context = new UniversityDatabase();

            var student = context.Students.FirstOrDefault(x => x.Id == model.Id);

            if (student == null)
            {
                return null;
            }

            student.Update(model);
            context.SaveChanges();

            return student.GetViewModel;
        }

        public StudentViewModel? Delete(StudentBindingModel model)
        {
            using var context = new UniversityDatabase();

            var element = context.Students.FirstOrDefault(rec => rec.Id == model.Id);

            if (element != null)
            {
                context.Students.Remove(element);
                context.SaveChanges();
                return element.GetViewModel;
            }

            return null;
        }
    }
}
