using SRMSDataAccess.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SRMSRepositories.IRepositories
{
    public interface IStudentRepository
    {

       IEnumerable<Student> GetAllStudents();
        Task<Student> AddStudentsAsync(Student std);
        Student GetStudentById(int id);
        Task<Student> UpdateStudentAsync(Student studentupdates);
        void RemoveStudent(int id);

        bool EmailAlreadyExists(string emailaddress);
        bool RollIdAlreadyExists(string rollId);
    }
}
