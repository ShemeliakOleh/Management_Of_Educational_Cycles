using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

using Management_Of_Educational_Cycles.Domain.Models;
using Newtonsoft.Json;
using System.Net.Http;
using System.Text;
using System.IO;
using Management_Of_Educational_Cycles.Logic.Interfaces;
using Management_Of_Educational_Cycles.Logic.Services;

namespace Management_Of_Educational_Cycles.View.Pages.Teachers
{
    public class CreateModel : BasePageModel
    {
    
        [BindProperty(SupportsGet = true)]
        public TeacherEditViewModel TeacherEditViewModel { get; set; }

        public CreateModel(EntitieViewModelsManager viewManager) : base(viewManager)
        {
           
        }

        public async Task<IActionResult> OnGet()
        {
            TeacherEditViewModel = await viewManager.teachersProvider.CreateTeacher();
            return Page();
        }

        public async Task<IActionResult> OnPost()
        {
            if (!ModelState.IsValid && TeacherEditViewModel.SelectedFaculty!= null && TeacherEditViewModel.SelectedDepartment!= null)
            {
                return null;
            }
            //Teacher.Name = TeacherCreateViewModel.TeacherName;
            //Teacher.Surname = TeacherCreateViewModel.TeacherSurname;
            //Teacher.Faculty = TeacherCreateViewModel.SelectedFaculty; !!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!

            bool saved = await viewManager.teachersProvider.SaveTeacher(TeacherEditViewModel);
            if (saved)
            {
                return RedirectToPage("./Index");
            }
            else
            {
                //DO something //////////////////!
            }
            return null;
            //if (response.IsSuccessStatusCode)
            //{
            //    //DO something
            //}
            //else
            //{
            //    //DO something
            //}

        }
      


    }
    
}
