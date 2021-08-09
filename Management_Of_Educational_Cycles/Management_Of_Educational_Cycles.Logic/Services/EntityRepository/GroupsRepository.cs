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
    public class GroupsRepository : EntityRepository, IGroupsRepository
    {
        public GroupsRepository(IRequestSender requestSender) : base(requestSender)
        {

        }
        public async Task<bool> CreateGroup(AcademicGroup group)
        {
            var response = await _requestSender.SendPostRequestAsync("https://localhost:44389/api/AcademicGroups/create", group);
            return response.IsSuccessStatusCode;
        }

        public async Task<bool> DeleteById(Guid? id)
        {
            var response = await _requestSender.SendGetRequestAsync("https://localhost:44389/api/AcademicGroups/remove?id=" + id);
            return response.IsSuccessStatusCode;
        }

        public async Task<AcademicGroup> GetById(Guid? id)
        {
            return await _requestSender.GetContetFromRequestAsyncAs<AcademicGroup>(
               await _requestSender.SendGetRequestAsync("https://localhost:44389/api/AcademicGroups/one?id=" + id)
               );
        }

        public async Task<List<AcademicGroup>> GetFilteredGroups(AcademicGroup pattern)
        {
            return await _requestSender.GetContetFromRequestAsyncAs<List<AcademicGroup>>(
                await _requestSender.SendPostRequestAsync("https://localhost:44389/api/AcademicGroups/filter", pattern)
                );
        }

        public async Task<List<AcademicGroup>> GetAllGroups()
        {
            return await _requestSender.GetContetFromRequestAsyncAs<List<AcademicGroup>>(
               await _requestSender.SendGetRequestAsync("https://localhost:44389/api/AcademicGroups/list")
               );
        }

        public async Task<List<AcademicGroup>> GetGroupsByDepartment(Guid? departmentId)
        {
            return await _requestSender.GetContetFromRequestAsyncAs<List<AcademicGroup>>(
               await _requestSender.SendGetRequestAsync("https://localhost:44389/api/AcademicGroups/getByDepartment?departmentId=" + departmentId)
               );
        }

        public async Task<bool> UpdateGroup(AcademicGroup group)
        {
            var response = await _requestSender.SendPostRequestAsync("https://localhost:44389/api/AcademicGroups/update", group);
            return response.IsSuccessStatusCode;
        }
    }
}
