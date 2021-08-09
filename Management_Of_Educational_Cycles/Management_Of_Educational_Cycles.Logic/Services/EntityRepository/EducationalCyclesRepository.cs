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
    public class EducationalCyclesRepository :EntityRepository ,IEducationalCyclesRepository
    {
        public EducationalCyclesRepository(IRequestSender requestSender) : base(requestSender)
        {

        }

       

        public async Task<bool> CreateEducationalCycle(EducationalCycle educationalCycle)
        {
            var response = await _requestSender.SendPostRequestAsync("https://localhost:44389/api/EducationalCycles/create", educationalCycle);
            return response.IsSuccessStatusCode;
        }

        public async Task<bool> DeleteById(Guid? id)
        {
            var response = await _requestSender.SendGetRequestAsync("https://localhost:44389/api/EducationalCycles/remove?id=" + id);
            return response.IsSuccessStatusCode;
        }

        public async Task<EducationalCycle> GetById(Guid? id)
        {
            return await _requestSender.GetContetFromRequestAsyncAs<EducationalCycle>(
               await _requestSender.SendGetRequestAsync("https://localhost:44389/api/EducationalCycles/one?id=" + id)
               );
        }

        public async Task<List<EducationalCycle>> GetEducationalCycles()
        {
            return await _requestSender.GetContetFromRequestAsyncAs<List<EducationalCycle>>(
               await _requestSender.SendGetRequestAsync("https://localhost:44389/api/EducationalCycles/list")
               );
        }

        public async Task<List<EducationalCycle>> GetFilteredEducationalCycles(EducationalCycle pattern)
        {
            return await _requestSender.GetContetFromRequestAsyncAs<List<EducationalCycle>>(
                await _requestSender.SendPostRequestAsync("https://localhost:44389/api/EducationalCycles/filter", pattern)
                );
        }
        public async Task<bool> AppointTeacherForCycle(Guid? educationalCycleId, Guid? teacherId)
        {
            var response = await _requestSender.SendGetRequestAsync("https://localhost:44389/api/EducationalCycles/appoint?educationalCycleId=" + educationalCycleId + "&teacherId=" + teacherId);
            return response.IsSuccessStatusCode;
        }
        public async Task<bool> ThrowOffTeacherForCycle(Guid? educationalCycleId, Guid? teacherId)
        {
            var response = await _requestSender.SendGetRequestAsync("https://localhost:44389/api/EducationalCycles/throwOff?educationalCycleId=" + educationalCycleId + "&teacherId=" + teacherId);
            return response.IsSuccessStatusCode;
           
        }


        public async Task<bool> UpdateEducationalCycle(EducationalCycle educationalCycle)
        {
            var response = await _requestSender.SendPostRequestAsync("https://localhost:44389/api/EducationalCycles/update", educationalCycle);
            return response.IsSuccessStatusCode;
        }
    }
}
