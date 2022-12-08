using SRMSDataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SRMSRepositories.IRepositories
{
    public interface IMarkRepository 
    {
        void AddMarks(List<Mark> marks);
        List<Mark> GetMarksList(int resultId);
        void DeleteMarks(List<Mark> marks);
    }
}
