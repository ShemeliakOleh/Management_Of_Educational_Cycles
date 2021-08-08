using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Management_Of_Educational_Cycles.Domain.Entities;
using Management_Of_Educational_Cycles.Domain.Models;
using System.Net.Http;
using Newtonsoft.Json;
using System.Text;
using Management_Of_Educational_Cycles.Logic.Services;

namespace Management_Of_Educational_Cycles.View.Pages.EducationalCycles
{
    public class CreateModel : BasePageModel
    {
        
        [BindProperty(SupportsGet = true)]
        public EducationalCycleEditViewModel educationalCycleEditViewModel { get; set; }

        public CreateModel(EntitieViewModelsManager viewManager): base(viewManager)
        {
           
        }

        public IActionResult OnGet()
        {
            educationalCycleEditViewModel = viewManager.educationalCyclesProvider.CreateEducationalCycleEditViewModel();
            return Page();
        }
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            await viewManager.educationalCyclesProvider.SaveEducationalCycle(educationalCycleEditViewModel);
            //if (response.IsSuccessStatusCode)
            //{
            //    //DO something
            //}
            //else
            //{
            //    //DO something
            //}

            return RedirectToPage("./Index");
        }
    }
}
