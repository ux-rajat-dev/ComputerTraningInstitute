using System;
using System.Collections.Generic;

namespace ComputerTrainingInstitute.Models;

public partial class Course
{
    public int CourseId { get; set; }

    public string? CourseName { get; set; }

    public float? DurationInMonth { get; set; }

    public int? TeacherId { get; set; }

    public int? DeptId { get; set; }

    public virtual Dept? Dept { get; set; }

    public virtual ICollection<Student> Students { get; set; } = new List<Student>();

    public virtual Teacher? Teacher { get; set; }
}
