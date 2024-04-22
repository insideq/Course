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
using UniversityDataModels.Models;

namespace UniversityDatabaseImplement.Implements
{
    public class StorekeeperStorage: IStorekeeperStorage
    {
        public StorekeeperViewModel? GetElement(StorekeeperSearchModel model)
        {
            if (string.IsNullOrEmpty(model.Email) && !model.Id.HasValue)
            {
                return null;
            }
            using var context = new UniversityDatabase();
            return context.Storekeepers.FirstOrDefault(x =>
            (!string.IsNullOrEmpty(model.Email) && x.Email == model.Email)
            || (model.Id.HasValue && x.Id == model.Id))?.GetViewModel;
        }

        public List<StorekeeperViewModel> GetFilteredList(StorekeeperSearchModel model)
        {
            if (string.IsNullOrEmpty(model.Email))
            {
                return new();
            }
            using var context = new UniversityDatabase();
            return context.Storekeepers
            .Where(x => x.Email.Contains(model.Email))
            .Select(x => x.GetViewModel)
            .ToList();
        }

        public List<StorekeeperViewModel> GetFullList()
        {
            using var context = new UniversityDatabase();
            return context.Storekeepers.Select(x => x.GetViewModel).ToList();
        }

        public StorekeeperViewModel? Insert(StorekeeperBindingModel model)
        {
            var newStorekeeper = Storekeeper.Create(model);
            if (newStorekeeper == null)
            {
                return null;
            }
            using var context = new UniversityDatabase();
            context.Storekeepers.Add(newStorekeeper);
            context.SaveChanges();
            return newStorekeeper.GetViewModel;
        }

        public StorekeeperViewModel? Update(StorekeeperBindingModel model)
        {
            using var context = new UniversityDatabase();
            var client = context.Storekeepers.FirstOrDefault(x => x.Id == model.Id);
            if (client == null)
            {
                return null;
            }
            client.Update(model);
            context.SaveChanges();
            return client.GetViewModel;
        }
        public StorekeeperViewModel? Delete(StorekeeperBindingModel model)
        {
            using var context = new UniversityDatabase();
            var client = context.Storekeepers.FirstOrDefault(x => x.Id == model.Id);
            if (client == null)
            {
                return null;
            }
            context.Storekeepers.Remove(client);
            context.SaveChanges();
            return client.GetViewModel;
        }
    }
}
