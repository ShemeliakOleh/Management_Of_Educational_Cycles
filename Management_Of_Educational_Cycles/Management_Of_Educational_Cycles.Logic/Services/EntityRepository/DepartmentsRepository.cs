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
        public async Task<bool> CreateDepartment(Department department)
        {
            var response = await _requestSender.SendPostRequestAsync("https://localhost:44389/api/Departments/create", department);
            return response.IsSuccessStatusCode;
        }
        
        public async Task<bool> DeleteById(Guid? id)
        {
            var response = await _requestSender.SendGetRequestAsync("https://localhost:44389/api/Departments/remove?id=" + id);
            return response.IsSuccessStatusCode;
        }

        public async Task<Department> GetById(Guid? id)
        {
            return await _requestSender.GetContetFromRequestAsyncAs<Department>(
               await _requestSender.SendGetRequestAsync("https://localhost:44389/api/Departments/one?id=" + id)
               );
        }

        public async Task<List<Department>> GetAllDepartments()
        {
            return await _requestSender.GetContetFromRequestAsyncAs<List<Department>>(
               await _requestSender.SendGetRequestAsync("https://localhost:44389/api/Departments/list")
               );

        }

        public async Task<List<Department>> GetDepartmentsByFaculty(Guid? facultyId)
        {
            return await _requestSender.GetContetFromRequestAsyncAs<List<Department>>(
                await _requestSender.SendGetRequestAsync("https://localhost:44389/api/Departments/getByFaculty?facultyId=" + facultyId)
                );
        }

        public async Task<bool> UpdateDepartment(Department department)
        {
            var response = await _requestSender.SendPostRequestAsync("https://localhost:44389/api/Departments/update", department);
            return response.IsSuccessStatusCode;
        }

        public async Task<List<Department>> GetFilteredDepartments(Department pattern)
        {
            return await _requestSender.GetContetFromRequestAsyncAs<List<Department>>(
                await _requestSender.SendPostRequestAsync("https://localhost:44389/api/Departments/filter", pattern)
                );
        }

        
    }
}
