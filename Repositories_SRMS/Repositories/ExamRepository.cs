using SRMSDataAccess.Models;
using SRMSRepositories.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SRMSRepositories.Repositories
{
    public class ExamRepository : IExamRepository
    {
        private readonly SrmsContext _sc;

        public ExamRepository(SrmsContext sc) 
        {
            _sc = sc;
        }

        public async Task<Exam> AddExamAsync(Exam exam)
        {
          await  _sc.Exams.AddAsync(exam);
           await _sc.SaveChangesAsync();
            return exam;    

        }
        public IEnumerable<Exam> GetAllExams()
        {
            return _sc.Exams;
        }

    }
}
