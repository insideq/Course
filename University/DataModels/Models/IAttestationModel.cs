namespace University.DataModels.Models
{
    public interface IAttestationModel : IId
    {
        string FormOfEvaluation { get; }
        string Score { get; }
        IStudentModel Student { get; }
    }
}
