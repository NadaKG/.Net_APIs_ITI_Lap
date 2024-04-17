using System.Text.Json.Serialization;

namespace WebApplication1.Models
{
    public class Course
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        [JsonIgnore]
        public ICollection<Student> Students { get; set; } = new List<Student>();

    }
}
