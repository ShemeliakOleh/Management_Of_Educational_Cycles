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
    public class TeachersRepository : ITeachersRepository
    {
        private readonly ApplicationContext _context;

        public TeachersRepository(ApplicationContext context)
        {
            this._context = context;
        }
        public async Task<bool> Add([FromBody] Teacher teacher)
        {
            _context.Teachers.Add(teacher);
            await _context.SaveChangesAsync();
            return true;
        }

        public bool Exists(Guid? id)
        {
            return _context.Teachers.Any(e => e.Id == id);
        }

        public async Task<List<Teacher>> GetAll()
        {
            var teachers = await _context.Teachers.ToListAsync();
            if (teachers != null)
            {
                return teachers;
            }
            else
            {
                return new List<Teacher>();
            }
        }

        public async Task<Teacher> GetById(Guid? id)
        {
            var teacher = await _context.Teachers.FirstOrDefaultAsync(m => m.Id == id);
            return teacher;
        }

        public async Task<bool> Remove(Guid? id)
        {
            var teacher = await _context.Teachers.FindAsync(id);

            if (teacher != null)
            {
                _context.Teachers.Remove(teacher);
                await _context.SaveChangesAsync();
                return true;
            }
            else
            {
                return false;
            }
        }

        public async Task<bool> Update([FromBody] Teacher teacher)
        {
            _context.Attach(teacher).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Exists(teacher.Id))
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
