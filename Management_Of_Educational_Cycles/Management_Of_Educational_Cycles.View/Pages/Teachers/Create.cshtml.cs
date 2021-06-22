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

namespace Management_Of_Educational_Cycles.View.Pages.Teachers
{
    public class CreateModel : BasePageModel
    {
    
        [BindProperty(SupportsGet = true)]
        public TeacherEditViewModel TeacherEditViewModel { get; set; }

        public CreateModel(IRequestSender requestSender, IDropDownService dropDownService) : base(requestSender, dropDownService)
        {
           
        }

        public async Task<IActionResult> OnGet()
        {
            TeacherEditViewModel = await _dropDownService.CreateTeacher();
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

            bool saved = await _dropDownService.SaveTeacher(TeacherEditViewModel);
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
