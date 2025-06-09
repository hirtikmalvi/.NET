using System;

namespace Practice_4
{
    class Student
    {
        private string StudentId;
        private string Name;
        private List<float> Marks = new List<float>();

        public Student() {
            StudentId = DateTime.UtcNow.Ticks.ToString();
        }

        public string GetStudentID()
        {
            return StudentId;
        }

        public void SetName(string name) {
            Name = name;
        }

        public string GetName()
        {
            return Name;
        }

        public void AddMarks(float marks)
        {
            if (marks < 0 || marks > 100)
            {
                throw new Exception("Marks must be between 0 and 100");
            }
            Marks.Add(marks);
        }

        public double GetPercentage()
        {
            float totalMarks = 0;
            foreach (var mark in Marks)
            {
                totalMarks += mark;
            }
            return totalMarks / Marks.Count;
        }
    }
}
