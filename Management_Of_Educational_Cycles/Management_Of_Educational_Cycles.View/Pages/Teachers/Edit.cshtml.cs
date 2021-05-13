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

namespace Management_Of_Educational_Cycles.View.Pages.Teachers
{
    public class EditModel : BasePageModel
    {
        
        public EditModel(IRequestSender requestSender) : base(requestSender)
        {

        }

        [BindProperty]
        public Teacher Teacher { get; set; }

        public async Task<IActionResult> OnGetAsync(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            Teacher = await _requestSender.GetContetFromRequestAsyncAs<Teacher>(
                await _requestSender.SendGetRequestAsync("https://localhost:44389/api/Teachers/one?id=" + id)
                );

            if (Teacher == null)
            {
                return NotFound();
            }
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }


            
            var response = await _requestSender.SendPostRequestAsync("https://localhost:44389/api/Teachers/update", Teacher);

            //if (response.IsCompletedSuccessfully)
            //{
            //    //Do something
            //}
            //else
            //{
            //    //Do something
            //}


            return RedirectToPage("./Index");
        }
    }
}
