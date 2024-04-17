namespace WebApplication1.DTOs
{
    public class DeptStudentName
    {
        public string DeptName { get; set; }
        public List<string> StudentName { get; set;} = new List<string>();
    }
}
