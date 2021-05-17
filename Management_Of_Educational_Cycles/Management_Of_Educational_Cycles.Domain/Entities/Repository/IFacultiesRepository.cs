using Management_Of_Educational_Cycles.Domain.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Management_Of_Educational_Cycles.Domain.Entities.Repository
{
    public interface IFacultiesRepository
    {
        public Task<bool> Add(Faculty faculty);
        public Task<bool> Update(Faculty faculty);
        public Task<bool> Remove(Guid? id);
        public Task<Faculty> GetById(Guid? id);
        public Task<List<Faculty>> GetAll();
        public bool Exists(Guid? id);
    }
}
