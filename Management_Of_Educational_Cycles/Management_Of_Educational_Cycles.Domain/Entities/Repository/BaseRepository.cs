using Management_Of_Educational_Cycles.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;

namespace Management_Of_Educational_Cycles.Domain.Entities.Repository
{
    public class BaseRepository:IBaseRepository
    {
        private readonly ApplicationContext _context;

    public BaseRepository(ApplicationContext context)
    {
        _context = context;
    }

       public async Task<bool> Add<T>(T entity) where T : BaseEntity
        {
            _context.Set<T>().Add(entity);
            await _context.SaveChangesAsync();
            return true;
        }

        public bool Exists<T>(Guid? id) where T : BaseEntity
        {
            return _context.Set<T>().Any(e => e.Id == id);
        }

        public virtual async Task<List<T>> GetAll<T>() where T : BaseEntity
        {
            var entities = await _context.Set<T>().ToListAsync();
            if (entities != null)
            {
                return entities;
            }
            else
            {
                return new List<T>();
            }
        }

        public virtual async Task<T> GetById<T>(Guid? id) where T : BaseEntity
        {
            var entity = await _context.Set<T>().FirstOrDefaultAsync(m => m.Id == id);
            return entity;
        }

        public async Task<bool> Remove<T>(Guid? id) where T : BaseEntity
        {
            var entity = await _context.Set<T>().FindAsync(id);

            if (entity != null)
            {
                _context.Set<T>().Remove(entity);
                await _context.SaveChangesAsync();
                return true;
            }
            else
            {
                return false;
            }
        }

        public async Task<bool> Update<T>(T entity) where T : BaseEntity
        {
            _context.Attach(entity).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Exists<T>(entity.Id))
                {
                    return false;
                }
                else
                {
                    throw;
                }
            }
            return true;
        }
    }
}
