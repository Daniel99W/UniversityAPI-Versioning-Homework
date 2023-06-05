using Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniversityAPI.Core.Abstractions
{
    public interface IRepositoryStudent : IRepository<Student>
    {
        public Task<List<Student>> GetStudentsByFirstName(string name);
        public Task<List<Student>> GetStudentsByCompleteName(string name);
    }
}
