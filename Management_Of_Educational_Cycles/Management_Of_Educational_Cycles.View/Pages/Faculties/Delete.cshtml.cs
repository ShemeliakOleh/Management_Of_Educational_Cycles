﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Management_Of_Educational_Cycles.Domain.Entities;
using Management_Of_Educational_Cycles.Domain.Models;

namespace Management_Of_Educational_Cycles.View.Pages.Faculties
{
    public class DeleteModel : PageModel
    {
        private readonly Management_Of_Educational_Cycles.Domain.Entities.ApplicationContext _context;

        public DeleteModel(Management_Of_Educational_Cycles.Domain.Entities.ApplicationContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Faculty Faculty { get; set; }

        public async Task<IActionResult> OnGetAsync(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Faculty = await _context.Faculties.FirstOrDefaultAsync(m => m.Id == id);

            if (Faculty == null)
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

            Faculty = await _context.Faculties.FindAsync(id);

            if (Faculty != null)
            {
                _context.Faculties.Remove(Faculty);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
