namespace UniversityDataModels.Models
{
    public interface IStudentModel : IId
    {
        string Name { get; }
        string PhoneNumber { get; }
        int PlanOfStudyId { get; }
    }
}
