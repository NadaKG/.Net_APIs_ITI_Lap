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
    public class DepartmentController : ControllerBase
    {
        StudentContext db = new StudentContext();

        [HttpGet(Name ="GetAll")]
        public IActionResult GetAll()
        {
            var departments = db.departments.Include(s => s.Students).ToList();
            var departmentDTOs = new List<DeptStudentName>();

            foreach (var department in departments)
            {
                var departmentDTO = new DeptStudentName
                {
                    DeptName = department.Name,
                    StudentName = department.Students.Select(s => s.Name).ToList()
                };
                departmentDTOs.Add(departmentDTO);
            }

            return Ok(departmentDTOs);
        }

        [HttpGet("{id}" ,Name ="GetByID")]
        public IActionResult GetByID(int id)
        {
            var dept = db.departments.Find(id);
            if (dept == null)
            {
                return NotFound();
            }
            return Ok(dept);
        }

        [HttpPost]
        public IActionResult Post( Department department)
        {
            if(ModelState.IsValid)
            {
                db.departments.Add(department);
                db.SaveChanges();
            }
            
            return Ok(department);
        }

        [HttpPut]
        public IActionResult Put(Department department)
        {
            if (department == null)
            {
                return BadRequest("department can't be null");
            }

            var existingdep = db.departments.Find(department.Id);
            if(existingdep == null)
            {
                return NotFound();
            }

            if(ModelState.IsValid)
            {
                existingdep.Id = department.Id;
                existingdep.Name = department.Name;
                existingdep.MgrName = department.MgrName;
                existingdep.Location = department.Location;
                db.departments.Update(existingdep);
                db.SaveChanges();
            }
            
            return Ok(existingdep);

        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            var dep = db.departments.Find(id);
            if(dep == null)
            {
                return NotFound();
            }
            db.departments.Remove(dep);
            db.SaveChanges();
            return Ok(dep);
        }
    }
}
