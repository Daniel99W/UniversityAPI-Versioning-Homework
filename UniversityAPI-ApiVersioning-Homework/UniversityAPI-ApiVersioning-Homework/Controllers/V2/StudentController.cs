using AutoMapper;
using Core.Models;
using Microsoft.AspNetCore.Mvc;
using UniversityAPI.Core.Abstractions;
using UniversityAPI_ApiVersioning_Homework.Core.Utilities;
using UniversityAPI_ApiVersioning_Homework.dtos;
using UniversityAPI_ApiVersioning_Homework.Dtos;

namespace UniversityAPI_ApiVersioning_Homework.Controllers.V2
{
    [ApiController]
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

        [HttpGet("GetStudentsByFirstNamePaginated")]
        [MapToApiVersion("2.1")]
        public async Task<ActionResult<IEnumerable<StudentGetDto>>> GetStudentsByFirstNamePaginated(
            [FromQuery] GetStudentsPaginatedQueryDto getStudentsPaginatedQueryDto)
        {
            var result =
                await _studentRepository.GetStudentsByFirstNamePaginated(
                    getStudentsPaginatedQueryDto.name,
                    getStudentsPaginatedQueryDto.Page,
                    getStudentsPaginatedQueryDto.StudentsPerPage);

            var mappedResult = _mapper.Map<Pagination<StudentGetDto>>(result);
            return Ok(mappedResult);
        }

    }
}
