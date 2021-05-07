﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Management_Of_Educational_Cycles.Domain.Entities;
using Management_Of_Educational_Cycles.Domain.Models;

namespace Management_Of_Educational_Cycles.View.Pages.EducationalCycles
{
    public class IndexModel : PageModel
    {
        private readonly Management_Of_Educational_Cycles.Domain.Entities.ApplicationContext _context;

        public IndexModel(Management_Of_Educational_Cycles.Domain.Entities.ApplicationContext context)
        {
            _context = context;
        }

        public IList<EducationalCycle> EducationalCycle { get;set; }

        public async Task OnGetAsync()
        {
            EducationalCycle = await _context.EducationalCycles.Include(x=>x.Discipline)
                .Include(x => x.Teacher).Include(x => x.Group).ToListAsync();
        }
    }
}
