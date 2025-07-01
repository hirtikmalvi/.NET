using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using StudentManagementSystem_A1.Configurations;
using StudentManagementSystem_A1.Models;
using StudentManagementSystem_A1.Services;

namespace StudentManagementSystem_A1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly StudentService _studentService;
        private readonly ILogger<StudentController> _logger;
        private readonly int _maxStudents;  
        public StudentController(StudentService studentService, ILogger<StudentController> logger, IOptions<StudentSettings> options)
        {
            _studentService = studentService;
            _logger = logger;
            _maxStudents = options.Value.MaxStudentCount;
        }

        [HttpGet("test-error")]
        public IActionResult TestError()
        {
            throw new Exception("This is a test error.");
        }

        [HttpGet]
        public async Task<IActionResult> GetAllStudents()
        {
            _logger.LogInformation($"GET /api/Student called at {DateTime.Now}");
            var students = await _studentService.GetAllStudents();
            if (students.Count == 0 || students == null)
            {
                return Ok(new
                {
                    Message = "No Students Found."
                });
            }
            return Ok(students);
        }

        [HttpPost]
        public async Task<IActionResult> AddStudent([FromBody] Student student)
        {
            _logger.LogInformation($"POST /api/Student called at {DateTime.Now}");
            
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (student.Name == "")
            {
                return BadRequest(new
                {
                    Message = "Name Cannot be empty."
                });
            }
            if (student.Age < 5 || student.Age > 100)
            {
                return BadRequest(new
                {
                    Message = "Age Must be between 5 and 100."
                });
            }
            if (student.Grade > 'F' || student.Grade > 'f')
            {
                return BadRequest(new
                {
                    Message = "Grade must be between A-F."
                });
            }
            var addedStudent = await _studentService.AddStudent(student);
            if (addedStudent == null)
            {
                return BadRequest($"Cannot add more than {_maxStudents} students.");
            }
            return CreatedAtAction(nameof(GetStudentById), new
            {
                id = student.StudentId
            }, addedStudent);
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetStudentById(int id)
        {
            _logger.LogInformation($"GET /api/Student/{id} called at {DateTime.Now}");
            var student = await _studentService.GetStudentById(id);
            if (student == null)
            {
                return NotFound(new
                {
                    Message = $"No Student exists with ID {id}."
                });
            }
            return Ok(student);
        }

        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> UpdateStudent(int id, [FromBody] Student studentToUpdate)
        {
            _logger.LogInformation($"PUT /api/Student/{id} called at {DateTime.Now}");

            if (id != studentToUpdate.StudentId)
            {
                return BadRequest("Student ID mismatch.");
            }
             var updatedStudent = await _studentService.UpdateStudent(id, studentToUpdate);
            if (updatedStudent == null)
            {
                return NotFound(new
                {
                    Message = $"Student with ID {id} not found."
                });
            }
            return NoContent();
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> DeleteStudent(int id)
        {
            _logger.LogInformation($"DELETE /api/Student/{id} called at {DateTime.Now}");

            var result = await _studentService.DeleteStudent(id);
            

            if (!result.isDeleted)
            {
                return BadRequest(result.message);
            }
            return Ok($"Student with ID {id} deleted successfully.");
        }
    }
}