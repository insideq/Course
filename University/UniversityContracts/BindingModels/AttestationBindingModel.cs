using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniversityDataModels.Models;

namespace UniversityContracts.BindingModels
{
    public class AttestationBindingModel : IAttestationModel
    {
        public int Id { get; set; }
        public string FormOfEvaluation { get; set; } = string.Empty;
        public string Score { get; set; } = string.Empty;
        public int StudentId { get; set; }
    }
}
