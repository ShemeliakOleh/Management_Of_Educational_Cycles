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
using Newtonsoft.Json;
using System.Net.Http;
using System.Text;
using Management_Of_Educational_Cycles.Logic.Services;

namespace Management_Of_Educational_Cycles.View.Pages.EducationalCycles
{
    public class EditModel : BasePageModel { 
       
        public EditModel(IRequestSender requestSender) : base(requestSender)
        {

        }

        [BindProperty]
        public EducationalCycle EducationalCycle { get; set; }

        public async Task<IActionResult> OnGetAsync(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            
            EducationalCycle = await _requestSender.GetContetFromRequestAsyncAs<EducationalCycle>(
                await _requestSender.SendGetRequestAsync("https://localhost:44389/api/EducationalCycles/one?id=" + id)
                );

            if (EducationalCycle == null)
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
            var response = await _requestSender.SendPostRequestAsync("https://localhost:44389/api/EducationalCycles/update", EducationalCycle);
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
