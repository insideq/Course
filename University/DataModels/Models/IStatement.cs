namespace University.DataModels.Models
{
    public interface IStatement : IId
    {
        int TeacherId { get; }
        string Name { get; }
        DateTime Date { get; }
    }
}
