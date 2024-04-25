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
    public interface IAttestationLogic
    {
        List<AttestationViewModel>? ReadList(AttestationSearchModel? model);
        bool CreateAttestation(AttestationBindingModel model);
        bool SetPass(AttestationBindingModel model);
        bool SetNotPass(AttestationBindingModel model);
        bool Set(AttestationBindingModel model);
        bool Set(AttestationBindingModel model);
        bool Set(AttestationBindingModel model);
        bool SetNotCredit(AttestationBindingModel model);

    }
}
