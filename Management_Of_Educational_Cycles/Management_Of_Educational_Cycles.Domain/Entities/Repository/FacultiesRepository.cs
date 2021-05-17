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
    public class FacultiesRepository : IFacultiesRepository
    {
        private readonly ApplicationContext _context;
        public FacultiesRepository(ApplicationContext context)
        {
            _context = context;
        }
        public async Task<bool> Add(Faculty faculty)
        {
            _context.Faculties.Add(faculty);
            await _context.SaveChangesAsync();
            return true;
        }


        public bool Exists(Guid? id)
        {

            return _context.Faculties.Any(e => e.Id == id);

        }

        public async Task<List<Faculty>> GetAll()
        {
            var faculties = await _context.Faculties.Include(x=>x.Departments)
                .Include(u => u.Disciplines).ToListAsync();
            if (faculties != null)
            {
                return faculties;
            }
            else
            {
                return new List<Faculty>();
            }
        }

        //public async Task<IEnumerable<SelectListItem>> GetAllAsSelectList()
        //{
        //    List<SelectListItem> faculties =await _context.Faculties.AsNoTracking()
        //        .OrderBy(n => n.Name)
        //        .Select(n =>
        //            new SelectListItem
        //            {
        //                Value = n.Id.ToString(),
        //                Text = n.Name
        //            }).ToListAsync();
        //    var facultytip = new SelectListItem()
        //    {
        //        Value = null,
        //        Text = "--- select faculty ---"
        //    };
        //    faculties.Insert(0, facultytip);
        //    return new SelectList(faculties, "Value", "Text");
        //}

        public async Task<Faculty> GetById(Guid? id)
        {
            var faculty = await _context.Faculties.Include(u => u.Departments).Include(u => u.Disciplines)
                .FirstOrDefaultAsync(u => u.Id == id);
            return faculty;
        }


        public async Task<bool> Remove(Guid? id)
        {
            var faculty = await _context.Faculties.FindAsync(id);

            if (faculty != null)
            {
                _context.Faculties.Remove(faculty);
                await _context.SaveChangesAsync();
                return true;
            }
            else
            {
                return false;
            }
        }

        public async Task<bool> Update(Faculty faculty)
        {

            _context.Attach(faculty).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Exists(faculty.Id))
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
