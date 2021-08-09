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
    public class DisciplinesRepository :EntityRepository ,IDisciplinesRepository
    {
        public DisciplinesRepository(IRequestSender requestSender) : base(requestSender)
        {

        }
        public async Task<bool> CreateDiscipline(Discipline discipline)
        {
            var response = await _requestSender.SendPostRequestAsync("https://localhost:44389/api/Disciplines/create", discipline);
            return response.IsSuccessStatusCode;
        }

        public async Task<bool> DeleteById(Guid? id)
        {
            var response = await _requestSender.SendGetRequestAsync("https://localhost:44389/api/Disciplines/remove?id=" + id);
            return response.IsSuccessStatusCode;
        }

        public async Task<Discipline> GetById(Guid? id)
        {
            return await _requestSender.GetContetFromRequestAsyncAs<Discipline>(
               await _requestSender.SendGetRequestAsync("https://localhost:44389/api/Disciplines/one?id=" + id)
               );
        }

        public async Task<List<Discipline>> GetAllDisciplines()
        {
            return await _requestSender.GetContetFromRequestAsyncAs<List<Discipline>>(
               await _requestSender.SendGetRequestAsync("https://localhost:44389/api/Disciplines/list")
               );
        }

        public async Task<List<Discipline>> GetFilteredDisciplines(Discipline pattern)
        {
            return await _requestSender.GetContetFromRequestAsyncAs<List<Discipline>>(
               await _requestSender.SendPostRequestAsync("https://localhost:44389/api/Disciplines/filter", pattern)
               );
        }
        public async Task<bool> UpdateDiscipline(Discipline discipline)
        {
            var response = await _requestSender.SendPostRequestAsync("https://localhost:44389/api/Disciplines/update", discipline);
            return response.IsSuccessStatusCode;
        }

    }
}
