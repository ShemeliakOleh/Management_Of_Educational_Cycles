using Management_Of_Educational_Cycles.Domain.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;

namespace Management_Of_Educational_Cycles.Domain.Entities.Repository
{
    public interface IBaseRepository
    {
        public Task<bool> Add<T>(T entity) where T : BaseEntity;
        public Task<bool> Update<T>(T entity) where T : BaseEntity;
        public Task<bool> Remove<T>(Guid? id) where T : BaseEntity;
        public Task<T> GetById<T>(Guid? id) where T : BaseEntity;
        public Task<List<T>> GetAll<T>() where T : BaseEntity;
        public bool Exists<T>(Guid? id) where T : BaseEntity;
    }
}
