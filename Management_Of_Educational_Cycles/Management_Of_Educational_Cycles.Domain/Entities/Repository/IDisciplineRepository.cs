using Management_Of_Educational_Cycles.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Management_Of_Educational_Cycles.Domain.Entities.Repository
{
   public interface IDisciplineRepository
    {
        public Task<bool> Add(Discipline discipline);
        public Task<bool> Update(Discipline discipline);
        public Task<bool> Remove(Guid? id);
        public Task<Discipline> GetById(Guid? id);
        public Task<List<Discipline>> GetAll();
        public bool Exists(Guid? id);
    }
}
