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
    public interface IWorkerStorage
    {
        List<WorkerViewModel> GetFullList();
        List<WorkerViewModel> GetFilteredList(WorkerSearchModel model);
        WorkerViewModel? GetElement(WorkerSearchModel model);
        WorkerViewModel? Insert(WorkerBindingModel model);
        WorkerViewModel? Update(WorkerBindingModel model);
        WorkerViewModel? Delete(WorkerBindingModel model);
    }
}
