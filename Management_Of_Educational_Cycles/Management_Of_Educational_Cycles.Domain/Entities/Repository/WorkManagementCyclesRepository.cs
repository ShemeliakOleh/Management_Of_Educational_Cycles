using Management_Of_Educational_Cycles.Domain.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;

namespace Management_Of_Educational_Cycles.Domain.Entities.Repository
{
   public class WorkManagementCyclesRepository : IWorkManagementCyclesRepository
    {
        private readonly ApplicationContext _context;

        public WorkManagementCyclesRepository(ApplicationContext context)
        {
            this._context = context;
        }
        public async Task<bool> Add(WorkManagementCycle workManagementCycle)
        {
            _context.WorkManagementCycles.Add(workManagementCycle);
            await _context.SaveChangesAsync();
            return true;
        }

        public bool Exists(Guid? id)
        {
            
            return _context.WorkManagementCycles.Any(e => e.Id == id);
            
        }

        public async Task<List<WorkManagementCycle>> GetAll()
        {
            var workManagementCycles =await _context.WorkManagementCycles.Include(u => u.Teachers).Include(u => u.Group).ToListAsync();
            if (workManagementCycles != null)
            {
                return workManagementCycles;
            }
            else
            {
                return new List<WorkManagementCycle>();
            }
        }

        public async Task<WorkManagementCycle> GetById(Guid? id)
        {
            var WorkManagementCycle = await _context.WorkManagementCycles.Include(x => x.Teachers).Include(x => x.Group).FirstOrDefaultAsync(m => m.Id == id);
            return WorkManagementCycle;
        }


        public async Task<bool> Remove(Guid? id)
        {
            var WorkManagementCycle = await _context.WorkManagementCycles.FindAsync(id);

            if (WorkManagementCycle != null)
            {
                _context.WorkManagementCycles.Remove(WorkManagementCycle);
                await _context.SaveChangesAsync();
                return true;
            }
            else
            {
                return false;
            }
        }

        public async Task<bool> Update(WorkManagementCycle workManagementCycle)
        {
            
            _context.Attach(workManagementCycle).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Exists(workManagementCycle.Id))
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
        public async Task<bool> Appoint(Guid? teacherId, Guid? workManagementCycleId)
        {
            var cycle = await _context.WorkManagementCycles.Include(x=>x.Teachers).FirstOrDefaultAsync(x => x.Id == workManagementCycleId);
            var teacher = await _context.Teachers.FirstOrDefaultAsync(x => x.Id == teacherId);

            cycle.Teachers.Add(teacher);
            _context.SaveChanges();



            return true;
        }

        public async Task<bool> ThrowOff(Guid? teacherId, Guid? workManagementCycleId)
        {
            var cycle = await _context.WorkManagementCycles.Include(x=>x.Teachers).FirstOrDefaultAsync(x => x.Id == workManagementCycleId);
            

            cycle.Teachers.RemoveAll(x=>x.Id == teacherId);
            _context.SaveChanges();
           


            return true;
        }
    }
}
