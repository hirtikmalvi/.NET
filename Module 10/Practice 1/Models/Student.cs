using System;
using System.Collections.Generic;

namespace Practice_1.Models;

public partial class Student
{
    public int StudentId { get; set; }

    public string? StudentName { get; set; }

    public int? CourseId { get; set; }

    public virtual Course? Course { get; set; }
}
