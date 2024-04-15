namespace University.DataModels.Models
{
    public interface IStudent : IId
    {
        string Name { get; }
        public string PhoneNumber { get; }
        Dictionary<int, (IDiscipline, int)> StudentDisciplines { get; }
    }
}
