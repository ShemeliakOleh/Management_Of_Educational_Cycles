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
    public class DepartmentsController : ControllerBase
    {
        private DataManager _dataManager;

        public DepartmentsController(DataManager dataManager)
        {
            _dataManager = dataManager;
        }
        [HttpGet("list")]
        public async Task<IActionResult> GetList()
        {
            var entities = await _dataManager._departmentRepository.GetAll();
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
            return Ok(await _dataManager._departmentRepository.GetById(id));
        }
        [HttpPost("create")]
        public async Task<IActionResult> Create([FromBody] Department department)
        {
            if (department != null)
            {
                await _dataManager._departmentRepository.Add(department);
                return Ok();
            }
            else
            {
                return BadRequest("Object is null");
            }

        }
        [HttpPost("update")]
        public async Task<IActionResult> Update(Department department)
        {

            if (department != null)
            {

                if (!(await _dataManager._departmentRepository.Update(department)))
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
    }
}
