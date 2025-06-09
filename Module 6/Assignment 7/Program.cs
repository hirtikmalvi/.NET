using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.Intrinsics.X86;
using System.Text.RegularExpressions;
using System.Xml.Linq;
using static System.Runtime.InteropServices.JavaScript.JSType;

public class Student
{
    public int StudentId { get; set; }
    public string Name { get; set; }
    public int Age { get; set; }
    public string Gender { get; set; }
    public string Department { get; set; }
}

public class Course
{
    public int CourseId { get; set; }
    public string CourseName { get; set; }
    public string Department { get; set; }
}

public class Enrollment
{
    public int EnrollmentId { get; set; }
    public int StudentId { get; set; }
    public int CourseId { get; set; }
    public DateTime EnrollmentDate { get; set; }
}


internal class Program
{
    private static void Main(string[] args)
    {
        List<Student> students = new List<Student>
        {
            new Student { StudentId = 1, Name = "Alice", Age = 22, Gender = "Female", Department = "Computer Science" },
            new Student { StudentId = 2, Name = "Bob", Age = 24, Gender = "Male", Department = "Mathematics" },
            new Student { StudentId = 3, Name = "Charlie", Age = 20, Gender = "Male", Department = "Physics" },
            new Student { StudentId = 4, Name = "Diana", Age = 21, Gender = "Female", Department = "Computer Science" },
            new Student { StudentId = 5, Name = "Eve", Age = 23, Gender = "Female", Department = "Mathematics" },
            new Student { StudentId = 6, Name = "Frank", Age = 25, Gender = "Male", Department = "Biology" }
        };

        List<Course> courses = new List<Course>
        {
            new Course { CourseId = 1, CourseName = "Data Structures", Department = "Computer Science" },
            new Course { CourseId = 2, CourseName = "Algorithms", Department = "Computer Science" },
            new Course { CourseId = 3, CourseName = "Linear Algebra", Department = "Mathematics" },
            new Course { CourseId = 4, CourseName = "Quantum Mechanics", Department = "Physics" },
            new Course { CourseId = 5, CourseName = "Organic Chemistry", Department = "Chemistry" }, // No enrollments
            new Course { CourseId = 6, CourseName = "Genetics", Department = "Biology" }
        };

        List<Enrollment> enrollments = new List<Enrollment>
        {
            new Enrollment { EnrollmentId = 1, StudentId = 1, CourseId = 1, EnrollmentDate = new DateTime(2024, 5, 1) },
            new Enrollment { EnrollmentId = 2, StudentId = 1, CourseId = 2, EnrollmentDate = new DateTime(2024, 5, 3) },
            new Enrollment { EnrollmentId = 3, StudentId = 2, CourseId = 3, EnrollmentDate = new DateTime(2024, 5, 2) },
            new Enrollment { EnrollmentId = 4, StudentId = 4, CourseId = 1, EnrollmentDate = new DateTime(2024, 5, 5) },
            new Enrollment { EnrollmentId = 5, StudentId = 5, CourseId = 3, EnrollmentDate = new DateTime(2024, 5, 6) },
            new Enrollment { EnrollmentId = 6, StudentId = 6, CourseId = 6, EnrollmentDate = new DateTime(2024, 5, 7) }
        };

        //🔹 Task 1: Filter and Analyze Data(Where and OfType)
        // Task 1.1 Retrieve all students who belong to the "Computer Science" department and are older than 20 years.
        var t1_1 = students.Where(s => s.Department == "Computer Science" && s.Age > 20);

        // Task 1.2 Filter and display all course names from a mixed collection of objects using OfType<string>().
        var t1_2 = courses.Select(c => c.CourseName).OfType<string>();

        // 🔹 Task 2: Sorting and Grouping (OrderBy, GroupBy, ToLookup)
        // Task 2.1 Sort all students by their name(ascending) and then by age(descending).

        var t2_1 = students.OrderBy(s => s.Name).ThenByDescending(s => s.Age);

        // Task 2.2 Group all students by their department and display the count of students in each department.

        var t2_2 = students.GroupBy(s => s.Department).Select(group => new
        {
            Department = group.Key,
            Count = group.Count()
        }); ;

        foreach (var item in t2_2)
        {
            Console.WriteLine($"Department: {item.Department}, Count: {item.Count}");    
        }

        // Task 2.3 Use ToLookup() to group courses by department and retrieve all courses for a specific department(e.g., "Mathematics").
        var depts = courses.Select(c => c.Department).Distinct().ToList();
        var t2_3 = courses.ToLookup(c => c.Department);

        foreach (var group in t2_3)
        {
            Console.WriteLine($"\nDepartment: {group.Key}");
            foreach (var c in group)
            {
                Console.WriteLine($"\tCourse: {c.CourseName}");
            }
        }

        // 🔹 Task 3: Joining Data (Join and GroupJoin)
        // Task 3.1 Write a LINQ query to join students with their enrollments and display the student name along with the course name they are enrolled in.

        var t3_1 = students.Join(enrollments, s => s.StudentId, e => e.StudentId, (s, e) => new
        {
            StudentName = s.Name,
            CourseName = courses.Find(c => c.CourseId == e.CourseId)?.CourseName
        });
        Console.WriteLine($"\nStudent With Enrolled Courses: ");
        foreach (var group in t3_1)
        {
            Console.WriteLine($"Student: {group.StudentName}, CourseName: {group.CourseName}");
        }

        // Task 3.2 Use GroupJoin to group students with the courses they are enrolled in and display the student name along with a list of course names.
        var t3_2 = students.GroupJoin(enrollments, s => s.StudentId, e => e.StudentId, (student, enrollmentGroup) => new
        {
            StudentName = student.Name,
            Courses = enrollmentGroup.Select(eg => courses.Find(c => c.CourseId == eg.CourseId).CourseName)
        });

        Console.WriteLine($"\nStudent with list of enrolled courses: ");
        foreach(var group in t3_2)
        {
            Console.WriteLine($"\t Student: {group.StudentName}, Courses: [{string.Join(", ", group.Courses)}]");
        }

        // 🔹 Task 4: Advanced Queries (LINQ Query and Method Syntax)

        // Task 4.1 Calculate the total number of enrollments in each department and display the department name with the count.


        var t4_1 = enrollments.Join(students, e => e.StudentId, s => s.StudentId, (e, s) => new { e, s }).Join(courses, es => es.e.CourseId, c => c.CourseId, (es, c) => new
        {
            Department = c.Department
        }).GroupBy(g => g.Department).Select(r => new
        {
            Department = r.Key,
            Count = r.Count()
        });

        foreach (var g in t4_1)
        {
            Console.WriteLine($"\nDepartment: {g.Department}, Count: {g.Count}");
        }

        var t4_2 = enrollments.GroupBy(e => e.StudentId).Select(g => new
        {
            StudentId = g.Key,
            Count = g.Count(),
        }).OrderByDescending(g => g.Count).Take(3);

        foreach (var group in t4_2)
        {
            Console.WriteLine($"\nStudentId: {group.StudentId}, Count: {group.Count}");
        }

        // Task 4.3 Write a LINQ query to find all courses that have no enrollments.
        var t4_3 = courses.Where(c => enrollments.FindIndex(e => e.CourseId == c.CourseId) == -1);

        Console.WriteLine("\nCourse That Does not have enrollments.");
        foreach (var c in t4_3)
        {
            Console.WriteLine($"CourseId: {c.CourseId}, CourseName: {c.CourseName}");
        }

    }
}