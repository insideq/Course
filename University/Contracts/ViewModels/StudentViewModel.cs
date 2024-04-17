using System.ComponentModel;
using University.DataModels.Models;

namespace University.Contracts.ViewModels
{
    public class StudentViewModel : IStudentModel
    {
        public int Id { get; set; }
        [DisplayName("Имя")]
        public string Name { get; set; } = string.Empty;
        [DisplayName("Фамилия")]
        public string Familia {  get; set; } = string.Empty;
        [DisplayName("Отчество")]
        public string Patronomyc { get; set; } = string.Empty;
        [DisplayName("Номер Телефона")]
        public string PhoneNumber { get; set; } = string.Empty;
        public IPlanOfStudyModel planOfStudy { get; set; }

    }
}
