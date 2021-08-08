using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Management_Of_Educational_Cycles.Domain.Models;
using Management_Of_Educational_Cycles.Logic.Interfaces;
using Management_Of_Educational_Cycles.Logic.Interfaces.IEntityRepository;
namespace Management_Of_Educational_Cycles.Logic.Services.EntityRepository
{
    public class GroupsRepository : EntityRepository,IGroupsRepository
    {
        public GroupsRepository(IRequestSender requestSender) : base(requestSender)
        {

        }
        public Task<bool> CreateGroup(AcademicGroup group)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteById(Guid? id)
        {
            throw new NotImplementedException();
        }

        public Task<AcademicGroup> GetById(Guid? id)
        {
            throw new NotImplementedException();
        }

        public Task<List<AcademicGroup>> GetFilteredGroups(AcademicGroup pattern)
        {
            throw new NotImplementedException();
        }

        public Task<List<AcademicGroup>> GetGroups()
        {
            throw new NotImplementedException();
        }

        public Task<List<AcademicGroup>> GetGroupsByDepartment(Guid? DepartmentId)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateGroup(AcademicGroup group)
        {
            throw new NotImplementedException();
        }
    }
}
