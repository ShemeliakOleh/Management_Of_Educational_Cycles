using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Management_Of_Educational_Cycles.Domain.Models;
using Newtonsoft.Json;
using System.Net.Http;
using System.Text;
using Management_Of_Educational_Cycles.Logic.Services;

namespace Management_Of_Educational_Cycles.View.Pages.EducationalCycles
{
    public class EditModel : BasePageModel {
        [BindProperty(SupportsGet = true)]
        public EducationalCycleEditViewModel educationalCycleEditViewModel { get; set; }
        public EditModel(EntitieViewModelsManager viewManager, DataManager dataManager) : base(viewManager, dataManager)
        {

        }


        public async Task<IActionResult> OnGetAsync(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var cycle = await dataManager.educationalCyclesRepository.GetById(id);
            educationalCycleEditViewModel = await viewManager.educationalCyclesProvider.CreateEducationalCycle(cycle);
            return Page();

            if (educationalCycleEditViewModel == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            await viewManager.educationalCyclesProvider.UpdateEducationalCycle(educationalCycleEditViewModel);
            //if (response.IsSuccessStatusCode)
            //{
            //    return RedirectToPage("./Index");
            //}
            //else
            //{
            //    //Do something
            //}

            return RedirectToPage("./Index");
        }
    }
}
