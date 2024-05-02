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
    public class PlanOfStudyStorage : IPlanOfStudyStorage
    {
        public List<PlanOfStudyViewModel> GetFullList()
        {
            using var context = new UniversityDatabase();

            return context.PlanOfStudys.Select(x => x.GetViewModel).ToList();
        }

        public List<PlanOfStudyViewModel> GetFilteredList(PlanOfStudySearchModel model)
        {
            using var context = new UniversityDatabase();
            if (model.Id.HasValue)
            {
                return context.PlanOfStudys
                    .Include(x => x.Students)
                    .Where(x => x.Id == model.Id)
                    .Select(x => x.GetViewModel)
                    .ToList();
            }
            return new();
        }

        public PlanOfStudyViewModel? GetElement(PlanOfStudySearchModel model)
        {
            if (!model.Id.HasValue)
            {
                return null;
            }
            using var context = new UniversityDatabase();
            return context.PlanOfStudys.Include(x => x.Profile).FirstOrDefault(x => (model.Id.HasValue && x.Id == model.Id))?.GetViewModel;
        }

        public PlanOfStudyViewModel? Insert(PlanOfStudyBindingModel model)
        {
            using var context = new UniversityDatabase();
            var newAttestation = PlanOfStudy.Create(context, model);

            if (newAttestation == null)
            {
                return null;
            }

            context.PlanOfStudys.Add(newAttestation);
            context.SaveChanges();

            return newAttestation.GetViewModel;
        }

        public PlanOfStudyViewModel? Update(PlanOfStudyBindingModel model)
        {
            using var context = new UniversityDatabase();
            var order = context.PlanOfStudys.FirstOrDefault(x => x.Id == model.Id);
            if (order == null)
            {
                return null;
            }
            order.Update(model);
            context.SaveChanges();
            return context.PlanOfStudys.Include(x => x.Profile).FirstOrDefault(x => x.Id == model.Id)?.GetViewModel;
        }
        public PlanOfStudyViewModel? Delete(PlanOfStudyBindingModel model)
        {
            using var context = new UniversityDatabase();
            var element = context.PlanOfStudys.FirstOrDefault(rec => rec.Id == model.Id);
            if (element != null)
            {
                context.PlanOfStudys.Remove(element);
                context.SaveChanges();
                return element.GetViewModel;
            }
            return null;
        }
    }
}
