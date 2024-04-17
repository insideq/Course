using University.DataModels.Models;

namespace University.Contracts.BindingModel
{
    public class StudentBindingModel : IStudentModel
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Familia { get; set; } = string.Empty;
        public string? Patronomyc { get; set; }
        public string PhoneNumber { get; set; } = string.Empty;
        public IPlanOfStudyModel? planOfStudy { get; set; }
    }
}
