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

        public async Task<ExamClassRelation> AddExamAsync(ExamClassRelation exam)
        {
          await  _sc.ExamClassRelations.AddAsync(exam);
           await _sc.SaveChangesAsync();
            return exam;    

        }
        public IEnumerable<Exam> GetAllExams()
        {
            return _sc.Exams;
        }

        public IEnumerable<ExamClassRelation> GetAllExamDetails()
        {
           return _sc.ExamClassRelations;
        }

        public ExamClassRelation GetExamClassById(int id)
        {
            var examClass =_sc.ExamClassRelations.FirstOrDefault(x=>x.ExamId==id);
            return examClass;
        }

        public Exam GetExamById(int id)
        {
           return _sc.Exams.Find(id);
        }
      


    }

  
    }
