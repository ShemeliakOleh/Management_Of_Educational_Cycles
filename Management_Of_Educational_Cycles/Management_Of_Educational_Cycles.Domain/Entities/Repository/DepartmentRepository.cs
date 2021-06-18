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
    public class DepartmentRepository : IDepartmentRepository
    {
        private readonly ApplicationContext _context;
        public DepartmentRepository(ApplicationContext context)
        {
            _context = context;
        }
        public async Task<bool> Add(Department department)
        {
            _context.Departments.Add(department);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (Exception)
            {

                throw;
            }
            
            return true;
        }


        public bool Exists(Guid? id)
        {

            return _context.Faculties.Any(e => e.Id == id);

        }

        public async Task<List<Department>> GetAll()
        {
            var departments = await _context.Departments.Include(x => x.Groups).ToListAsync();
            if (departments != null)
            {
                return departments;
            }
            else
            {
                return new List<Department>();
            }
        }

        //public async Task<IEnumerable<SelectListItem>> GetAllAsSelectList(Guid? facultyId)
        //{
        //    var faculty =await _context.Faculties.Include(x=>x.Departments).AsNoTracking().FirstOrDefaultAsync(x => x.Id == facultyId);
        //    List<SelectListItem> departments = faculty.Departments
        //        .OrderBy(n => n.Name)
        //        .Select(n =>
        //            new SelectListItem
        //            {
        //                Value = n.Id.ToString(),
        //                Text = n.Name
        //            }).ToList();
        //    var departmenttip = new SelectListItem()
        //    {
        //        Value = null,
        //        Text = "--- select department ---"
        //    };
        //    departments.Insert(0, departmenttip);
        //    return new SelectList(departments, "Value", "Text");
        //}

        public async Task<Department> GetById(Guid? id)
        {
            var department = await _context.Departments.Include(u => u.Groups)
                .FirstOrDefaultAsync(u => u.Id == id);
            return department;
        }


        public async Task<bool> Remove(Guid? id)
        {
            var department =await _context.Departments.Include(x => x.Groups).Include(x=>x.Teachers).SingleOrDefaultAsync(x => x.Id == id);

            if (department != null)
            {
                _context.Departments.Remove(department);
                await _context.SaveChangesAsync();
                return true;
            }
            else
            {
                return false;
            }
        }

        public async Task<bool> Update(Department department)
        {

            _context.Attach(department).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Exists(department.Id))
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
