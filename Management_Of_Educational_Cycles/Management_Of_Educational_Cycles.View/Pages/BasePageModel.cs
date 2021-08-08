using Management_Of_Educational_Cycles.Logic.Interfaces;
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
        protected EntitieViewModelsManager viewManager;
        protected DataManager dataManager;
        protected BasePageModel(EntitieViewModelsManager viewManager, DataManager dataManager)
        {
            this.viewManager = viewManager;
            this.dataManager = dataManager;
        }
        public BasePageModel(EntitieViewModelsManager viewManager)
        {
            this.viewManager = viewManager;
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
                IEnumerable<SelectListItem> departmentsAsSelectList = await viewManager.departmentsProvider.GetDepartmentsByFaculty(facultyId);
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
                IEnumerable<SelectListItem> groupsAsSelectList = await viewManager.groupsProvider.GetGroupsByDepartment(departmentId);
                return new JsonResult(groupsAsSelectList);
            }
            return null;
        }
        
    }
}
