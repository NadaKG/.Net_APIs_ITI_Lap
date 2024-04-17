using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace WebApplication1.Models
{
    public class Student
    {
        public int Id { get; set; }

        [RegularExpression("[a-zA-Z]")]
        public string Name { get; set; }
        public int Age { get; set; }
        public string? Image { get; set;}
        public string? Address { get; set; }
        [ForeignKey("Department")]
        public int DepartmentId { get; set; }
        public Department? Department { get; set; }
        //[JsonIgnore]
        public ICollection<Course> Courses { get; set; } = new List<Course>();
    }
}
