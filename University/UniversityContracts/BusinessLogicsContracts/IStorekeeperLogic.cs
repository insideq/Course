using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniversityContracts.BindingModels;
using UniversityContracts.SearchModels;
using UniversityContracts.ViewModels;

namespace UniversityContracts.BusinessLogicsContracts
{
    public interface IStorekeeperLogic
    {
        List<StorekeeperViewModel>? ReadList(StorekeeperSearchModel? model);
        StorekeeperViewModel? ReadElement(StorekeeperSearchModel model);
        bool Create(StorekeeperBindingModel model);
        bool Update(StorekeeperBindingModel model);
        bool Delete(StorekeeperBindingModel model);
    }
}
