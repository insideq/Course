namespace University.DataModels.Models
{
    public interface IStudentModel : IId
    {
        string Name { get; }
        string Familia { get; }
        string Patronomyc { get; }
        public string PhoneNumber { get; }
        IPlanOfStudyModel planOfStudy { get; }
    }
}
