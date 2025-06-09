using System;

namespace Practice_2
{
    class Person
    {
        public string Name {  get; set; }
        public int Age { get; set; }
    }
    class Student: Person { 
        public string StudentId {  get; set; }
        public string Course {  get; set; }
        public void DisplayStudentInfo()
        {
            Console.WriteLine($"Student Information: Name: {Name}, Age: {Age}, StudentID: {StudentId}, Course: {Course}");
        }
    }
    class GraduateStudent: Student 
    {
        public string GraduationYear {  get; set; }
        public void DisplayStudentInfo()
        {
            Console.WriteLine($"Student Information: Name: {Name}, Age: {Age}, StudentID: {StudentId}, Course: {Course}, Graduation Year: {GraduationYear}");
        }
    }
}
