using SRMSDataAccess.Models;
using SRMSRepositories.IRepositories;
using SRMSServices.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SRMSServices.Services
{
    public class StudentService : Service<Student, int>, IStudentService
    {
        public StudentService(IRepository<Student, int> repository) : base(repository)
        {
        }
    }
}
