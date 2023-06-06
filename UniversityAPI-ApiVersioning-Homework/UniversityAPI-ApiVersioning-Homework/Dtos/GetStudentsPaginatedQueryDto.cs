namespace UniversityAPI_ApiVersioning_Homework.Dtos
{
    public class GetStudentsPaginatedQueryDto
    {
        public int StudentsPerPage { get; set; }
        public int Page { get; set; }
        public string? Name { get; set; }
    }
}
