using ComputerTrainingInstitute.CommandModel;
using ComputerTrainingInstitute.QueryModel;
using System.Net;

namespace ComputerTrainingInstitute.Interfaces
{
    public interface IStudent
    {
        StudentQueryModel GetById(int id);
        List<StudentQueryModel> GetAll(ColumnFilter predicate);
        bool AddStudent(StudentCommandModel student);
        bool DeleteStudent(int id);
        bool UpdateStudent(int id, StudentCommandModel student);
    }
}
