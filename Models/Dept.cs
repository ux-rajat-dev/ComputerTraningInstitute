using System;
using System.Collections.Generic;

namespace ComputerTrainingInstitute.Models;

public partial class Dept
{
    public int DeptId { get; set; }

    public string? DeptName { get; set; }

    public bool? IsEnabled { get; set; }

    public bool? IsDeleted { get; set; }

    public virtual ICollection<Course> Courses { get; set; } = new List<Course>();

    public virtual ICollection<Teacher> Teachers { get; set; } = new List<Teacher>();
}
