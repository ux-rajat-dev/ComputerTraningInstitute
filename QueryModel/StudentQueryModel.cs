namespace ComputerTrainingInstitute.QueryModel
{

    public class StudentQueryModel
    {
        public int RollNo { get; set; }
        public string Name { get; set; }
        public string CourseName { get; set; }
        public float? CourseDuration { get; set; }
        public float? Age { get; set; }
        public bool isDeleted { get; set; }
        public bool isEnabled { get; set; }

    }
    public class ColumnFilter 
    {
        public new StudentQueryModel PredicateFilter;
    }
}
