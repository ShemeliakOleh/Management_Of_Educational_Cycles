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

namespace Management_Of_Educational_Cycles.View.Pages.Groups
{
    public class EditModel : BasePageModel
    {
      
        public EditModel(IRequestSender requestSender) : base(requestSender)
        {
            
        }

        [BindProperty]
        public Group Group { get; set; }

        public async Task<IActionResult> OnGetAsync(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Group = await _requestSender.GetContetFromRequestAsyncAs<Group>(
                await _requestSender.SendGetRequestAsync("https://localhost:44389/api/Groups/one?id=" + id)
                );

            if (Group == null)
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

            var response = await _requestSender.SendPostRequestAsync("https://localhost:44389/api/Groups/update", Group);
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
