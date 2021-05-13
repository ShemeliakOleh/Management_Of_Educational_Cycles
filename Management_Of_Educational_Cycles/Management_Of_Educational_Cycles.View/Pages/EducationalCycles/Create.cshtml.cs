﻿using System;
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
        
        public CreateModel(IRequestSender requestSender) : base(requestSender)
        {

        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public EducationalCycle EducationalCycle { get; set; }
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            var response = await _requestSender.SendPostRequestAsync("https://localhost:44389/api/EducationalCycles/create", EducationalCycle);
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
