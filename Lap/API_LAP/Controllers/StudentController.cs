using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Entity;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        StudentContext Db = new StudentContext();
        [HttpGet]
        public IActionResult GetAll()
        {
            var stds = Db.students.ToList();
            JsonResult res = new JsonResult(stds);
            return res;
        }

        [HttpGet("{id:int}")]
        public IActionResult GetbyID(int id)
        {
            var std = Db.students.Find(id);
            if(std is null) { return NotFound("Student Not Found"); }
            return Ok(new { Student = std});
        }

        [HttpGet("{name:alpha}")]
        public IActionResult GetbyName(string name)
        {
            var std = Db.students.FirstOrDefault(x => x.Name == name);
            if (Empty is null) { return NotFound("Student Not Found"); }
            return Ok(new { Student = std });
        }

        [HttpPost]
        public IActionResult Post(Student student)
        {
            var dep = Db.departments.FirstOrDefault(d => d.Id == student.DepartmentId);
            if (dep == null)
            {
                return BadRequest("Department Doesnt Exist");
            }
            if(ModelState.IsValid)
            {
                Db.students.Add(student);
                Db.SaveChanges();
            }
            
            return Ok(GetAll());
        }

        [HttpPut]
        public IActionResult Put(Student student)
        {
            if(student == null) { return BadRequest(); }
            var existingstudent = Db.students.Find(student.Id);
            if (existingstudent == null) {
                return NotFound();
            }
            if(ModelState.IsValid)
            {
                existingstudent.Name = student.Name;
                existingstudent.Id = student.Id;
                existingstudent.Address = student.Address;
                existingstudent.Age = student.Age;
                existingstudent.Image = student.Image;
                var dep = Db.departments.FirstOrDefault(d => d.Id == student.DepartmentId);
                if (dep == null)
                {
                    return BadRequest("Department Doesnt Exist");
                }
                existingstudent.DepartmentId = student.DepartmentId;
                Db.Update(existingstudent);
                Db.SaveChanges();
            }
            
            return Ok(student);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var student = Db.students.Find(id);
            if(student == null)
            {
                return BadRequest("Student Not Found");
            }
            Db.students.Remove(student);
            Db.SaveChanges();
            return Ok(GetAll());
        }
    }
}
