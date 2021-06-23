using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Management_Of_Educational_Cycles.Domain.Entities;
using Management_Of_Educational_Cycles.Domain.Models;
using System.Net.Http;
using Newtonsoft.Json;
using System.Text;
using Management_Of_Educational_Cycles.Logic.Services;

namespace Management_Of_Educational_Cycles.View.Pages.Groups
{
    public class EditModel : BasePageModel
    {
        [BindProperty(SupportsGet = true)]
        public AcademicGroupEditViewModel GroupEditViewModel { get; set; }
        public EditModel(IRequestSender requestSender, IDropDownService dropDownService) : base(requestSender , dropDownService)
        {
            
        }

       

        public async Task<IActionResult> OnGetAsync(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var group = await _requestSender.GetContetFromRequestAsyncAs<AcademicGroup>(
                await _requestSender.SendGetRequestAsync("https://localhost:44389/api/AcademicGroups/one?id=" + id)
                );

            if(group is AcademicGroup)
            {
                GroupEditViewModel = await _dropDownService.CreateAcademicGroupEditViewModel(group as AcademicGroup);
                return Page();
            }
            if(group is Group)
            {
                string url = Url.Page("EditMixedGroup", id );
                return Redirect(url);
            }
            

            if (GroupEditViewModel == null)
            {
                return NotFound();
            }
            return Page();
        }


        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            await _dropDownService.UpdateAcademicGroup(GroupEditViewModel);
            //if (response.IsCompletedSuccessfully)
            //{
            //    //Do something
            //}
            //else
            //{
            //    //Do something
            //}

            return RedirectToPage("./Index");
        }

    }
}
