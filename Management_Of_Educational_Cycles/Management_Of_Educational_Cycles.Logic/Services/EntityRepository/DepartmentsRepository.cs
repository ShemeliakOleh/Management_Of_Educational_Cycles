using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Management_Of_Educational_Cycles.Domain.Models;
using Management_Of_Educational_Cycles.Logic.Interfaces;
using Management_Of_Educational_Cycles.Logic.Interfaces.IEntityRepository;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Management_Of_Educational_Cycles.Logic.Services.EntityRepository
{
    public class DepartmentsRepository :EntityRepository ,IDepartmentsRepository
    {
        public DepartmentsRepository(IRequestSender requestSender): base(requestSender)
        {

        }
        public Task<bool> CreateDepartment(Department department)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteById(Guid? id)
        {
            throw new NotImplementedException();
        }

        public Task<Department> GetById(Guid? id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Department>> GetDepartments()
        {
            return await _requestSender.GetContetFromRequestAsyncAs<List<Department>>(
               await _requestSender.SendGetRequestAsync("https://localhost:44389/api/Departments/list")
               );

        }

        public Task<List<Department>> GetDepartmentsByFaculty(Guid? FacultyId)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateDepartment(Department department)
        {
            throw new NotImplementedException();
        }

        public Task<List<Department>> GetFilteredDepartments(Department pattern)
        {
            throw new NotImplementedException();
        }

        
    }
}
