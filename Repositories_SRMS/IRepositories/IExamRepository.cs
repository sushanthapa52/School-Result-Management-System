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
        Task<ExamClassRelation> AddExamAsync(ExamClassRelation exam);
        IEnumerable<Exam> GetAllExams();

        IEnumerable<ExamClassRelation> GetAllExamDetails();

         ExamClassRelation GetExamClassById(int id);

        Exam GetExamById(int id);
        bool ExamExists(ExamClassRelation model);





    }
}
