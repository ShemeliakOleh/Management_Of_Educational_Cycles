using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Management_Of_Educational_Cycles.Domain.Entities;
using Management_Of_Educational_Cycles.Domain.Models;
using System.Net.Http;
using Newtonsoft.Json;
using System.Text;
using Management_Of_Educational_Cycles.Logic.Services;
using System.IO;

namespace Management_Of_Educational_Cycles.View.Pages.WorkManagementCycles
{
    public class EditModel : BasePageModel
    {
       
        [BindProperty(SupportsGet = true)]
        public WorkManagementCycleEditViewModel WorkManagementCycleEditViewModel { get; set; }

        public EditModel(IRequestSender requestSender, IDropDownService dropDownService) : base(requestSender, dropDownService)
        {
          
        }

        public async Task<IActionResult> OnGetAsync(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var cycle = await _requestSender.GetContetFromRequestAsyncAs<WorkManagementCycle>(
                await _requestSender.SendGetRequestAsync("https://localhost:44389/api/WorkManagementCycles/one?id=" + id)
                );
            WorkManagementCycleEditViewModel = await _dropDownService.CreateWorkMangementCycle(cycle);
            return Page();

            if (WorkManagementCycleEditViewModel == null)
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
            await _dropDownService.UpdateWorkManagementCycle(WorkManagementCycleEditViewModel);
            //if (response.IsSuccessStatusCode)
            //{
            //    return RedirectToPage("./Index");
            //}
            //else
            //{
            //    //DO something
            //}



            return RedirectToPage("./Index");
        }
        
        
    }
}
