namespace UniversityAPI_ApiVersioning_Homework.Core.Utilities
{
    public class Pagination<T>
    {
        public int CurrentPage { get; set; }
        public int TotalPages { get; set; }
        public List<T> Results { get; set; }
    }
}
