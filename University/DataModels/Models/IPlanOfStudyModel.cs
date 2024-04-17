namespace University.DataModels.Models
{
    public interface IPlanOfStudyModel : IId
    {
        string Profile { get; }
        string FormOfStudy { get; }
        Dictionary<int, IWorkerModel> Workers { get; }
    }
}
