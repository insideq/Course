using UniversityContracts.BindingModel;
using UniversityContracts.SearchModels;
using UniversityContracts.ViewModels;

namespace UniversityContracts.BusinessLogicsContracts
{
    public interface IStudentLogic
    {
        List<StudentViewModel>? ReadList(StudentSearchModel? model);
        StudentViewModel? ReadElement(StudentSearchModel model);
        bool Create(StudentBindingModel model);
        bool Update(StudentBindingModel model);
        bool Delete(StudentBindingModel model);
    }
}
