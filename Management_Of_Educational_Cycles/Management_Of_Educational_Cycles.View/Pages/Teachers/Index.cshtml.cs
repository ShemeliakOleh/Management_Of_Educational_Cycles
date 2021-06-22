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

namespace Management_Of_Educational_Cycles.View.Pages.Teachers
{
    public class IndexModel : BasePageModel
    {
        public IPageSeparator<Teacher> PageSeparator { get; set; }
        [BindProperty(SupportsGet = true)]
        public TeachersFilter TeachersFilter { get; set; }

        public IndexModel(IRequestSender requestSender, IDropDownService dropDownService, IPageSeparator<Teacher> pageSeparator) : base(requestSender, dropDownService)
        {
            this.PageSeparator = PageSeparator;
            TeachersFilter = new TeachersFilter();

        }

        public async Task OnGetAsync()
        {
            TeachersFilter = await _dropDownService.CreateTeachersFilter();
        }
        public async Task<IActionResult> OnPostAsync()
        {
            var newTeachersFilter = await _dropDownService.CreateTeachersFilter();
            List<Teacher> filteredTeachers = newTeachersFilter.Teachers;
            if (TeachersFilter.TeacherName != null)
            {
                filteredTeachers = filteredTeachers.Where(x => x.Name.ToLower().Contains(TeachersFilter.TeacherName.ToLower())).ToList();
                newTeachersFilter.TeacherName = TeachersFilter.TeacherName;
            }
            if (TeachersFilter.TeacherSurname != null)
            {
                filteredTeachers = filteredTeachers.Where(x => x.Surname.ToLower().Contains(TeachersFilter.TeacherSurname.ToLower())).ToList();
                newTeachersFilter.TeacherSurname = TeachersFilter.TeacherSurname;

            }
            Guid guid;
            if (Guid.TryParse(TeachersFilter.SelectedFaculty,out guid))
            {  
                filteredTeachers = filteredTeachers.Where(x => x.Department.FacultyId == guid).ToList();
                newTeachersFilter.SelectedFaculty = TeachersFilter.SelectedFaculty;
                newTeachersFilter.Departments =await _dropDownService.GetDepartments(Guid.Parse(newTeachersFilter.SelectedFaculty));
            }
            if (Guid.TryParse(TeachersFilter.SelectedDepartment, out guid))
            {
                filteredTeachers = filteredTeachers.Where(x => x.DepartmentId == guid).ToList();
                newTeachersFilter.SelectedDepartment = TeachersFilter.SelectedDepartment;
            }
            newTeachersFilter.Teachers = filteredTeachers;
            TeachersFilter = newTeachersFilter;
            return Page();


        }
    }

}
