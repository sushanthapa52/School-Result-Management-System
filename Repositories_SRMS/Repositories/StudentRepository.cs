using Microsoft.EntityFrameworkCore;
using SRMSDataAccess.Models;
using SRMSRepositories.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SRMSRepositories.Repositories
{
    public class StudentRepository : IStudentRepository
    {
        private readonly SrmsContext _sc;
        public StudentRepository(SrmsContext sc)
        {
            _sc = sc;
        }

        public IEnumerable<Student> GetAllStudents()
        {
            return _sc.Students;
        }
        public async Task<Student> AddStudentsAsync(Student std)
        {
            await _sc.Students.AddAsync(std);
            await _sc.SaveChangesAsync();
            return std;


        }




    }
}
