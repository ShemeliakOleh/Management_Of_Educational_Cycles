using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Management_Of_Educational_Cycles.Domain.Models;
using System.Net.Http;
using Newtonsoft.Json;
using Management_Of_Educational_Cycles.Logic.Services;

namespace Management_Of_Educational_Cycles.View.Pages.Faculties
{
    public class DetailsModel : BasePageModel
    {

        public DetailsModel(EntitieViewModelsManager viewManager, DataManager dataManager) : base(viewManager, dataManager)
        {

        }

        public Faculty Faculty { get; set; }
        public List<Department> Departments {get; set;}

        public async Task<IActionResult> OnGetAsync(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            
            Faculty = await dataManager.facultiesRepository.GetById(id);
            Departments = Faculty.Departments;
            if (Faculty == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
