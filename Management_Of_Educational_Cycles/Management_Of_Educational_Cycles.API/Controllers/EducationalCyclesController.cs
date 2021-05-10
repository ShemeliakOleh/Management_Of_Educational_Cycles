using Management_Of_Educational_Cycles.Domain.Entities;
using Management_Of_Educational_Cycles.Domain.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Management_Of_Educational_Cycles.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EducationalCyclesController : ControllerBase
    {
        private readonly ApplicationContext _context;

        public EducationalCyclesController(ApplicationContext context)
        {
            this._context = context;
        }
        [HttpGet("list")]
        public async Task<IActionResult> GetList()
        {
            var EducationalCycles = await _context.EducationalCycles.Include(x => x.Discipline)
            .Include(x => x.Teacher).Include(x => x.Group).ToListAsync();
            return Ok(EducationalCycles);
        }
        [HttpPost("update")]
        public async Task<IActionResult> UpdateOne([FromBody] EducationalCycle educationalCycle)
        {
            _context.Attach(educationalCycle).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EducationalCycleExists(educationalCycle.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            return Ok();
        }
        [HttpGet("one")]
        public async Task<IActionResult> GetById(Guid? id)
        {
            var WorkManagementCycle = await _context.EducationalCycles.Include(x => x.Group).Include(x => x.Discipline).Include(x => x.Teacher).FirstOrDefaultAsync(m => m.Id == id);
            if(WorkManagementCycle != null)
            {
                return Ok(WorkManagementCycle);
            }
            else
            {
                return Problem("object with id = " + id + " not found");
            }
        }
        [HttpGet("remove")]
        public async Task<IActionResult> RemoveById(Guid? id)
        {
            var educationalCycle = await _context.EducationalCycles.FindAsync(id);

            if (educationalCycle != null)
            {
                _context.EducationalCycles.Remove(educationalCycle);
                await _context.SaveChangesAsync();
                return Ok();
            }
            else
            {
                return Problem("object with id = " + id + " not found");
            }
        }
        [HttpPost("create")]
        public async Task<IActionResult> Create([FromBody] EducationalCycle educationalCycle)
        {
            if (educationalCycle != null)
            {
                _context.EducationalCycles.Add(educationalCycle);
                await _context.SaveChangesAsync();
                return Ok();
            }
            else
            {
                return BadRequest("object is null");
            }

        }
        private bool EducationalCycleExists(Guid id)
        {
            return _context.EducationalCycles.Any(e => e.Id == id);
        }
    }
}
