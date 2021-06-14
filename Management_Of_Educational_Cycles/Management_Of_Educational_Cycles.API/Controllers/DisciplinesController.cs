using Management_Of_Educational_Cycles.Domain.Entities;
using Management_Of_Educational_Cycles.Domain.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Management_Of_Educational_Cycles.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DisciplinesController : ControllerBase
    {
        private DataManager _dataManager;

        public DisciplinesController(DataManager dataManager)
        {
            _dataManager = dataManager;
        }
        [HttpGet("list")]
        public async Task<IActionResult> GetList()
        {
            var entities = await _dataManager._disciplineRepository.GetAll();
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
            return Ok(await _dataManager._disciplineRepository.GetById(id));
        }
        [HttpPost("create")]
        public async Task<IActionResult> Create([FromBody] Discipline discipline)
        {
            if (discipline != null)
            {
                await _dataManager._disciplineRepository.Add(discipline);
                return Ok();
            }
            else
            {
                return BadRequest("Object is null");
            }

        }
        [HttpPost("update")]
        public async Task<IActionResult> Update(Discipline discipline)
        {

            if (discipline != null)
            {

                if (!(await _dataManager._disciplineRepository.Update(discipline)))
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
            if (await _dataManager._disciplineRepository.Remove(id))
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
