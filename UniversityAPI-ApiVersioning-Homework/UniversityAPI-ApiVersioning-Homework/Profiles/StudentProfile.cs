using AutoMapper;
using Core.Models;
using UniversityAPI_ApiVersioning_Homework.dtos;

namespace UniversityAPI_ApiVersioning_Homework.Profiles
{
    public class StudentProfile : Profile
    {
        public StudentProfile()
        {
            CreateMap<Student, StudentGetDto>().ReverseMap();
        }
    }
}
