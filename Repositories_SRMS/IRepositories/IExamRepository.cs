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

        ExamClassRelation GetExamByClass(int eid, int cid, int examYear);

        ExamClassRelation GetExamByClass(int eid);

        Exam GetExamById(int id);
        bool ExamExists(ExamClassRelation model);





    }
}
