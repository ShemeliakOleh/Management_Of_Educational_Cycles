using Management_Of_Educational_Cycles.Domain.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;

namespace Management_Of_Educational_Cycles.Domain.Entities.Repository
{
   public interface IWorkManagementCyclesRepository
    {
        public Task<bool> Add([FromBody]WorkManagementCycle workManagementCycle);
        public Task<bool> Update([FromBody] WorkManagementCycle workManagementCycle);
        public Task<bool> Remove(Guid? id);
        public Task<WorkManagementCycle> GetById(Guid? id);
        public Task<List<WorkManagementCycle>> GetAll();
        public bool Exists(Guid? id);
    }
}
