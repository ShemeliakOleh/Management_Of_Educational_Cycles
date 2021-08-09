using Management_Of_Educational_Cycles.Domain.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Management_Of_Educational_Cycles.Domain.Entities.Repository
{
    public interface IDepartmentRepository
    {
        public Task<bool> Add(Department department);
        public Task<List<Department>> GetDepartmentsByFaculty(Guid? facultyId);
        public Task<bool> Update(Department department);
        public Task<bool> Remove(Guid? id);
        public Task<Department> GetById(Guid? id);
        public Task<List<Department>> GetAll();
        public bool Exists(Guid? id);
    }
}
