using System;
using System.Collections.Generic;

namespace ComputerTrainingInstitute.Models;

public partial class Teacher
{
    public int TeacherId { get; set; }

    public int? DeptId { get; set; }

    public string? Name { get; set; }

    public float? Age { get; set; }

    public DateTime DateOfJoining { get; set; }

    public float? Salary { get; set; }

    public virtual ICollection<Course> Courses { get; set; } = new List<Course>();

    public virtual Dept? Dept { get; set; }
}
