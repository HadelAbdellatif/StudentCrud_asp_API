using CRUD_task.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net.NetworkInformation;

namespace CRUD_task.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        List<Students> students = new List<Students> {
            new Students { Id = 1, Name="Hadeel", Bio="CSE"},
            new Students { Id = 2, Name="Nour", Bio="CVE"},
            new Students { Id = 3, Name="Hanaa", Bio="CS"},
        };

        [HttpGet("getAllStudents")]
        public IActionResult GetAll()
        {
            return Ok(students);
        }

        [HttpGet("{id}")]
        public IActionResult GetStudentById(int id)
        {
            var student = students.First(student => student.Id == id);

            if (student is null)
            {
                return NotFound();
            }

                return Ok(student);
        }

        [HttpPost]
        public IActionResult addStudent(Students request)
        {
            if(request is null)
            {
                return BadRequest();
            }

            Students student = new Students
            {
                Id = request.Id,
                Name = request.Name,
                Bio = request.Bio
            };

            students.Add(student);
            return Ok();
        }

        [HttpPut("{id}")]
        public IActionResult updateStudent(int id, Students request)
        {
            var student = students.FirstOrDefault(student => student.Id == id);

            if(student is null)
            {
                return NotFound();
            }

            student.Name = request.Name;
            student.Bio = request.Bio;
            return Ok(student);
        }

        [HttpDelete]
        public IActionResult deleteStudent(int id)
        {
            var student = students.FirstOrDefault(student => student.Id == id);

            if( student is null)
            {
                return NotFound();
            }

            students.Remove(student);
            return Ok(students);
        }
    }
}
