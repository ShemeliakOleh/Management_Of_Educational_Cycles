﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Management_Of_Educational_Cycles.Domain.Entities;
using Management_Of_Educational_Cycles.Domain.Models;
using Newtonsoft.Json;
using System.Net.Http;
using Management_Of_Educational_Cycles.Logic.Services;

namespace Management_Of_Educational_Cycles.View.Pages.Teachers
{
    public class DetailsModel : BasePageModel
    {
     
        public DetailsModel(IRequestSender requestSender) : base(requestSender)
        {

        }

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
    }
}
