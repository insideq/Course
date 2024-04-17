using University.DataModels.Models;

namespace University.Contracts.SearchModels
{
    public class StudentSearchModel
    {
        public int? Id { get; set; }
        public string? Name { get; set; }
        public string? Familia {  get; set; }
        public IPlanOfStudyModel? planOfStudy { get; set; }

    }
}
