using University.Contracts.BindingModel;
using University.Contracts.SearchModels;
using University.Contracts.ViewModels;

namespace University.Contracts.StorageContracts
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
