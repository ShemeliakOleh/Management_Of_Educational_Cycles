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

namespace Management_Of_Educational_Cycles.View.Pages.Disciplines
{
    public class EditModel : BasePageModel
    {
     
        public EditModel(IRequestSender requestSender) : base(requestSender)
        {

        }

        [BindProperty]
        public Discipline Discipline { get; set; }

        public async Task<IActionResult> OnGetAsync(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            
            Discipline = await _requestSender.GetContetFromRequestAsyncAs<Discipline>(
                await _requestSender.SendGetRequestAsync("https://localhost:44389/api/Disciplines/one?id=" + id)
                );

            if (Discipline == null)
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

            var response = await _requestSender.SendPostRequestAsync("https://localhost:44389/api/Disciplines/update", Discipline);
            
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
