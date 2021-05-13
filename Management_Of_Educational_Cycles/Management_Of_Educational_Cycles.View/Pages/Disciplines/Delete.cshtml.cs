using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Management_Of_Educational_Cycles.Domain.Entities;
using Management_Of_Educational_Cycles.Domain.Models;
using System.Net.Http;
using Newtonsoft.Json;
using Management_Of_Educational_Cycles.Logic.Services;

namespace Management_Of_Educational_Cycles.View.Pages.Disciplines
{
    public class DeleteModel : BasePageModel
    {
      
        public DeleteModel(IRequestSender requestSender) : base(requestSender)
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

        public async Task<IActionResult> OnPostAsync(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var response = await _requestSender.SendGetRequestAsync("https://localhost:44389/api/Disciplines/remove?id=" + id);
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
