using AutoMapper;
using Core.Models;
using Microsoft.AspNetCore.Mvc;
using UniversityAPI.Core.Abstractions;
using UniversityAPI_ApiVersioning_Homework.dtos;

namespace UniversityAPI_ApiVersioning_Homework.Controllers.V2
{
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiVersion("2.0")]
    public class StudentController : ControllerBase
    {
        private IMapper _mapper;
        private IRepositoryStudent _studentRepository;
        public StudentController(IMapper mapper, IRepositoryStudent repositoryStudent)
        {
            _mapper = mapper;
            _studentRepository = repositoryStudent;
        }

        [HttpGet("GetStudentsByFirstName")]
        [MapToApiVersion("2.0")]
        public async Task<ActionResult<IEnumerable<StudentGetDto>>> GetStudentsByFirstName([FromQuery] string name)
        {
            var results = await _studentRepository.GetStudentsByFirstName(name);
            var mappedResults = _mapper.Map<IEnumerable<StudentGetDto>>(results);
            return Ok(mappedResults);
        }

    }
}
