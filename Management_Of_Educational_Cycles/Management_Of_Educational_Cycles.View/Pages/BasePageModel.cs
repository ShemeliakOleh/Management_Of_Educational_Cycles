using Management_Of_Educational_Cycles.Logic.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Management_Of_Educational_Cycles.View.Pages
{
    public abstract class BasePageModel:PageModel
    {
        protected IDropDownService _dropDownService;
        protected IRequestSender _requestSender;
        public BasePageModel(IRequestSender requestSender, IDropDownService dropDownService)
        {
            _requestSender = requestSender;
            _dropDownService = dropDownService;
        }
        public BasePageModel(IRequestSender requestSender)
        {
            _requestSender = requestSender;
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
