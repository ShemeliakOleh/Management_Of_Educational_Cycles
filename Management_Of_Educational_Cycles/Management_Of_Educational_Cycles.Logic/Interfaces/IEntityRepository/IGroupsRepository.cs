using Management_Of_Educational_Cycles.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Management_Of_Educational_Cycles.Logic.Interfaces.IEntityRepository
{
    public interface IGroupsRepository
    {
        public Task<AcademicGroup> GetById(Guid? id);
        public Task<List<AcademicGroup>> GetAllGroups();

        public Task<List<AcademicGroup>> GetGroupsByDepartment(Guid? DepartmentId);
        public Task<bool> CreateGroup(AcademicGroup group);
        public Task<bool> UpdateGroup(AcademicGroup group);
        public Task<bool> DeleteById(Guid? id);
        public Task<List<AcademicGroup>> GetFilteredGroups(AcademicGroup pattern);
    }
}
