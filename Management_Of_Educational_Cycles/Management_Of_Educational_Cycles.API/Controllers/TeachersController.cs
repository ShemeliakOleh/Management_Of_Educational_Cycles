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
    public class TeachersController : GenericCrudController<Teacher>
    {
        public TeachersController(DataManager dataManager) : base(dataManager)
        {

            
        }
        [HttpGet("list")]
        public override async Task<IActionResult> GetList()
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
        public override async Task<IActionResult> GetOneById(Guid? id)
        {
            return Ok(await _dataManager._teachersRepository.GetById(id));
        }

    }
}
