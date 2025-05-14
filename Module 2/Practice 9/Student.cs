using System;
using System.Globalization;

namespace Practice_9
{
    internal class Student
    {
        public string Name;
        public int Age;

        public Student() { }

        public Student(string name, int age)
        {
            Name = name;
            Age = age;
        }

        public Student(string name) {
            Name = name;
            Age = 18;
        }

        public Student(int id, string name, int age): this(name, age) 
        { 
            Console.WriteLine("Called");
        }
    }
}
