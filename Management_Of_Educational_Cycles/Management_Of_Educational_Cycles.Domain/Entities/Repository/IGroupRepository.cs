using Management_Of_Educational_Cycles.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Management_Of_Educational_Cycles.Domain.Entities.Repository
{
   public interface IGroupRepository
    {
        public Task<bool> Add(Group group);
        public Task<bool> Update(Group group);
        public Task<bool> Remove(Guid? id);
        public Task<Group> GetById(Guid? id);
        public Task<List<Group>> GetAll();
        public bool Exists(Guid? id);
    }
}
