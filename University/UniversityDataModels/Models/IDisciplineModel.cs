namespace UniversityDataModels.Models
{
    public interface IDisciplineModel : IId
    {
        int TeacherId { get; }
        string Name { get; set; }
        string Description { get; set; }
    }
}
