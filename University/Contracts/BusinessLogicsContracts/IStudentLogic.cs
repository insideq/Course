using University.Contracts.BindingModel;
using University.Contracts.SearchModels;
using University.Contracts.ViewModels;

namespace University.Contracts.BusinessLogicsContracts
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
