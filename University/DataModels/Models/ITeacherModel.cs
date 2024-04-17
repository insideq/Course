namespace University.DataModels.Models
{
    public interface ITeacherModel : IId
    {
        int StorekeeperId { get; }
        string Name { get; }
        string AcademicDegree { get; }
        string Position { get; }
    }
}
