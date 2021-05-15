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
        private DataManager _dataManager;
        public WorkManagementCyclesController(DataManager dataManager)
        {
            _dataManager = dataManager;
        }
        [HttpPost("update")]
        public async Task<IActionResult> Update(WorkManagementCycle workManagementCycle)
        {

            if (workManagementCycle != null)
            {

                if (!(await _dataManager._workManagementCyclesRepository.Update(workManagementCycle)))
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
        [HttpPost("appoint")]
        public async Task<IActionResult> Appoint([FromBody] WorkManagementCycle workManagementCycle)
        {

            if (workManagementCycle != null)
            {

                if (!(await _dataManager._workManagementCyclesRepository.Appoint(workManagementCycle)))
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
        [HttpGet("list")]
        public async Task<IActionResult> GetList()
        {
            var workManagementRepository = await _dataManager._workManagementCyclesRepository.GetAll();
            if (workManagementRepository != null)
            {
                return Ok(workManagementRepository);
            }
            else
            {
                return Problem();
            }
            
        }
        [HttpGet("one")]
        public async Task<IActionResult> GetById(Guid? id)
        {
            return Ok(await _dataManager._workManagementCyclesRepository.GetById(id));
        }
        [HttpGet("remove")]
        public async Task<IActionResult> RemoveById(Guid? id)
        {
            if(await _dataManager._workManagementCyclesRepository.Remove(id))
            {
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
                await _dataManager._workManagementCyclesRepository.Add(workManagementCycle);
                return Ok();
            }
            else
            {
                return BadRequest("Object is null");
            }

        }
      
    }
}
