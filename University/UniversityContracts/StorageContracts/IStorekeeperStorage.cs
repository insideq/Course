using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniversityContracts.BindingModels;
using UniversityContracts.SearchModels;
using UniversityContracts.ViewModels;

namespace UniversityContracts.StorageContracts
{
    public interface IStorekeeperStorage
    {
        List<StorekeeperViewModel> GetFullList();
        List<StorekeeperViewModel> GetFilteredList(StorekeeperSearchModel model);
        StorekeeperViewModel? GetElement(StorekeeperSearchModel model);
        StorekeeperViewModel? Insert(StorekeeperBindingModel model);
        StorekeeperViewModel? Update(StorekeeperBindingModel model);
        StorekeeperViewModel? Delete(StorekeeperBindingModel model);
    }
}
