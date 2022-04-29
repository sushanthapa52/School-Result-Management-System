using SRMSDataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SRMSRepositories.IRepositories
{
    public interface IExamRepository
    {
       IEnumerable<Exam> GetAllExams();
       Task<Exam> AddExamAsync(Exam exam);

    }
}
