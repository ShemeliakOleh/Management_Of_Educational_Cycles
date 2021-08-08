using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Management_Of_Educational_Cycles.Domain.Models;
using Newtonsoft.Json;
using System.Net.Http;
using System.Text;
using Management_Of_Educational_Cycles.Logic.Services;
using System.IO;

namespace Management_Of_Educational_Cycles.View.Pages.Groups
{
    public class CreateMixedGroupModel : BasePageModel
    {
        [BindProperty(SupportsGet = true)]
        public MixedGroupEditViewModel MixedGroupEditViewModel { get; set; }

        public CreateMixedGroupModel(EntitieViewModelsManager viewManager, DataManager dataManager) : base(viewManager, dataManager)
        {

        }

        public async Task<IActionResult> OnGet()
        {
            MixedGroupEditViewModel = await viewManager.groupsProvider.CreateMixedGroup();
            return Page();
        }


        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if(MixedGroupEditViewModel.Action == "AddAcademicGroup")
            {
                var selectedGroups = MixedGroupEditViewModel.SelectedGroups;
                Guid academicGroupId;
                if (Guid.TryParse(MixedGroupEditViewModel.SelectedGroup, out academicGroupId))
                {
              
                    var group = await dataManager.groupsRepository.GetById(academicGroupId);
                    MixedGroupEditViewModel = await viewManager.groupsProvider.CreateMixedGroup();
                    MixedGroupEditViewModel.SelectedGroups = selectedGroups;
                    MixedGroupEditViewModel.SelectedGroups.Add(group);
                }
                else
                {

                }
                return Page();
            }
            else 
            {
                bool saved = false;
                if (!ModelState.IsValid && MixedGroupEditViewModel != null && MixedGroupEditViewModel.SelectedGroups.Count >= 0)
                {
                    saved = await viewManager.groupsProvider.SaveMixedGroup(MixedGroupEditViewModel);
                }


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
}
