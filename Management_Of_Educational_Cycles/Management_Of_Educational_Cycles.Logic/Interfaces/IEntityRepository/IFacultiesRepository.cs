using Management_Of_Educational_Cycles.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Management_Of_Educational_Cycles.Logic.Interfaces.IEntityRepository
{
    public interface IFacultiesRepository
    {
        public Task<Faculty> GetById(Guid? id);
        public Task<List<Faculty>> GetAllFaculties();
        public Task<bool> CreateFaculty(Faculty faculty);
        public Task<bool> UpdateFaculty(Faculty faculty);
        public Task<bool> DeleteById(Guid? id);
        public Task<List<Faculty>> GetFilteredFaculties(Faculty pattern);
    }
}
