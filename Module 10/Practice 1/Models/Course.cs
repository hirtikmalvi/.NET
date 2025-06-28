using System;
using System.Collections.Generic;

namespace Practice_1.Models;

public partial class Course
{
    public int CourseId { get; set; }

    public string? CourseName { get; set; }

    public virtual ICollection<Student> Students { get; set; } = new List<Student>();
}
