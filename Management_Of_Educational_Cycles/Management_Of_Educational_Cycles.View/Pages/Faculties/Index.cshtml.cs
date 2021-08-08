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
using Microsoft.Extensions.Configuration;

namespace Management_Of_Educational_Cycles.View.Pages.Faculties
{
    public class IndexModel : BasePageModel
    {
        [BindProperty(SupportsGet = true)]
        public FacultiesFilter FacultiesFilter { get; set; }
        public IndexModel(EntitieViewModelsManager viewManager, IConfiguration configuration) : base(viewManager)
        {
            FacultiesFilter = new FacultiesFilter();
            var link = configuration["ServerLink"];
        }
       
        public async Task OnGetAsync()
        {
            FacultiesFilter = await viewManager.facultiesProvider.CreateFacultiesFilter();
            
        }
        public async Task<IActionResult> OnPostAsync()
        {
            if(FacultiesFilter.FacultyName != null)
            {
                FacultiesFilter = await viewManager.facultiesProvider.FilterFacultiesByName(FacultiesFilter.FacultyName);
            }
            else
            {
                FacultiesFilter = await viewManager.facultiesProvider.CreateFacultiesFilter();
            }
            return Page();

        }
    }
}
