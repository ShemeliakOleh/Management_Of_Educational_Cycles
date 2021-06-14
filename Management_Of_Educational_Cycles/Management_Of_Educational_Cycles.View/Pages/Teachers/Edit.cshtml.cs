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
using System.IO;

namespace Management_Of_Educational_Cycles.View.Pages.Teachers
{
    public class EditModel : BasePageModel
    {
       
        [BindProperty(SupportsGet = true)]
        public TeacherEditViewModel TeacherEditViewModel { get; set; }

        public EditModel(IRequestSender requestSender, IDropDownService dropDownService) : base(requestSender, dropDownService)
        {
         
        }


        public async Task<IActionResult> OnGetAsync(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var teacher = await _requestSender.GetContetFromRequestAsyncAs<Teacher>(
                await _requestSender.SendGetRequestAsync("https://localhost:44389/api/Teachers/one?id=" + id)
                );

            if (teacher == null)
            {
                return NotFound();
            }
            TeacherEditViewModel = await _dropDownService.CreateTeacher(teacher);
            
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid && TeacherEditViewModel.SelectedFaculty != null && TeacherEditViewModel.SelectedDepartment != null)
            {
                return null;
            }
            var teacher = await _dropDownService.Convert2Teacher(TeacherEditViewModel);
            teacher.Id = TeacherEditViewModel.TeacherId;
            var response = await _requestSender.SendPostRequestAsync("https://localhost:44389/api/Teachers/update",teacher);

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
