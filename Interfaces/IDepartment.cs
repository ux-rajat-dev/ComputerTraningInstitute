using ComputerTrainingInstitute.CommandModel;
using ComputerTrainingInstitute.QueryModel;
using System.Collections.Generic;

namespace ComputerTrainingInstitute.Interfaces
{
    public interface IDepartment
    {
        DepartmentQueryModel GetById(int id);
        List<DepartmentQueryModel> GetAll();
        bool AddDepartment(DepartmentCommandModel department);
        bool DeleteDepartment(int id);
        bool UpdateDepartment(int id, DepartmentCommandModel department);
    }
}
