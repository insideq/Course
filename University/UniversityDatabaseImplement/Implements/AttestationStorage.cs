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
    public class AttestationStorage : IAttestationStorage
    {
        public List<AttestationViewModel> GetFullList()
        {
            using var context = new UniversityDatabase();

            return context.Attestations.Select(x => x.GetViewModel).ToList();
        }

        public List<AttestationViewModel> GetFilteredList(AttestationSearchModel model)
        {
            using var context = new UniversityDatabase();
            if (model.Id.HasValue)
            {
                return context.Attestations
                    .Include(x => x.Student)
                    .Where(x => x.Id == model.Id)
                    .Select(x => x.GetViewModel)
                    .ToList();
            }
            else if (model.StudentId.HasValue)
            {
                return context.Attestations
                    .Include(x => x.Student)
                    .Where(x => x.StudentId == model.StudentId)
                    .Select(x => x.GetViewModel)
                    .ToList();
            }

            return new();
        }

        public AttestationViewModel? GetElement(AttestationSearchModel model)
        {
            if (!model.Id.HasValue)
            {
                return null;
            }
            using var context = new UniversityDatabase();
            return context.Attestations.Include(x => x.Student).FirstOrDefault(x => (model.Id.HasValue && x.Id == model.Id))?.GetViewModel;
        }

        public AttestationViewModel? Insert(AttestationBindingModel model)
        {
            using var context = new UniversityDatabase();

            var newAttestation = Attestation.Create(context, model);

            if (newAttestation == null)
            {
                return null;
            }

            context.Attestations.Add(newAttestation);
            context.SaveChanges();

            return newAttestation.GetViewModel;
        }

        public AttestationViewModel? Update(AttestationBindingModel model)
        {
            using var context = new UniversityDatabase();
            var order = context.Attestations.FirstOrDefault(x => x.Id == model.Id);
            if (order == null)
            {
                return null;
            }
            order.Update(model);
            context.SaveChanges();
            return context.Attestations.Include(x => x.Student).FirstOrDefault(x => x.Id == model.Id)?.GetViewModel;
        }
        public AttestationViewModel? Delete(AttestationBindingModel model)
        {
            using var context = new UniversityDatabase();
            var element = context.Attestations.FirstOrDefault(rec => rec.Id == model.Id);
            if (element != null)
            {
                context.Attestations.Remove(element);
                context.SaveChanges();
                return element.GetViewModel;
            }
            return null;
        }
    }
}
