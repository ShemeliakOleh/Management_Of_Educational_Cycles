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
    public class TeachersController : ControllerBase
    {
        private readonly ApplicationContext _context;

        public TeachersController(ApplicationContext context)
        {
            this._context = context;
        }
        [HttpGet("list")]
        public async Task<IActionResult> GetList()
        {
            var Teachers = await _context.Teachers.ToListAsync();
            if(Teachers!= null)
            {
                return Ok(Teachers);
            }
            else
            {
                return Ok(new List<Teacher>());
            }
        }
        [HttpPost("update")]
        public async Task<IActionResult> UpdateOne([FromBody] Teacher teacher)
        {
            _context.Attach(teacher).State = EntityState.Modified;
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TeacherExists(teacher))
                {
                    return Problem("object with id = " + teacher.Id + " not found");
                }
                else
                {
                    throw;
                }
            }
            return Ok();

        }
        [HttpGet("remove")]
        public async Task<IActionResult> Remove(Guid? id)
        {
            var teacher =await _context.Teachers.FirstOrDefaultAsync(x => x.Id == id);
            if(teacher != null)
            {
                _context.Teachers.Remove(teacher);
                await _context.SaveChangesAsync();
                return Ok();
            }
            else
            {
                return Problem("object with id = " + teacher.Id + " not found");
            }
        }
        [HttpPost("create")]
        public async Task<IActionResult> Create([FromBody] Teacher teacher)
        {
            if (teacher != null)
            {
                _context.Teachers.Add(teacher);
                await _context.SaveChangesAsync();
                return Ok();
            }
            else
            {
                return BadRequest("object is null");
            }

        }
        [HttpGet("one")]
        public async Task<IActionResult> GetOneById(Guid? id)
        {
            var teacher = await _context.Teachers.FirstOrDefaultAsync(x => x.Id == id);
            if(teacher != null)
            {
                return Ok(teacher);
            }
            else
            {
                return Problem("object with id = " + teacher.Id + " not found");
            }
        }
        private bool TeacherExists (Teacher teacher)
        {
            return _context.Teachers.Any(x => x.Id == teacher.Id);
        }
    }
}
