using Management_Of_Educational_Cycles.Domain.Entities;
using Management_Of_Educational_Cycles.Domain.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Management_Of_Educational_Cycles.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WorkManagementCyclesController : ControllerBase
    {
        private ApplicationContext _context;

        public WorkManagementCyclesController(ApplicationContext context)
        {
            _context = context;
        }
        [HttpPost("update")]
        public async Task<IActionResult> Update(WorkManagementCycle workManagementCycle)
        {
            _context.Attach(workManagementCycle).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!WorkManagementCycleExists(workManagementCycle.Id))
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
        [HttpGet("list")]
        public async Task<IActionResult> GetList()
        {
            var ListOfWorkManagementCycle = await _context.WorkManagementCycles.Include(u => u.Group).Include(u => u.Teachers).ToListAsync();
            return Content(JsonConvert.SerializeObject(ListOfWorkManagementCycle));
        }
        [HttpGet("one")]
        public async Task<IActionResult> GetById(Guid? id)
        {
            var WorkManagementCycle = await _context.WorkManagementCycles.Include(x => x.Group).Include(x=>x.Teachers).FirstOrDefaultAsync(m => m.Id == id);
            return Content(JsonConvert.SerializeObject(WorkManagementCycle));
        }
        [HttpGet("remove")]
        public async Task<IActionResult> RemoveById(Guid? id)
        {
            var WorkManagementCycle = await _context.WorkManagementCycles.FindAsync(id);

            if (WorkManagementCycle != null)
            {
                _context.WorkManagementCycles.Remove(WorkManagementCycle);
                await _context.SaveChangesAsync();
                return Ok();
            }
            else
            {
                return Problem("object with id = " + id + " not found");
            }

        }
        [HttpPost("create")]
        public async Task<IActionResult> Create([FromBody] WorkManagementCycle workManagementCycle) 
        {
            if(workManagementCycle!= null) { 
                _context.WorkManagementCycles.Add(workManagementCycle);
                await _context.SaveChangesAsync();
                return Ok();
            }
            else
            {
                return BadRequest("object is null");
            }

        }
        private bool WorkManagementCycleExists(Guid id)
        {
            return _context.WorkManagementCycles.Any(e => e.Id == id);
        }
    }
}
