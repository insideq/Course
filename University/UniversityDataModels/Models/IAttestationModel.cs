using UniversityDataModels.Enums;

namespace UniversityDataModels.Models
{
    public interface IAttestationModel : IId
    {
        string FormOfEvaluation { get; }
        AttestationScore Score { get; }
        int StudentId { get; }
    }
}
