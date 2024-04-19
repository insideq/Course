using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniversityContracts.SearchModels
{
    public class DisciplineSearchModel
    {
        public int? TeacherId { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
    }
}
