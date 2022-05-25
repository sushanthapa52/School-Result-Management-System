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

        public IEnumerable<Student> FilterStudentByName(string searchString)
        {
            return _sc.Students.Where(x => x.StudentName.ToLower().Contains(searchString.ToLower()));
        }
        public async Task<Student> AddStudentsAsync(Student std)
        {

            await _sc.Students.AddAsync(std);
            await _sc.SaveChangesAsync();
            return std;


        }
        public  Student GetStudentById(int id)
        {
            var std = _sc.Students.Find(id);
            return std;
        }

        public async Task<Student> UpdateStudentAsync(Student studentupdates)
        {

           var student= _sc.Students.Attach(studentupdates);
            student.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            await _sc.SaveChangesAsync();
            return studentupdates;
        }

        public void RemoveStudent(int id)
        {
            var student = _sc.Students.Find(id);
            if (student != null)
            {
                _sc.Remove(student);
                _sc.SaveChanges();
            }
        }

        public bool EmailAlreadyExists(string emailaddress)
        {
            Student std = _sc.Students.FirstOrDefault(x => x.StudentEmailId == emailaddress);
            if (std != null)
                return true;

            return false; 

        }
        public bool RollIdAlreadyExists(int rollId,int classId)
        {
            Student std = _sc.Students.FirstOrDefault(x=>x.StudentRollNo==rollId && x.ClassId==classId);
            if (std != null)
                return true;

            return false;

        }

        public Student CheckStudentClassRollNo(int rid,int cid, DateTime dob)
        {

            return _sc.Students.FirstOrDefault(x=>x.StudentRollNo==rid && x.ClassId==cid && x.StudentDob==dob);
        }

     

    }
}
