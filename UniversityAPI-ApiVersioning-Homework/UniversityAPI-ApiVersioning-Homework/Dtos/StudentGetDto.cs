namespace UniversityAPI_ApiVersioning_Homework.dtos
{
    public class StudentGetDto
    {
        public int Id { get; set; }

        public string Nume { get; set; } = null!;

        public string Prenume { get; set; } = null!;

        public int? GrupaId { get; set; }

        public int? OrasId { get; set; }
    }
}
