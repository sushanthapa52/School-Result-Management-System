﻿using SRMSDataAccess.Models;
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

        public async Task AddMarksAsync(List<Mark> marks)
        {
            _sc.Marks.AddRange(marks);
            await _sc.SaveChangesAsync();
            
        }

    }
}
