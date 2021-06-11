using Management_Of_Educational_Cycles.Domain.Entities;
using Management_Of_Educational_Cycles.Domain.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Management_Of_Educational_Cycles.API.Controllers
{// write Crud logic for groups, try dont use clsses faculty and department for adding group and teacher!!
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
            var entities = await _dataManager._groupRepository.GetAll();
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
            return Ok(await _dataManager._groupRepository.GetById(id));
        }
        [HttpPost("create")]
        public async Task<IActionResult> Create([FromBody] Group group)
        {
            if (group != null)
            {
                await _dataManager._groupRepository.Add(group);
                return Ok();
            }
            else
            {
                return BadRequest("Object is null");
            }

        }
        [HttpPost("update")]
        public async Task<IActionResult> Update(Group group)
        {

            if (group != null)
            {

                if (!(await _dataManager._groupRepository.Update(group)))
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
            if (await _dataManager._groupRepository.Remove(id))
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
