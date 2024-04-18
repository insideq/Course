namespace University.DataModels.Models
{
    public interface IPlanOfStudyModel : IId
    {
        string Profile { get; }
        string FormOfStudy { get; }
        int WorkerId { get; }
    }
}
