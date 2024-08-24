using System;
using System.Collections.Generic;

namespace ComputerTrainingInstitute.Models;

public partial class Student
{
    public int StudentId { get; set; }

    public int? RegId { get; set; }

    public string? Name { get; set; }

    public int? CourseId { get; set; }

    public float? Age { get; set; }

    public bool? IsEnabled { get; set; }

    public bool? IsDeleted { get; set; }

    public virtual Course? Course { get; set; }
}
