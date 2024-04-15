namespace University.DataModels.Models
{
    public interface IDiscipline : IId
    {
        int TeacherId { get; }
        string Name { get; set; }
        string Description { get; set; }
    }
}
