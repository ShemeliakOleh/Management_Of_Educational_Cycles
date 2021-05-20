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
        private IDropDownService _dropDownService;
        [BindProperty(SupportsGet = true)]
        public TeacherCreateViewModel TeacherCreateViewModel { get; set; }
        //[BindProperty(SupportsGet = true)]
        //public int FacultyId { get; set; }
        //[BindProperty(SupportsGet = true)]
        //public int DepartmentId { get; set; }
        public CreateModel(IRequestSender requestSender, IDropDownService dropDownService) : base(requestSender)
        {
            _dropDownService = dropDownService;
        }

        public async Task<IActionResult> OnGet()
        {
            TeacherCreateViewModel =await _dropDownService.CreateTeacher();
            return Page();
        }

        [BindProperty]
        public Teacher Teacher { get; set; }
        public async Task<IActionResult> OnPost()
        {
            if (!ModelState.IsValid)
            {
                return null;
            }
            //Teacher.Name = TeacherCreateViewModel.TeacherName;
            //Teacher.Surname = TeacherCreateViewModel.TeacherSurname;
            //Teacher.Faculty = TeacherCreateViewModel.SelectedFaculty; !!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!

            bool saved = await _dropDownService.SaveTeacher(TeacherCreateViewModel);
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
        public async Task<IActionResult> OnPostDepartmentsAsync(string selectedFaculty)
        {

            MemoryStream stream = new MemoryStream();
            await Request.Body.CopyToAsync(stream);
            stream.Position = 0;
            using StreamReader reader = new StreamReader(stream);
            var requestBody = reader.ReadToEnd();
            
            if (requestBody.Length > 0)
            {
                var facultyId = Guid.Parse(requestBody);
                IEnumerable <SelectListItem> departmentsAsSelectList = await _dropDownService.GetDepartments(facultyId);
                return new JsonResult(departmentsAsSelectList);
            }
            return null;
        }
       

    }
}
