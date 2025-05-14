using System;

namespace BusinessLogic
{
    public class StudentManager
    {
        private List<Student> _Students = new List<Student>();

        public void AddStudent(string name, int age)
        {
            Student student = new Student();
            student.Name = name;
            student.Age = age;
            _Students.Add(student);
        }
        public List<Student> GetStudentDetails()
        {
            List<Student> students = _Students;
            return students;
        }

        public double CalculateAverageAge()
        {
            double totalAge = 0;
            foreach (var student in _Students)
            {
                totalAge += student.Age;
            }
            return totalAge / _Students.Count;
        }
    }
}



