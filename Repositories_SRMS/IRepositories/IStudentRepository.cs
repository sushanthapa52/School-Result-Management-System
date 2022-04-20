using SRMSDataAccess.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SRMSRepositories.IRepositories
{
    public interface IStudentRepository
    {

       IEnumerable<Student> GetAllStudents();
        Task<Student> AddStudentsAsync(Student std);
    }
}
