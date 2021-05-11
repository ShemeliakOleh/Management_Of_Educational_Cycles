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
    public class GroupsController : ControllerBase
    {
        private DataManager _dataManager;
        public GroupsController(DataManager dataManager)
        {
            _dataManager = dataManager;
        }
        [HttpGet("list")]
        public async Task<IActionResult> GetList()
        {
            var groups = await _dataManager._baseRepository.GetAll<Group>();
            if (groups != null)
            {
                return Ok(groups);
            }
            else
            {
                return Problem();
            }
        }
        [HttpPost("update")]
        public async Task<IActionResult> UpdateOne([FromBody] Group group)
        {
            if (group != null)
            {

                if (!(await _dataManager._baseRepository.Update(group)))
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
        public async Task<IActionResult> Remove(Guid? id)
        {
            if (await _dataManager._baseRepository.Remove<Group>(id))
            {
                return Ok();
            }
            else
            {
                return Problem("object with id = " + id + " not found");
            }
        }
        [HttpPost("create")]
        public async Task<IActionResult> Create([FromBody] Group group)
        {
            if (group != null)
            {
                await _dataManager._baseRepository.Add<Group>(group);
                return Ok();
            }
            else
            {
                return BadRequest("Object is null");
            }

        }
        [HttpGet("one")]
        public async Task<IActionResult> GetOneById(Guid? id)
        {
            return Ok(await _dataManager._baseRepository.GetById<Group>(id));
        }
    }
}
