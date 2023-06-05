using Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniversityAPI_ApiVersioning_Homework.Core.Utilities;

namespace UniversityAPI.Core.Abstractions
{
    public interface IRepositoryStudent : IRepository<Student>
    {
        public Task<List<Student>> GetStudentsByFirstName(string name);
        public Task<List<Student>> GetStudentsByCompleteName(string name);
        public Task<Pagination<Student>> GetStudentsByFirstNamePaginated(
            string? name, 
            int page,
            int studentsPerPage);
    }
}
