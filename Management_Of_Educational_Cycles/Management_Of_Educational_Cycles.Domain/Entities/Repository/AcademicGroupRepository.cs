using Management_Of_Educational_Cycles.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Management_Of_Educational_Cycles.Domain.Entities.Repository
{
    public class AcademicGroupRepository : IAcademicGroupRepository
    {
        private readonly ApplicationContext _context;
        public AcademicGroupRepository(ApplicationContext context)
        {
            _context = context;
        }
        public async Task<bool> Add(AcademicGroup group)
        {
            _context.AcademicGroups.Add(group);
            await _context.SaveChangesAsync();
            return true;
        }

        public bool Exists(Guid? id)
        {
            return _context.AcademicGroups.Any(e => e.Id == id);
        }

        public async Task<List<AcademicGroup>> GetAll()
        {
            var groups = await _context.AcademicGroups.Include(u => u.Department).ToListAsync();

            if (groups != null)
            {
                return groups;
            }
            else
            {
                return new List<AcademicGroup>();
            }
        }

        public async Task<AcademicGroup> GetById(Guid? id)
        {
            var group = await _context.AcademicGroups.Include(u => u.Department).FirstOrDefaultAsync(u => u.Id == id);
            return group;
        }

        public async Task<bool> Remove(Guid? id)
        {
            var teacher = await _context.AcademicGroups.FindAsync(id);

            if (teacher != null)
            {
                _context.AcademicGroups.Remove(teacher);
                await _context.SaveChangesAsync();
                return true;
            }
            else
            {
                return false;
            }
        }

        public async Task<bool> Update(AcademicGroup group)
        {
            var groupFromDb = _context.AcademicGroups.FirstOrDefault(x => x.Id == group.Id);
            groupFromDb.Name = group.Name;
            groupFromDb.DepartmentId = group.DepartmentId;
            

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Exists(group.Id))
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
