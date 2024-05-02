using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace University.ViewModels
{
    public class ReportTeacherViewModel
    {
        public string TeacherName { get; set; } = string.Empty;
        public List<(string Student, string PhoneNumber)> Students { get; set; } = new();
    }
}