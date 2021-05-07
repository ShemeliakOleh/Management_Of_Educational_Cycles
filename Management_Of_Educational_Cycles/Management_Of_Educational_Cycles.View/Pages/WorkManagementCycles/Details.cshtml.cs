﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Management_Of_Educational_Cycles.Domain.Entities;
using Management_Of_Educational_Cycles.Domain.Models;

namespace Management_Of_Educational_Cycles.View.Pages.WorkManagementCycles
{
    public class DetailsModel : PageModel
    {
        private readonly Management_Of_Educational_Cycles.Domain.Entities.ApplicationContext _context;

        public DetailsModel(Management_Of_Educational_Cycles.Domain.Entities.ApplicationContext context)
        {
            _context = context;
        }

        public WorkManagementCycle WorkManagementCycle { get; set; }

        public async Task<IActionResult> OnGetAsync(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            WorkManagementCycle = await _context.WorkManagementCycles.Include(x=>x.Group).FirstOrDefaultAsync(m => m.Id == id);

            if (WorkManagementCycle == null)
            {
                return NotFound();
            }
            if (WorkManagementCycle.Teachers == null)
            {
                WorkManagementCycle.Teachers = new List<Teacher>();
            }
            return Page();
        }
    }
}
