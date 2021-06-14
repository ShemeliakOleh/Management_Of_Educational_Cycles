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
        public GroupEditViewModel GroupEditViewModel { get; set; }

        public CreateModel(IRequestSender requestSender, IDropDownService dropDownService) : base(requestSender, dropDownService)
        {
            
        }

        public async Task<IActionResult> OnGet()
        {
            GroupEditViewModel =await _dropDownService.CreateGroup();
            return Page();
        }


        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid && GroupEditViewModel != null && GroupEditViewModel.SelectedDepartment != null)
            {
                return null;
            }

            bool saved = await _dropDownService.SaveGroup(GroupEditViewModel);
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
