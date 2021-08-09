using Management_Of_Educational_Cycles.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Management_Of_Educational_Cycles.Logic.Interfaces.IEntityRepository
{
    public interface IDisciplinesRepository
    {
        public Task<Discipline> GetById(Guid? id);
        public Task<List<Discipline>> GetAllDisciplines();
        public Task<bool> CreateDiscipline(Discipline discipline);
        public Task<bool> UpdateDiscipline(Discipline discipline);
        public Task<bool> DeleteById(Guid? id);
        public Task<List<Discipline>> GetFilteredDisciplines(Discipline pattern);
    }
}
