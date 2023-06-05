using Core.Models;
using DAL;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniversityAPI.Core.Abstractions;

namespace UniversityAPI.DAL.Repositories
{
    public class StudentsRepository : Repository<Student>, IRepositoryStudent
    {
        public StudentsRepository(UniversitateContext universitateContext) 
            : base(universitateContext)
        {

        }

        public async Task<List<Student>> GetStudentsByCompleteName(string name)
        {
            return await _universitateContext
                .Students.Where(s => (s.Nume + s.Prenume).Contains(name))
                .ToListAsync();
        }

        public async Task<List<Student>> GetStudentsByFirstName(string name)
        {
            return await _universitateContext
                .Students.Where(s => s.Nume.Contains(name))
                .ToListAsync();
        }


    }
}
