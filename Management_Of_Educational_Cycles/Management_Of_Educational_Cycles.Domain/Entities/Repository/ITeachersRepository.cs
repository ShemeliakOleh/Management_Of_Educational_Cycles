using Management_Of_Educational_Cycles.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Management_Of_Educational_Cycles.Domain.Entities.Repository
{
    public interface ITeachersRepository
    {
        public Task<bool> Add(Teacher teacher);
        public Task<bool> Update(Teacher teacher);
        public Task<bool> Remove(Guid? id);
        public Task<Teacher> GetById(Guid? id);
        public Task<List<Teacher>> GetAll();
        public bool Exists(Guid? id);
    }
}
