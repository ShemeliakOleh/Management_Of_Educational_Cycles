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
using System.Text;
using Newtonsoft.Json;
using Management_Of_Educational_Cycles.Logic.Services;
using System.IO;

namespace Management_Of_Educational_Cycles.View.Pages.WorkManagementCycles
{
    public class CreateModel : BasePageModel
    {
       
        [BindProperty(SupportsGet = true)]
        public WorkManagementCycleEditViewModel WorkManagementCycleEditViewModel { get; set; }

        public CreateModel(IRequestSender requestSender, IDropDownService dropDownService) : base(requestSender, dropDownService)
        {
         
        }

        public async Task<IActionResult> OnGet()
        {
            WorkManagementCycleEditViewModel = await _dropDownService.CreateWorkMangementCycle();
            return Page();
        }
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }






            await _dropDownService.SaveWorkManagementCycle(WorkManagementCycleEditViewModel);
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
