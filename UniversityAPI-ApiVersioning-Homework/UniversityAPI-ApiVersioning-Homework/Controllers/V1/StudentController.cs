using AutoMapper;
using Core.Models;
using Microsoft.AspNetCore.Mvc;
using UniversityAPI.Core.Abstractions;
using UniversityAPI_ApiVersioning_Homework.dtos;

namespace UniversityAPI_ApiVersioning_Homework.Controllers.V1
{
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiVersion("1.0")]
    public class StudentController : ControllerBase
    {
        private IMapper _mapper;
        private IRepositoryStudent _studentRepository;
        public StudentController(IMapper mapper, IRepositoryStudent repositoryStudent)
        {
            _mapper = mapper;
            _studentRepository = repositoryStudent;
        }


        [HttpGet("GetStudentsByCompleteName")]
        [MapToApiVersion("1.0")]
        public async Task<ActionResult<IEnumerable<StudentGetDto>>> GetStudentsByCompleteName([FromQuery] string name)
        {
            var results = await _studentRepository.GetStudentsByCompleteName(name);
            var mappedResults = _mapper.Map<IEnumerable<StudentGetDto>>(results);
            return Ok(mappedResults);
        }





    }
}
