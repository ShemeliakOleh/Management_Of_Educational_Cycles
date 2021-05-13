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

namespace Management_Of_Educational_Cycles.View.Pages.WorkManagementCycles
{
    public class EditModel : BasePageModel
    {
        public EditModel(IRequestSender requestSender) : base(requestSender)
        {
        }

        [BindProperty]
        public WorkManagementCycle WorkManagementCycle { get; set; }

        public async Task<IActionResult> OnGetAsync(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            WorkManagementCycle = await _requestSender.GetContetFromRequestAsyncAs<WorkManagementCycle>(
               await _requestSender.SendGetRequestAsync("https://localhost:44389/api/WorkManagementCycles/one?id=" + id));
            

            if (WorkManagementCycle == null)
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
            var response = await _requestSender.SendPostRequestAsync("https://localhost:44389/api/WorkManagementCycles/update", WorkManagementCycle);
            if (response.IsSuccessStatusCode)
            {
                return RedirectToPage("./Index");
            }
            //else
            //{
            //    //DO something
            //}



            return RedirectToPage("./Index");
        }
    }
}
