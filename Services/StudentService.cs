using System.Linq;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Net;
using ComputerTrainingInstitute.Models;
using ComputerTrainingInstitute.Interfaces;
using ComputerTrainingInstitute.QueryModel;
using ComputerTrainingInstitute.CommandModel;
using LinqKit;

namespace ComputerTrainingInstitute.Services
{
    public class StudentService : IStudent
    {
        private readonly ComputerInstituteContext _ComputerInstituteContext;

        public StudentService(ComputerInstituteContext ComputerInstituteContext)
        {
            _ComputerInstituteContext = ComputerInstituteContext;
        }

        public StudentQueryModel GetById(int id)
        {
            var data = from st in _ComputerInstituteContext.Students.Where(x => x.StudentId == id && x.IsEnabled == true && x.IsDeleted == false)
                       join course in _ComputerInstituteContext.Courses on st.CourseId equals course.CourseId
                       select new StudentQueryModel
                       {
                           RollNo = st.StudentId,
                           Name = st.Name,
                           CourseName = course.CourseName,
                           CourseDuration = course.DurationInMonth,
                           Age = st.Age
                       };
            var data1 = data.FirstOrDefault();
            if (data1 == null)
            {
                return null;
            }
            return data1;
        }

        public List<StudentQueryModel> GetAll(ColumnFilter predicate)
        {
            var studentDetails = _ComputerInstituteContext.Students.Where(x=>x.IsEnabled==true && x.IsDeleted==false).ToList();

            var filter = PredicateBuilder.New<Student>();

            if(predicate != null)   
            {
                if (!string.IsNullOrEmpty(predicate.PredicateFilter.Name))
                {
                    filter = filter.And(st=>predicate.PredicateFilter.Name.Contains(st.Name));
                }                
            }
            var data = from st in studentDetails.Where(filter)
                       join course in _ComputerInstituteContext.Courses on st.CourseId equals course.CourseId
                       select new StudentQueryModel
                       {
                           RollNo = st.StudentId,
                           Name = st.Name,
                           CourseName = course.CourseName,
                           CourseDuration = course.DurationInMonth,
                           Age = st.Age
                       };
            var data1 = data.ToList();
            if (data1 == null)
            {
                return null;
            }
            return data1;
        }

        public bool AddStudent(StudentCommandModel Student)
        {
            if (Student != null)
            {
                var addr = new Student()
                {
                    StudentId = Student.Id,
                    RegId = Student.RegId,
                    Name = Student.Name,
                    CourseId = Student.CourseId,
                    Age = Student.age,
                    IsDeleted = false,
                    IsEnabled = true
                };
                _ComputerInstituteContext.Students.Add(addr);
                _ComputerInstituteContext.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool DeleteStudent(int id)
        {
            var existingData = _ComputerInstituteContext.Students.Find(id);
            if (existingData != null)
            {
                existingData.IsEnabled = false;
                existingData.IsDeleted = true;
                _ComputerInstituteContext.Students.Update(existingData);
                _ComputerInstituteContext.SaveChanges();
                return true;
            }
            return false;
        }


        public bool UpdateStudent(int id, StudentCommandModel student)
        {
            if (student != null)
            {
                var StudentData = _ComputerInstituteContext.Students.Find(id);

                StudentData.Name = student.Name;
                StudentData.Age = student.age;
                StudentData.CourseId = student.CourseId;
                _ComputerInstituteContext.Students.Update(StudentData);
                _ComputerInstituteContext.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}