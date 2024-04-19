using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniversityDataModels.Models;

namespace UniversityContracts.ViewModels
{
    public class StorekeeperViewModel : IStorekeeperModel
    {
        public int Id { get; set; }
        [DisplayName("Имя")]
        public string FirstName { get; set; } = string.Empty;
        [DisplayName("Фамилия")]
        public string LastName { get; set; } = string.Empty;
        [DisplayName("Отчество")]
        public string MiddleName { get; set; } = string.Empty;
        [DisplayName("Номер телефона")]
        public string PhoneNumber { get; set; } = string.Empty;
        [DisplayName("Почта")]
        public string Email { get; set; } = string.Empty;
    }
}
