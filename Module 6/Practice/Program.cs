using System;
using System.Linq;
using System.Collections.Generic;

// Use this Class For GroupBy vs ToLookup
//public class Student
//{
//    public int StudentID { get; set; }
//    public string StudentName { get; set; }
//    public int Age { get; set; }
//}

// Use following Student and Standard Class for the Join And GroupJoin Demo
public class Student
{
    public int StudentID { get; set; }
    public string StudentName { get; set; }
    public int Age { get; set; }
    public int StandardID { get; set; }
}

public class Standard
{
    public int StandardID { get; set; }
    public string StandardName { get; set; }
}

public class Program
{
    // Just For Practice and to Demonstrate difference between the GroupBy and ToLookup
    public void GroupBy_VS_ToLookup()
    {
        // Student collection
        IList<Student> studentList = new List<Student>() {
                new Student() { StudentID = 1, StudentName = "John", Age = 18 } ,
                new Student() { StudentID = 2, StudentName = "Steve",  Age = 21 } ,
                new Student() { StudentID = 3, StudentName = "Bill",  Age = 18 } ,
                new Student() { StudentID = 4, StudentName = "Ram" , Age = 20 } ,
                new Student() { StudentID = 5, StudentName = "Ron" , Age = 21 }
            };

        var groupedResult = studentList.GroupBy(s => s.Age);
        var lookedUpList = studentList.ToLookup(s => s.Age);
        studentList.Add(new Student { StudentID = 6, StudentName = "Hirtik", Age = 21 });

        Console.WriteLine("\n---- GroupBy ----\n");
        foreach (var group in groupedResult)
        {
            Console.WriteLine($"Age Group: {group.Key}");
            foreach (var s in group)
            {
                Console.WriteLine($"ID: {s.StudentID} ,Name: {s.StudentName}");
            }
        }

        Console.WriteLine("\n---- ToLookUp ----\n");
        foreach (var group in lookedUpList)
        {
            Console.WriteLine($"Age Group: {group.Key}");
            foreach (var s in group)
            {
                Console.WriteLine($"ID: {s.StudentID} ,Name: {s.StudentName}");
            }
        }
    }


    // Just For Practice and to Demonstrate difference between the Join and GroupJoin
    public void JoinDemo()
    {
        IList<Student> studentList = new List<Student>() {
                new Student() { StudentID = 1, StudentName = "John", Age = 18, StandardID = 1 } ,
                new Student() { StudentID = 2, StudentName = "Steve",  Age = 21, StandardID = 1 } ,
                new Student() { StudentID = 3, StudentName = "Bill",  Age = 18, StandardID = 2 } ,
                new Student() { StudentID = 4, StudentName = "Ram" , Age = 20, StandardID = 2 } ,
                new Student() { StudentID = 5, StudentName = "Ron" , Age = 21 }
            };

        IList<Standard> standardList = new List<Standard>() {
                new Standard(){ StandardID = 1, StandardName="Standard 1"},
                new Standard(){ StandardID = 2, StandardName="Standard 2"},
                new Standard(){ StandardID = 3, StandardName="Standard 3"}
            };

        var result = studentList.Join(standardList, stdnt => stdnt.StandardID, std => std.StandardID, (student, standard) => new { StudentName = student.StudentName, Standard = standard.StandardName });

        foreach (var item in result)
        {
            Console.WriteLine($"Student: {item.StudentName}, Standard: {item.Standard}");
        }
    }

    public void GroupJoinDemo()
    {
        IList<Student> studentList = new List<Student>() {
                new Student() { StudentID = 1, StudentName = "John", Age = 18, StandardID = 1 } ,
                new Student() { StudentID = 2, StudentName = "Steve",  Age = 21, StandardID = 1 } ,
                new Student() { StudentID = 3, StudentName = "Bill",  Age = 18, StandardID = 2 } ,
                new Student() { StudentID = 4, StudentName = "Ram" , Age = 20, StandardID = 2 } ,
                new Student() { StudentID = 5, StudentName = "Ron" , Age = 21 }
            };

        IList<Standard> standardList = new List<Standard>() {
                new Standard(){ StandardID = 1, StandardName="Standard 1"},
                new Standard(){ StandardID = 2, StandardName="Standard 2"},
                new Standard(){ StandardID = 3, StandardName="Standard 3"}
            };

        var result = standardList.GroupJoin(studentList, std => std.StandardID, stdnt => stdnt.StandardID, (standard, studentGroup) => new { StandardName = standard.StandardName, Students = studentGroup });

        foreach (var item in result)
        {
            Console.WriteLine($"{item.StandardName}, Students: [{string.Join(", ", item.Students.Select(s => s.StudentName))}]");
        }
    }
    public static void Main()
    {
        Program program = new Program();
        // Uncomment one by one to try 
        //program.GroupBy_VS_ToLookup();
        //program.JoinDemo();
        //program.GroupJoinDemo();
    }

}