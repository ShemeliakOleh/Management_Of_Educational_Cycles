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
    public class TeachersRepository : EntityRepository,ITeachersRepository
    {
        public TeachersRepository(IRequestSender requestSender) : base(requestSender)
        {

        }
        public async Task<bool> CreateTeacher(Teacher teacher)
        {
            var response = await _requestSender.SendPostRequestAsync("https://localhost:44389/api/Teachers/create", teacher);
            return response.IsSuccessStatusCode;
        }

        public async Task<bool> DeleteById(Guid? id)
        {
            var response = await _requestSender.SendGetRequestAsync("https://localhost:44389/api/Teachers/remove?id=" + id);
            return response.IsSuccessStatusCode;
        }

        public async Task<Teacher> GetById(Guid? id)
        {
            return await _requestSender.GetContetFromRequestAsyncAs<Teacher>(
              await _requestSender.SendGetRequestAsync("https://localhost:44389/api/Teachers/one?id=" + id)
              );
        }

        public async Task<List<Teacher>> GetFilteredTeachers(Teacher pattern)
        {
            return await _requestSender.GetContetFromRequestAsyncAs<List<Teacher>>(
                await _requestSender.SendPostRequestAsync("https://localhost:44389/api/Teachers/filter", pattern)
                );
        }

        public async Task<List<Teacher>> GetAllTeachers()
        {
            return await _requestSender.GetContetFromRequestAsyncAs<List<Teacher>>(
              await _requestSender.SendGetRequestAsync("https://localhost:44389/api/Teachers/list")
              );
        }

        public async Task<bool> UpdateTeacher(Teacher teacher)
        {
            var response = await _requestSender.SendPostRequestAsync("https://localhost:44389/api/Teachers/update", teacher);
            return response.IsSuccessStatusCode;
        }
    }
}
