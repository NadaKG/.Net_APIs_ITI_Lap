using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication1.DTOs;
using WebApplication1.Entity;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CourseController : ControllerBase
    {
        StudentContext db = new StudentContext();

        [HttpGet("{id}")]
        public IActionResult GetByID(int id)
        {
            var course = db.courses.Include(s => s.Students).FirstOrDefault(d => d.Id == id);
            var courseDTO = new CourseStudent();

            courseDTO.CourseName = course.Name;

            foreach (var student in course.Students)
            {
                courseDTO.Students.Add(student.Name);
            }
            return Ok(courseDTO);
        }


        [HttpGet]
        public IActionResult GetAll() {
            var course = db.courses.Include(s => s.Students).ToList();
            JsonResult res = new JsonResult(course);
            return res;
        }

        [HttpPost]
        public IActionResult Post(Course course)
        {
            db.courses.Add(course);
            db.SaveChanges();
            return Ok(course);
        }

        [HttpPut]

        public IActionResult Put(Course course) {
            if (course == null) {
                return BadRequest();
            }
            var existingCourse = db.courses.Find(course.Id);
            if (existingCourse == null)
            {
                return NotFound();
            }
            existingCourse.Name = course.Name;
            existingCourse.Description = course.Description;
            existingCourse.Id = course.Id;
            db.courses.Update(existingCourse);
            db.SaveChanges();
            return Ok(existingCourse);
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            var course = db.courses.Find(id);
            if(course == null)
            {
                return NotFound();
            }
            db.courses.Remove(course);
            db.SaveChanges();
            return Ok(GetAll());
        }

    } 
}
