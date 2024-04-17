namespace WebApplication1.DTOs
{
    public class CourseStudent
    {
        public string CourseName { get; set; }
        public List<string> Students { get; set; } = new List<string>();
    }
}
