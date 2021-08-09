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

    public class WorkManagementCyclesRepository : EntityRepository,IWorkManagementCyclesRepository
    {
        public WorkManagementCyclesRepository(IRequestSender requestSender) : base(requestSender)
        {

        }

        

        public async Task<bool> CreateWorkManagementCycle(WorkManagementCycle workManagementCycle)
        {
            var response = await _requestSender.SendPostRequestAsync("https://localhost:44389/api/WorkManagementCycles/create", workManagementCycle);
            return response.IsSuccessStatusCode;
        }

        public async Task<bool> DeleteById(Guid? id)
        {
            var response = await _requestSender.SendGetRequestAsync("https://localhost:44389/api/WorkManagementCycles/remove?id=" + id);
            return response.IsSuccessStatusCode;
        }

        public async Task<WorkManagementCycle> GetById(Guid? id)
        {
            return await _requestSender.GetContetFromRequestAsyncAs<WorkManagementCycle>(
              await _requestSender.SendGetRequestAsync("https://localhost:44389/api/WorkManagementCycles/one?id=" + id)
              );
        }

        public async Task<List<WorkManagementCycle>> GetFilteredWorkManagementCycles(WorkManagementCycle pattern)
        {
            return await _requestSender.GetContetFromRequestAsyncAs<List<WorkManagementCycle>>(
                await _requestSender.SendPostRequestAsync("https://localhost:44389/api/WorkManagementCycles/filter", pattern)
                );
        }

        public async Task<List<WorkManagementCycle>> GetWorkManagementCycles()
        {
            return await _requestSender.GetContetFromRequestAsyncAs<List<WorkManagementCycle>>(
               await _requestSender.SendGetRequestAsync("https://localhost:44389/api/WorkManagementCycles/list")
               );
        }
        public async Task<bool> UpdateWorkManagementCycle(WorkManagementCycle workManagementCycle)
        {
            var response = await _requestSender.SendPostRequestAsync("https://localhost:44389/api/WorkManagementCycles/update", workManagementCycle);
            return response.IsSuccessStatusCode;
            
        }
        public async Task<bool> ThrowOffTeacherForCycle(Guid? workManagementCycleId, Guid? teacherId)
        {
            var response = await _requestSender.SendGetRequestAsync("https://localhost:44389/api/WorkManagementCycles/throwOff?workManagementCycleId=" + workManagementCycleId + "&teacherId=" + teacherId);
            return response.IsSuccessStatusCode;
        }
        public async Task<bool> AppointTeacherForCycle(Guid? workManagementCycleId, Guid? teacherId)
        {
            var response = await _requestSender.SendGetRequestAsync("https://localhost:44389/api/WorkManagementCycles/appoint?workManagementCycleId=" + workManagementCycleId + "&teacherId=" + teacherId);
            return response.IsSuccessStatusCode;
        }
    }
}
