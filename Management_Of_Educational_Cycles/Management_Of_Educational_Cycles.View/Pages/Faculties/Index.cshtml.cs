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

namespace Management_Of_Educational_Cycles.View.Pages.Faculties
{
    public class IndexModel : BasePageModel
    {
        [BindProperty(SupportsGet = true)]
        public FacultiesFilter FacultiesFilter { get; set; }
        public IndexModel(IRequestSender requestSender, IDropDownService dropDownService) : base(requestSender, dropDownService)
        {
            FacultiesFilter = new FacultiesFilter();
        }
       
        public async Task OnGetAsync()
        {
            FacultiesFilter = await _dropDownService.CreateFacultiesFilter();
        }
        public async Task<IActionResult> OnPostAsync()
        {
            if(FacultiesFilter.FacultyName != null)
            {
                FacultiesFilter = await _dropDownService.FilterFacultiesByName(FacultiesFilter.FacultyName);
            }
            else
            {
                FacultiesFilter = await _dropDownService.CreateFacultiesFilter();
            }
            return Page();

        }
    }
}
