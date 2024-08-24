using System.Linq;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Net;
using ComputerTrainingInstitute.Models;
using ComputerTrainingInstitute.Interfaces;
using ComputerTrainingInstitute.QueryModel;
using ComputerTrainingInstitute.CommandModel;

namespace ComputerTrainingInstitute.Services
{
    public class DepartmentService : IDepartment
    {
        private readonly ComputerInstituteContext _ComputerInstituteContext;

        public DepartmentService(ComputerInstituteContext ComputerInstituteContext)
        {
            _ComputerInstituteContext = ComputerInstituteContext;
        }

        public DepartmentQueryModel GetById(int id)
        {
            var data = from de in _ComputerInstituteContext.Depts.Where(x => x.DeptId == id && x.IsEnabled == true && x.IsDeleted == false)
                       select new DepartmentQueryModel
                       {
                           DeptsId = de.DeptId,
                           DeptName = de.DeptName
                       };
            var data1 = data.FirstOrDefault();
            if (data1 == null)
            {
                return null;
            }
            return data1;
        }

        public List<DepartmentQueryModel> GetAll()
        {

            var data = from de in _ComputerInstituteContext.Depts.Where(x => x.IsEnabled == true && x.IsDeleted == false)
                       select new DepartmentQueryModel
                       {
                           DeptsId = de.DeptId,
                           DeptName = de.DeptName
                       };
            var data1 = data.ToList();
            if (data1 == null)
            {
                return null;
            }
            return data1;
        }

        public bool AddDepartment(DepartmentCommandModel Dept)
        {
            if (Dept != null)
            {
                var addr = new Dept()
                {
                    DeptId = Dept.DeptsId,
                    DeptName = Dept.DeptName,
                    IsDeleted = false,
                    IsEnabled = true
                };
                _ComputerInstituteContext.Depts.Add(addr);
                _ComputerInstituteContext.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool DeleteDepartment(int id)
        {
            var existingData = _ComputerInstituteContext.Depts.Find(id);
            if (existingData != null)
            {
                existingData.IsEnabled = false;
                existingData.IsDeleted = true;
                _ComputerInstituteContext.Depts.Update(existingData);
                _ComputerInstituteContext.SaveChanges();
                return true;
            }
            return false;
        }


        public bool UpdateDepartment(int id, DepartmentCommandModel Dept)
        {
            if (Dept != null)
            {
                var DepartmentData = _ComputerInstituteContext.Depts.Find(id);
                DepartmentData.DeptName = Dept.DeptName;

                _ComputerInstituteContext.Depts.Update(DepartmentData);
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
