using SRMSDataAccess.Models;
using SRMSRepositories.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SRMSRepositories.Repositories
{
    public class MarkRepository :  IMarkRepository
    {
        private readonly SrmsContext _sc;
        public MarkRepository(SrmsContext sc) 
        {

            _sc = sc;
        }

        public void AddMarks(List<Mark> marks)
        {
            _sc.Marks.AddRange(marks);
            _sc.SaveChanges();
            
        }

        public List<Mark> GetMarksList(int resultId)
        {
            return _sc.Marks.Where(x=>x.ResultId.Equals(resultId)).ToList();  
        }

        public void DeleteMarks(List<Mark> marks)
        {
           _sc.Marks.RemoveRange(marks);
            _sc.SaveChanges();
        }

    }
}
