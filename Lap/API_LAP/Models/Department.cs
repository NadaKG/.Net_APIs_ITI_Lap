using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace WebApplication1.Models
{
    public class Department
    {
        public int Id { get; set; }

        [RegularExpression("[a-zA-Z]")]
        public string Name { get; set; }
        [RegularExpression(@"^(cairo|giza|ismailia)$", ErrorMessage = "Invalid Location name. Valid options are Cairo, Giza, or Ismailia.")]
        public string Location { get; set; }
        [RegularExpression("[a-zA-Z]")]
        public string MgrName { get; set; }
        [JsonIgnore]
        public ICollection<Student> Students { get; set; } = new List<Student>();
    }
}
