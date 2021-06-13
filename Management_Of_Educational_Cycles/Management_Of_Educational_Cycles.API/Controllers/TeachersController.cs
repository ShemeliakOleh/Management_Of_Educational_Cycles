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
        private DataManager _dataManager;

        public TeachersController(DataManager dataManager)
        {
            _dataManager = dataManager;
        }
        [HttpGet("list")]
        public async Task<IActionResult> GetList()
        {
            var entities = await _dataManager._teachersRepository.GetAll();
            if (entities != null)
            {
                return Ok(entities);
            }
            else
            {
                return Problem();
            }
        }
        [HttpGet("one")]
        public async Task<IActionResult> GetOneById(Guid? id)
        {
            return Ok(await _dataManager._teachersRepository.GetById(id));
        }
        [HttpPost("create")]
        public async Task<IActionResult> Create([FromBody] Teacher teacher)
        {
            if (teacher != null)
            {
                await _dataManager._teachersRepository.Add(teacher);
                return Ok();
            }
            else
            {
                return BadRequest("Object is null");
            }

        }
        [HttpPost("update")]
        public async Task<IActionResult> Update(Teacher teacher)
        {

            if (teacher != null)
            {

                if (!(await _dataManager._teachersRepository.Update(teacher)))
                {
                    return NotFound();
                }
                else
                {
                    return Ok();
                }

            }
            else
            {
                return Problem("object is null");
            }


        }
        [HttpGet("remove")]
        public async Task<IActionResult> RemoveById(Guid? id)
        {
            if (await _dataManager._teachersRepository.Remove(id))
            {
                return Ok();
            }
            else
            {
                return Problem("object with id = " + id + " not found");
            }

        }
    }
}
