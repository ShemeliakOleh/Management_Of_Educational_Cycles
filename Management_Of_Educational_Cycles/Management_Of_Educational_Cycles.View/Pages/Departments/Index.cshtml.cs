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

namespace Management_Of_Educational_Cycles.View.Pages.Departments
{
    public class IndexModel : BasePageModel
    {
     
        public IndexModel(EntitieViewModelsManager viewManager) : base(viewManager)
        {
            DepartmentsFilter = new DepartmentsFilter();
        }
        
       [BindProperty(SupportsGet = true)]
        public DepartmentsFilter DepartmentsFilter { get; set; }

        public async Task OnGetAsync()
        {
            DepartmentsFilter = await viewManager.departmentsProvider.CreateDepartmentsFilter();
        }
        public async Task<IActionResult> OnPostAsync()
        {
           
            var newDepartmentsFilter = await viewManager.departmentsProvider.CreateDepartmentsFilter();
            List<Department> filteredDepartments = newDepartmentsFilter.Departments;
            if (DepartmentsFilter.DepartmentName != null)
            {
                filteredDepartments = filteredDepartments.Where(x => x.Name.ToLower().Contains(DepartmentsFilter.DepartmentName.ToLower())).ToList();
                newDepartmentsFilter.DepartmentName = DepartmentsFilter.DepartmentName;
            }
           
            Guid guid;
            if (Guid.TryParse(DepartmentsFilter.SelectedFaculty, out guid))
            {
                filteredDepartments = filteredDepartments.Where(x => x.FacultyId == guid).ToList();
                newDepartmentsFilter.SelectedFaculty = DepartmentsFilter.SelectedFaculty;
                
            }
           
            newDepartmentsFilter.Departments = filteredDepartments;
            DepartmentsFilter = newDepartmentsFilter;
            return Page();

        }


    }
}
