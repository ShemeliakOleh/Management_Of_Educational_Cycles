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
        public Task<bool> CreateFaculty(Faculty faculty)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteById(Guid? id)
        {
            throw new NotImplementedException();
        }

        public async Task<Faculty> GetById(Guid? id)
        {
            var faculty = await _requestSender.GetContetFromRequestAsyncAs<Faculty>(
            await _requestSender.SendGetRequestAsync("https://localhost:44389/api/Faculties/one?id=" + id)
            );
            return faculty;
        }

        public Task<List<Faculty>> GetFaculties()
        {
            throw new NotImplementedException();
        }

        public Task<List<Faculty>> GetFilteredFaculties(Faculty pattern)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateFaculty(Faculty faculty)
        {
            throw new NotImplementedException();
        }
    }
}
