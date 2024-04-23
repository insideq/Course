using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using UniversityContracts.BindingModels;
using UniversityContracts.SearchModels;
using UniversityContracts.StorageContracts;
using UniversityContracts.ViewModels;
using UniversityDatabaseImplement.Models;

namespace UniversityDatabaseImplement.Implements
{
    public class DisciplineStorage : IDisciplineStorage
    {
        public DisciplineViewModel? Delete(DisciplineBindingModel model)
        {
            using var context = new UniversityDatabase();
            var element = context.Disciplines.Include(x => x.Students).FirstOrDefault(rec => rec.Id == model.Id);
            if (element != null)
            {
                context.Disciplines.Remove(element);
                context.SaveChanges();
                return element.GetViewModel;
            }
            return null;
        }

        public DisciplineViewModel? GetElement(DisciplineSearchModel model)
        {
            if (string.IsNullOrEmpty(model.Name) && !model.Id.HasValue)
            {
                return null;
            }
            using var context = new UniversityDatabase();
            return context.Disciplines.Include(x => x.Students).ThenInclude(x => x.Student)
            .Include(x => x.Teacher)
            .FirstOrDefault(x =>
           (!string.IsNullOrEmpty(model.Name) && x.Name == model.Name) || (model.Id.HasValue && x.Id == model.Id)) ?.GetViewModel;

        }

        public List<DisciplineViewModel> GetFilteredList(DisciplineSearchModel model)
        {
            if (string.IsNullOrEmpty(model.Name) || string.IsNullOrEmpty(model.Description))
            {
                return new();
            }
            using var context = new UniversityDatabase();
            return context.Disciplines
            .Include(x => x.Students)
            .ThenInclude(x => x.Student)
            .Where(x => x.Name.Contains(model.Name) || x.Description.Contains(model.Description)  || x.Id == model.Id || x.TeacherId == model.TeacherId)
            .Include(x => x.Teacher)
           .Select(x => x.GetViewModel)
           .ToList();
        }

        public List<DisciplineViewModel> GetFullList()
        {
            using var context = new UniversityDatabase();
            return context.Disciplines
            .Include(x => x.Students)
            .ThenInclude(x => x.Student)
            .ToList()
            .Select(x => x.GetViewModel)
           .ToList();
        }

        public DisciplineViewModel? Insert(DisciplineBindingModel model)
        {
            using var context = new UniversityDatabase();
            var newDiscipline = Discipline.Create(context, model);
            if (newDiscipline == null)
            {
                return null;
            }
            context.Disciplines.Add(newDiscipline);
            context.SaveChanges();
            return newDiscipline.GetViewModel;
        }

        public DisciplineViewModel? Update(DisciplineBindingModel model)
        {
            using var context = new UniversityDatabase();
            using var transaction = context.Database.BeginTransaction();
            try
            {
                    var discipline = context.Disciplines.FirstOrDefault(x => x.Id == model.Id);
                if (discipline == null)
                {
                    return null;
                }
                discipline.Update(model);
                context.SaveChanges();
                discipline.UpdateStudents(context, model);
                transaction.Commit();
                return discipline.GetViewModel;
            }
            catch
            {
                transaction.Rollback();
                throw;
            }
        }
    }
}
