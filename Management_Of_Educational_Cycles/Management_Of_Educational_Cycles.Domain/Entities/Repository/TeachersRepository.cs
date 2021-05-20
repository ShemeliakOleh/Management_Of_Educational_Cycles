using Management_Of_Educational_Cycles.Domain.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Management_Of_Educational_Cycles.Domain.Entities.Repository
{
    public class TeachersRepository : ITeachersRepository
    {
        private readonly ApplicationContext _context;
        public TeachersRepository(ApplicationContext context)
        {
            _context = context;
        }
        public async Task<bool> Add(Teacher teacher)
        {
            var teacherToDb = new Teacher() { Name = teacher.Name, Surname = teacher.Surname };
            var faculty = _context.Faculties.FirstOrDefault(x => x.Id == teacher.Faculty.Id);
            var department = _context.Departments.FirstOrDefault(x => x.Id == teacher.Department.Id);
            _context.Teachers.Add(teacherToDb);
            teacherToDb.Faculty = faculty;
            teacherToDb.Department = department;
            await _context.SaveChangesAsync();
            return true;
        }


        public bool Exists(Guid? id)
        {

            return _context.Teachers.Any(e => e.Id == id);

        }

        public async Task<List<Teacher>> GetAll()
        {
            var teachers = await _context.Teachers.Include(u => u.WorkManagementCycles).Include(u => u.EducationalCycles)
                .Include(u => u.Department).Include(u => u.Faculty).ToListAsync();
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
            var teacher = await _context.Teachers.Include(u => u.WorkManagementCycles).Include(u => u.EducationalCycles)
                .Include(u => u.Department).Include(u => u.Faculty).FirstOrDefaultAsync(u => u.Id == id);
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

        public async Task<bool> Update(Teacher teacher)
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
