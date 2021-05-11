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
        private DataManager _dataManager;
        public EducationalCyclesController(DataManager dataManager)
        {
            this._dataManager = dataManager;
        }
        [HttpGet("list")]
        public async Task<IActionResult> GetList()
        {
            var educationalCycles = await _dataManager._educationalCyclesRepository.GetAll();
            if (educationalCycles != null)
            {
                return Ok(educationalCycles);
            }
            else
            {
                return Problem();
            }
        }
        [HttpPost("update")]
        public async Task<IActionResult> UpdateOne([FromBody] EducationalCycle educationalCycle)
        {
            if (educationalCycle != null)
            {

                if (!(await _dataManager._educationalCyclesRepository.Update(educationalCycle)))
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
        [HttpGet("one")]
        public async Task<IActionResult> GetById(Guid? id)
        {
            return Ok(await _dataManager._educationalCyclesRepository.GetById(id));
        }
        [HttpGet("remove")]
        public async Task<IActionResult> RemoveById(Guid? id)
        {
            if (await _dataManager._educationalCyclesRepository.Remove(id))
            {
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
                await _dataManager._educationalCyclesRepository.Add(educationalCycle);
                return Ok();
            }
            else
            {
                return BadRequest("Object is null");
            }

        }
    }
}
