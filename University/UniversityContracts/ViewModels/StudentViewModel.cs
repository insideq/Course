﻿using System.ComponentModel;
using UniversityDataModels.Models;

namespace UniversityContracts.ViewModels
{
    public class StudentViewModel : IStudentModel
    {
        public int Id { get; set; }
        public int PlanOfStudyId { get; set; }
        [DisplayName("ФИО")]
        public string Name { get; set; } = string.Empty;
        [DisplayName("Номер Телефона")]
        public string PhoneNumber { get; set; } = string.Empty;

    }
}
