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

namespace Management_Of_Educational_Cycles.View.Pages.Groups
{
    public class CreateModel : BasePageModel
    {

        private IDropDownService _dropDownService;
        [BindProperty(SupportsGet = true)]
        public GroupEditViewModel GroupEditViewModel { get; set; }

        public CreateModel(IRequestSender requestSender, IDropDownService dropDownService) : base(requestSender)
        {
            _dropDownService = dropDownService;
        }

        public async Task<IActionResult> OnGet()
        {
            GroupEditViewModel =await _dropDownService.CreateGroup();
            return Page();
        }


        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid && GroupEditViewModel != null && GroupEditViewModel.SelectedDepartment != null)
            {
                return null;
            }

            bool saved = await _dropDownService.SaveGroup(GroupEditViewModel);
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
    }
}
