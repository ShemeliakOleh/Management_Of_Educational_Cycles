using Management_Of_Educational_Cycles.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Management_Of_Educational_Cycles.Domain.Entities.Repository
{
    public class GroupRepository : IGroupRepository
    {
        private readonly ApplicationContext _context;
        public GroupRepository(ApplicationContext context)
        {
            _context = context;
        }
        public async Task<bool> Add(Group group)
        {
            var groupToDb = new Group() { Name = group.Name};
            var faculty = _context.Faculties.FirstOrDefault(x => x.Id == group.FacultyId);
            var department = _context.Departments.FirstOrDefault(x => x.Id == group.DepartmentId);
            _context.Groups.Add(groupToDb);
            groupToDb.Faculty = faculty;
            groupToDb.Department = department;
            await _context.SaveChangesAsync();
            return true;
        }

        public bool Exists(Guid? id)
        {
            return _context.Groups.Any(e => e.Id == id);
        }

        public async Task<List<Group>> GetAll()
        {
            var groups = await _context.Groups.Include(u => u.Department).Include(u => u.Faculty).ToListAsync();

            if (groups != null)
            {
                return groups;
            }
            else
            {
                return new List<Group>();
            }
        }

        public async Task<Group> GetById(Guid? id)
        {
            var group = await _context.Groups.Include(u => u.Department).Include(u => u.Faculty).FirstOrDefaultAsync(u => u.Id == id);
            return group;
        }

        public async Task<bool> Remove(Guid? id)
        {
            var teacher = await _context.Groups.FindAsync(id);

            if (teacher != null)
            {
                _context.Groups.Remove(teacher);
                await _context.SaveChangesAsync();
                return true;
            }
            else
            {
                return false;
            }
        }

        public async Task<bool> Update(Group group)
        {
            var groupFromDb = _context.Groups.FirstOrDefault(x => x.Id == group.Id);
            groupFromDb.Name = group.Name;
            groupFromDb.DepartmentId = group.DepartmentId;
            groupFromDb.FacultyId = group.FacultyId;

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
