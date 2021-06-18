﻿using Management_Of_Educational_Cycles.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;

namespace Management_Of_Educational_Cycles.Domain.Entities.Repository
{
    public class EducationalCyclesRepository : IEducationalCyclesRepository
    {
        private readonly ApplicationContext _context;
        public EducationalCyclesRepository(ApplicationContext context)
        {
            _context = context;
        }
        public async Task<bool> Add(EducationalCycle educationalCycle)
        {
            _context.EducationalCycles.Add(educationalCycle);
            await _context.SaveChangesAsync();
            return true;
        }

        public bool Exists(Guid? id)
        {
            return _context.EducationalCycles.Any(e => e.Id == id);
        }

        public async Task<List<EducationalCycle>> GetAll()
        {
            var educationalCycles = await _context.EducationalCycles.Include(x => x.Discipline)
            .Include(x => x.Teacher).Include(x => x.Group).ToListAsync();
            if (educationalCycles != null)
            {
                return educationalCycles;
            }
            else
            {
                return new List<EducationalCycle>();
            }
        }

        public async Task<EducationalCycle> GetById(Guid? id)
        {
            var educationalCycles = await _context.EducationalCycles.Include(x => x.Discipline)
                .Include(x => x.Teacher).Include(x => x.Group).ThenInclude(x=>x.Department).ThenInclude(x=>x.Faculty).FirstOrDefaultAsync(m => m.Id == id);
            return educationalCycles;
        }

        public async Task<bool> Remove(Guid? id)
        {
            var educationalCycle = await _context.EducationalCycles.FindAsync(id);

            if (educationalCycle != null)
            {
                _context.EducationalCycles.Remove(educationalCycle);
                await _context.SaveChangesAsync();
                return true;
            }
            else
            {
                return false;
            }
        }

        public async Task<bool> Update(EducationalCycle educationalCycle)
        {
            _context.Attach(educationalCycle).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Exists(educationalCycle.Id))
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

        public async Task<bool> Appoint(Guid? teacherId, Guid? educationalCycleId)
        {
            var cycle = await _context.EducationalCycles.FirstOrDefaultAsync(x => x.Id == educationalCycleId);
            var teacher = await _context.Teachers.Include(x => x.EducationalCycles).FirstOrDefaultAsync(x => x.Id == teacherId);
            teacher.EducationalCycles.Add(cycle);
            _context.SaveChanges();



            return true;
        }

        public async Task<bool> ThrowOff(Guid? teacherId, Guid? educationalCycleId)
        {
            var teacher = await _context.Teachers.Include(x => x.EducationalCycles).FirstOrDefaultAsync(x => x.Id == teacherId);
            teacher.EducationalCycles.RemoveAll(x => x.Id == educationalCycleId);
            _context.SaveChanges();



            return true;
        }
    }
}
