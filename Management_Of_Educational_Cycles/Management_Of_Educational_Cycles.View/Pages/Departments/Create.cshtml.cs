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

namespace Management_Of_Educational_Cycles.View.Pages.Departments
{
    public class CreateModel : BasePageModel
    {
        [BindProperty(SupportsGet = true)]
        public DepartmentEditViewModel DepartmentEditViewModel{ get; set; }
        public CreateModel(EntitieViewModelsManager viewManager) : base(viewManager)
        {
          
        }

        public async Task<IActionResult> OnGetAsync()
        {
            DepartmentEditViewModel =await viewManager.departmentsProvider.CreateDepartmentEditViewModel();
            return Page();
        }

        [BindProperty]
        public Department Department { get; set; }
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            bool saved =await viewManager.departmentsProvider.SaveDepartment(DepartmentEditViewModel);
            if (saved)
            {
                return RedirectToPage("./Index");
            }
            else
            {
                //DO something //////////////////!
            }
            return Page();

            
        }
    }
}
