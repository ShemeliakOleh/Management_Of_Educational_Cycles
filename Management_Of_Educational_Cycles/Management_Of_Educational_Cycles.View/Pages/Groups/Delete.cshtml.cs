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

namespace Management_Of_Educational_Cycles.View.Pages.Groups
{
    public class DeleteModel : BasePageModel
    {
      
        public DeleteModel(EntitieViewModelsManager viewManager, DataManager dataManager) : base(viewManager, dataManager)
        {

        }

        [BindProperty]
        public AcademicGroup Group { get; set; }

        public async Task<IActionResult> OnGetAsync(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Group = await dataManager.groupsRepository.GetById(id);
            if (Group == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var response = await dataManager.groupsRepository.DeleteById(id);
            //if (response.IsSuccessStatusCode)
            //{
            //    //DO something
            //}
            //else
            //{
            //    //Do something
            //}

            return RedirectToPage("./Index");
        }
    }
}
