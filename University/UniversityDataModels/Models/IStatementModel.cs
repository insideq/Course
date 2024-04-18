namespace UniversityDataModels.Models
{
    public interface IStatementModel : IId
    {
        int TeacherId { get; }
        string Name { get; }
        DateTime Date { get; }
    }
}
