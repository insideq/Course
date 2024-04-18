using UniversityContracts.BindingModel;
using UniversityContracts.SearchModels;
using UniversityContracts.ViewModels;

namespace UniversityContracts.StorageContracts
{
    public interface IStudentStorage
    {
        List<StudentViewModel> GetFullList();
        List<StudentViewModel> GetFilteredList(StudentSearchModel model);
        StudentViewModel? GetElement(StudentSearchModel model);
        StudentViewModel? Insert(StudentBindingModel model);
        StudentViewModel? Update(StudentBindingModel model);
        StudentViewModel? Delete(StudentBindingModel model);
    }
}
