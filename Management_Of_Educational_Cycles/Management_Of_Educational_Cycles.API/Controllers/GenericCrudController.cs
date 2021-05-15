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
    public abstract class GenericCrudController<T>: ControllerBase where T : BaseEntity
    {
        protected readonly DataManager _dataManager;
        
        public GenericCrudController(DataManager dataManager)
        {
            _dataManager = dataManager;
        }
        [HttpGet("list")]
        virtual public async Task<IActionResult> GetList()
        {
            var entities = await _dataManager._baseRepository.GetAll<T> ();
            if (entities != null)
            {
                return Ok(entities);
            }
            else
            {
                return Problem();
            }
        }
        [HttpPost("update")]
        virtual public async Task<IActionResult> UpdateOne([FromBody] T entity)
        {
            if (entity != null)
            {

                if (!(await _dataManager._baseRepository.Update(entity)))
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
        virtual public async Task<IActionResult> Remove(Guid? id)
        {
            if (await _dataManager._baseRepository.Remove<T>(id))
            {
                return Ok();
            }
            else
            {
                return Problem("object with id = " + id + " not found");
            }
        }
        [HttpPost("create")]
        virtual public async Task<IActionResult> Create([FromBody] T entity)
        {
            if (entity != null)
            {
                await _dataManager._baseRepository.Add<T>(entity);
                return Ok();
            }
            else
            {
                return BadRequest("Object is null");
            }

        }
        [HttpGet("one")]
        virtual public async Task<IActionResult> GetOneById(Guid? id)
        {
            return Ok(await _dataManager._baseRepository.GetById<T>(id));
        }
    }
}
