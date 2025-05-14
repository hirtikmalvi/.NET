using System;

namespace BusinessLogic
{
    public class Student
    {
        private static int _Id = 0;
        public string Name { get; set; }
        public int Age { get; set; }
        public int Id { get; } 

        public Student()
        {
            _Id++;
            Id = _Id;
        }
    }
}