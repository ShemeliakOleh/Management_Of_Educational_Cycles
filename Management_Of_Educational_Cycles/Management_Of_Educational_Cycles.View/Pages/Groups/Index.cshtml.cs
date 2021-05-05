﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Management_Of_Educational_Cycles.Domain.Entities;
using Management_Of_Educational_Cycles.Domain.Models;

namespace Management_Of_Educational_Cycles.View.Pages.Groups
{
    public class IndexModel : PageModel
    {
        private readonly Management_Of_Educational_Cycles.Domain.Entities.ApplicationContext _context;

        public IndexModel(Management_Of_Educational_Cycles.Domain.Entities.ApplicationContext context)
        {
            _context = context;
        }

        public IList<Group> Group { get;set; }

        public async Task OnGetAsync()
        {
            Group = await _context.Groups.ToListAsync();
        }
    }
}