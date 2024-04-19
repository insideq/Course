﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniversityDataModels.Models;

namespace UniversityContracts.BindingModels
{
    public class TeacherBindingModel : ITeacherModel
    {
        public int Id { get; set; }
        public int StorekeeperId { get; set; }
        public string Name { get; set; } = string.Empty;
        public string AcademicDegree { get; set; } = string.Empty;
        public string Position { get; set; } = string.Empty;
    }
}
