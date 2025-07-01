using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using StudentManagementSystem_A1.Configurations;
using StudentManagementSystem_A1.Models;

namespace StudentManagementSystem_A1.Services
{
    public class StudentService
    {
        private readonly AppDbContext _context;
        private readonly int _maxStudents;
        public StudentService(AppDbContext appDbContext, IOptions<StudentSettings> options)
        {
            _context = appDbContext;
            _maxStudents = options.Value.MaxStudentCount;
        }

        public async Task<List<Student>> GetAllStudents()
        {
            return await _context.Students.ToListAsync();
        }

        public async Task<Student?> GetStudentById(int studentId)
        {
            var student = _context.Students.FindAsync(studentId);
            return await student;
        }

        public async Task<Student?> AddStudent(Student student)
        {
            int currentCount = await _context.Students.CountAsync();
            if (currentCount >= _maxStudents)
            {
                return null;
            }
            await _context.AddAsync(student);
            await _context.SaveChangesAsync();
            return student;
        }

        public async Task<Student?> UpdateStudent(int studentId, Student student)
        {
            var foundStudent = await _context.Students.FindAsync(studentId);
            if (foundStudent == null)
            {
                return null;
            }
            foundStudent.Name = student.Name;
            foundStudent.Age = student.Age;
            foundStudent.Grade = student.Grade;
            await _context.SaveChangesAsync();
            return foundStudent;
        }

        public async Task<(bool isDeleted, string? message)> DeleteStudent(int studentId)
        {
            var student = await _context.Students.FindAsync(studentId);
            if(student == null) return (false, "Student not found.");

            if(student.Grade == 'A')
            {
                return (false, "Cannot delete top-performing students");
            }
            _context.Students.Remove(student);
            await _context.SaveChangesAsync();
            return (true, null);
        }
    }
}
