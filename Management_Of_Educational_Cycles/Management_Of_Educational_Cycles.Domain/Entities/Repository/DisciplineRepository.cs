using Management_Of_Educational_Cycles.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Management_Of_Educational_Cycles.Domain.Entities.Repository
{
    public class DisciplineRepository : IDisciplineRepository
    {
        private readonly ApplicationContext _context;
        public DisciplineRepository(ApplicationContext context)
        {
            _context = context;
        }
        public async Task<bool> Add(Discipline discipline)
        {
            _context.Disciplines.Add(discipline);
            await _context.SaveChangesAsync();
            return true;
        }

        public bool Exists(Guid? id)
        {
            return _context.Disciplines.Any(e => e.Id == id);
        }

        public async Task<List<Discipline>> GetAll()
        {
            var disciplines = await _context.Disciplines.ToListAsync();
            if (disciplines != null)
            {
                return disciplines;
            }
            else
            {
                return new List<Discipline>();
            }
        }

        public async Task<Discipline> GetById(Guid? id)
        {
            var discipline = await _context.Disciplines.FirstOrDefaultAsync(u => u.Id == id);
            return discipline;
        }

        public async Task<bool> Remove(Guid? id)
        {
            var discpline = await _context.Disciplines.FindAsync(id);

            if (discpline != null)
            {
                _context.Disciplines.Remove(discpline);
                await _context.SaveChangesAsync();
                return true;
            }
            else
            {
                return false;
            }
        }

        public async Task<bool> Update(Discipline discipline)
        {
            _context.Attach(discipline).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Exists(discipline.Id))
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
