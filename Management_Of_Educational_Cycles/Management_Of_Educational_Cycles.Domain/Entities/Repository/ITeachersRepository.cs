using Management_Of_Educational_Cycles.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;

namespace Management_Of_Educational_Cycles.Domain.Entities.Repository
{
    public interface ITeachersRepository
    {
        public Task<bool> Add([FromBody] Teacher teacher);
        public Task<bool> Update([FromBody] Teacher teacher);
        public Task<bool> Remove(Guid? id);
        public Task<Teacher> GetById(Guid? id);
        public Task<List<Teacher>> GetAll();
        public bool Exists(Guid? id);
    }
}
