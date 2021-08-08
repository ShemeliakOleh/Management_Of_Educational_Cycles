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
        public Task<bool> CreateDiscipline(Discipline discipline)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteById(Guid? id)
        {
            throw new NotImplementedException();
        }

        public Task<Discipline> GetById(Guid? id)
        {
            throw new NotImplementedException();
        }

        public Task<List<Discipline>> GetDisciplines()
        {
            throw new NotImplementedException();
        }

        public Task<List<Discipline>> GetFilteredDisciplines(Discipline pattern)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateDiscipline(Discipline discipline)
        {
            throw new NotImplementedException();
        }

    }
}
