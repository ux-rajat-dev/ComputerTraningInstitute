using Microsoft.AspNetCore.Mvc;
using ComputerTrainingInstitute.Interfaces;
using ComputerTrainingInstitute.QueryModel;
using ComputerTrainingInstitute.CommandModel;
using System.Collections.Generic;
using ComputerTrainingInstitute.Services;

namespace ComputerTrainingInstitute.Controllers
{
    [ApiController]
    [Route("API/Department")]
    public class DepartmentController : ControllerBase
    {
        private readonly IDepartment _departmentService;

        public DepartmentController(IDepartment departmentService)
        {
            _departmentService = departmentService;
        }

        [HttpGet("{id}")]
        public ActionResult<DepartmentQueryModel> GetById(int id)
        {
            var data = _departmentService.GetById(id);
            if (data == null)
            {
                return NotFound();
            }
            return Ok(data);
        }

        [HttpGet]
        public ActionResult<List<DepartmentQueryModel>> GetAll()
        {
            var data = _departmentService.GetAll();
            if (data == null)
            {
                return NoContent();
            }
            return Ok(data);
        }

        [HttpPost]
        public IActionResult Post(DepartmentCommandModel department)
        {
            var success = _departmentService.AddDepartment(department);
            if (success)
            {
                return Ok();
            }
            return BadRequest();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var success = _departmentService.DeleteDepartment(id);
            if (success)
            {
                return Ok();
            }
            return NotFound();
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, DepartmentCommandModel department)
        {
            var success = _departmentService.UpdateDepartment(id, department);
            if (success)
            {
                return Ok();
            }
            return NotFound();
        }
    }
}
