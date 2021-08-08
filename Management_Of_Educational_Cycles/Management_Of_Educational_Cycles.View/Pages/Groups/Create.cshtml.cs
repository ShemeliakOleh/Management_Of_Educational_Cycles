using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Management_Of_Educational_Cycles.Domain.Entities;
using Management_Of_Educational_Cycles.Domain.Models;
using Newtonsoft.Json;
using System.Net.Http;
using System.Text;
using Management_Of_Educational_Cycles.Logic.Services;
using System.IO;

namespace Management_Of_Educational_Cycles.View.Pages.Groups
{
    public class CreateModel : BasePageModel
    {
        [BindProperty(SupportsGet = true)]
        public AcademicGroupEditViewModel GroupEditViewModel { get; set; }

        public CreateModel(EntitieViewModelsManager viewManager) : base(viewManager)
        {
            
        }

        public async Task<IActionResult> OnGet()
        {
            GroupEditViewModel =await viewManager.groupsProvider.CreateAcademicGroup();
            return Page();
        }


        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid && GroupEditViewModel != null && GroupEditViewModel.SelectedDepartment != null)
            {
                return null;
            }

            bool saved = await viewManager.groupsProvider.SaveAcademicGroup(GroupEditViewModel);
            if (saved)
            {
                return RedirectToPage("./Index");
            }
            else
            {
                //DO something //////////////////!
            }
            return RedirectToPage("./Index");
        }
       
    }
}
