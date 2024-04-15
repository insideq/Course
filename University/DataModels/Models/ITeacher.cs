namespace University.DataModels.Models
{
    public interface ITeacher : IId
    {
        int StorekeeperId { get; }
        string Name { get; }
        string AcademicDegree { get; }
        string Position { get; }
    }
}
