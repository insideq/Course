namespace UniversityDataModels.Models
{
    public interface IAttestationModel : IId
    {
        string FormOfEvaluation { get; }
        string Score { get; }
        int StudentId { get; }
    }
}
