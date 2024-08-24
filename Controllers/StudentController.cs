using System.Linq;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using ComputerTrainingInstitute.Interfaces;
using ComputerTrainingInstitute.QueryModel;
using ComputerTrainingInstitute.CommandModel;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using ComputerTrainingInstitute.Models;

namespace ComputerTrainingInstitute.Controllers
{
    [ApiController]
    [Route("API/Student")]
    public class StudentController : ControllerBase
    {
        private readonly IStudent _Student;

        public StudentController(IStudent Student)
        {
            _Student = Student;
        }
        [HttpGet("/Id")]
        public StudentQueryModel GetById(int id)
        {
            var data = _Student.GetById(id);
            if (data == null)
            {
                return null;
            }
            return data;
        }
        /// <summary>
        /// Reference 
        /// </summary>
        /// <param name="filter"></param>
        /// <returns></returns>
        [HttpGet("/Id/Get")]
        public List<StudentQueryModel> GetAll([FromBody] ColumnFilter filter)
        {
            var data = _Student.GetAll(filter);

            if (data == null)
            {
                return null;
            }
            return data;
        }


        [HttpPost("/Id/Post")]
        public IActionResult Post(StudentCommandModel Student1)
        {
            var data = _Student.AddStudent(Student1);
            return Ok(data);
        }

        [HttpPut("/Id/Put-Update")]
        public IActionResult Put(int id)
        {
            var data = _Student.DeleteStudent(id);
            return Ok(data);
        }

        [HttpPut("/Id/Put")]
        public IActionResult Put(int Id, StudentCommandModel add1)
        {

            var data = _Student.UpdateStudent(Id, add1);
            return Ok(data);
        }
    }
}
