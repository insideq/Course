﻿using UniversityDataModels.Models;

namespace UniversityContracts.SearchModels
{
    public class StudentSearchModel
    {
        public int? Id { get; set; }
        public int UserId { get; set; }
        public string? Name { get; set; }
    }
}
