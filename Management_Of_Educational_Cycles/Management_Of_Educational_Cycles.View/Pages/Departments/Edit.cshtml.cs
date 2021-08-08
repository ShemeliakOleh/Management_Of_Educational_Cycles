using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Management_Of_Educational_Cycles.Domain.Models;
using System.Net.Http;
using Newtonsoft.Json;
using System.Text;
using Management_Of_Educational_Cycles.Logic.Services;

namespace Management_Of_Educational_Cycles.View.Pages.Departments
{
    public class EditModel : BasePageModel
    {

        [BindProperty(SupportsGet = true)]
        public DepartmentEditViewModel DepartmentEditViewModel { get; set; }
        public EditModel(EntitieViewModelsManager viewManager, DataManager dataManager) : base(viewManager, dataManager)
        {

        }

        public async Task<IActionResult> OnGetAsync(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var department = await dataManager.departmentsRepository.GetById(id);
            DepartmentEditViewModel = await viewManager.departmentsProvider.CreateDepartmentEditViewModel(department);
            return Page();

            if (DepartmentEditViewModel == null)
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

            await viewManager.departmentsProvider.UpdateDepartment(DepartmentEditViewModel);

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
