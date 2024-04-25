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
    public class WorkerStorage : IWorkerStorage
    {
        public WorkerViewModel? GetElement(WorkerSearchModel model)
        {
            if (string.IsNullOrEmpty(model.Email) && !model.Id.HasValue)
            {
                return null;
            }
            using var context = new UniversityDatabase();

            return context.Workers.FirstOrDefault(x =>
            (!string.IsNullOrEmpty(model.Email) && x.Email == model.Email)
            || (model.Id.HasValue && x.Id == model.Id))?.GetViewModel;
        }

        public List<WorkerViewModel> GetFilteredList(WorkerSearchModel model)
        {
            if (string.IsNullOrEmpty(model.Email))
            {
                return new();
            }
            using var context = new UniversityDatabase();
            return context.Workers
            .Where(x => x.Email.Contains(model.Email))
            .Select(x => x.GetViewModel)
            .ToList();
        }

        public List<WorkerViewModel> GetFullList()
        {
            using var context = new UniversityDatabase();
            return context.Workers.Select(x => x.GetViewModel).ToList();
        }

        public WorkerViewModel? Insert(WorkerBindingModel model)
        {
            var newWorker = Worker.Create(model);
            if (newWorker == null)
            {
                return null;
            }
            using var context = new UniversityDatabase();
            context.Workers.Add(newWorker);
            context.SaveChanges();
            return newWorker.GetViewModel;
        }

        public WorkerViewModel? Update(WorkerBindingModel model)
        {
            using var context = new UniversityDatabase();
            var client = context.Workers.FirstOrDefault(x => x.Id == model.Id);
            if (client == null)
            {
                return null;
            }
            client.Update(model);
            context.SaveChanges();
            return client.GetViewModel;
        }
        public WorkerViewModel? Delete(WorkerBindingModel model)
        {
            using var context = new UniversityDatabase();
            var client = context.Workers.FirstOrDefault(x => x.Id == model.Id);
            if (client == null)
            {
                return null;
            }
            context.Workers.Remove(client);
            context.SaveChanges();
            return client.GetViewModel;
        }
    }
}
