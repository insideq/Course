namespace UniversityDataModels.Models
{
    public interface IStudentModel : IId
    {
        string Name { get; }
        public string PhoneNumber { get; }
        int PlanOfStudyId { get; }
    }
}
