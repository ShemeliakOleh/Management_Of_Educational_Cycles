﻿using System;
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

namespace Management_Of_Educational_Cycles.View.Pages.Disciplines
{
    public class DetailsModel : PageModel
    {
        private readonly Management_Of_Educational_Cycles.Domain.Entities.ApplicationContext _context;

        public DetailsModel(Management_Of_Educational_Cycles.Domain.Entities.ApplicationContext context)
        {
            _context = context;
        }

        public Discipline Discipline { get; set; }

        public async Task<IActionResult> OnGetAsync(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var client = new HttpClient();
            var response = await client.GetAsync("https://localhost:44389/api/Disciplines/one?id=" + id);
            var textResponse = await response.Content.ReadAsStringAsync();
            Discipline = JsonConvert.DeserializeObject<Discipline>(textResponse);

            if (Discipline == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
