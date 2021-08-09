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
    public class FacultiesRepository : EntityRepository,IFacultiesRepository
    {
        public FacultiesRepository(IRequestSender requestSender) : base(requestSender)
        {

        }
        public async Task<bool> CreateFaculty(Faculty faculty)
        {
            var response = await _requestSender.SendPostRequestAsync("https://localhost:44389/api/Faculties/create", faculty);
            return response.IsSuccessStatusCode;
        }

        public async Task<bool> DeleteById(Guid? id)
        {
            var response = await _requestSender.SendGetRequestAsync("https://localhost:44389/api/Faculties/remove?id=" + id);
            return response.IsSuccessStatusCode;
        }

        public async Task<Faculty> GetById(Guid? id)
        {
            return await _requestSender.GetContetFromRequestAsyncAs<Faculty>(
               await _requestSender.SendGetRequestAsync("https://localhost:44389/api/Faculties/one?id=" + id)
               );
        }

        public async Task<List<Faculty>> GetAllFaculties()
        {
            return await _requestSender.GetContetFromRequestAsyncAs<List<Faculty>>(
               await _requestSender.SendGetRequestAsync("https://localhost:44389/api/Faculties/list")
               );
        }

        public async Task<List<Faculty>> GetFilteredFaculties(Faculty pattern)
        {
            return await _requestSender.GetContetFromRequestAsyncAs<List<Faculty>>(
               await _requestSender.SendPostRequestAsync("https://localhost:44389/api/Faculties/filter", pattern)
               );
        }
        public async Task<bool> UpdateFaculty(Faculty faculty)
        {
            var response = await _requestSender.SendPostRequestAsync("https://localhost:44389/api/Faculties/update", faculty);
            return response.IsSuccessStatusCode;
        }
    }
}
