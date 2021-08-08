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
        public Task<bool> CreateTeacher(Teacher teacher)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteById(Guid? id)
        {
            throw new NotImplementedException();
        }

        public Task<Teacher> GetById(Guid? id)
        {
            throw new NotImplementedException();
        }

        public Task<List<Teacher>> GetFilteredTeachers(Teacher pattern)
        {
            throw new NotImplementedException();
        }

        public Task<List<Teacher>> GetTeachers()
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateTeacher(Teacher teacher)
        {
            throw new NotImplementedException();
        }
    }
}
