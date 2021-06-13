using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Management_Of_Educational_Cycles.Domain.Entities;
using Management_Of_Educational_Cycles.Domain.Models;
using System.Net.Http;
using System.Text;
using Newtonsoft.Json;
using Management_Of_Educational_Cycles.Logic.Services;
using System.IO;

namespace Management_Of_Educational_Cycles.View.Pages.WorkManagementCycles
{
    public class CreateModel : BasePageModel
    {
        private IDropDownService _dropDownService;
        [BindProperty(SupportsGet = true)]
        public WorkManagementCycleEditViewModel WorkManagementCycleEditViewModel { get; set; }

        public CreateModel(IRequestSender requestSender, IDropDownService dropDownService) : base(requestSender)
        {
            _dropDownService = dropDownService;
        }

        public async Task<IActionResult> OnGet()
        {
            WorkManagementCycleEditViewModel = await _dropDownService.CreateWorkMangementCycle();
            return Page();
        }
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }






            await _dropDownService.SaveWorkManagementCycle(WorkManagementCycleEditViewModel);
            //if (response.IsSuccessStatusCode)
            //{
            //    //DO something
            //}
            //else
            //{
            //    //DO something
            //}

            return RedirectToPage("./Index");
        }
        public async Task<IActionResult> OnPostDepartmentsAsync()
        {

            MemoryStream stream = new MemoryStream();
            await Request.Body.CopyToAsync(stream);
            stream.Position = 0;
            using StreamReader reader = new StreamReader(stream);
            var requestBody = reader.ReadToEnd();

            if (requestBody.Length > 0)
            {
                var facultyId = Guid.Parse(requestBody);
                IEnumerable<SelectListItem> departmentsAsSelectList = await _dropDownService.GetDepartments(facultyId);
                return new JsonResult(departmentsAsSelectList);
            }
            return null;
        }
        public async Task<IActionResult> OnPostGroupsAsync()
        {

            MemoryStream stream = new MemoryStream();
            await Request.Body.CopyToAsync(stream);
            stream.Position = 0;
            using StreamReader reader = new StreamReader(stream);
            var requestBody = reader.ReadToEnd();

            if (requestBody.Length > 0)
            {
                var departmentId = Guid.Parse(requestBody);
                IEnumerable<SelectListItem> groupsAsSelectList = await _dropDownService.GetGroups(departmentId);
                return new JsonResult(groupsAsSelectList);
            }
            return null;
        }
    }
}
