using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Web.Http;

namespace Management_Of_Educational_Cycles.Domain.Entities.Repository
{
    public interface IGroupsRepository
    {
        public Task<bool> Add([FromBody] Group group);
        public Task<bool> Update([FromBody] Group group);
        public Task<bool> Remove(Guid? id);
        public Task<Group> GetById(Guid? id);
        public Task<List<Group>> GetAll();
        public bool Exists(Guid? id);
    }
}
