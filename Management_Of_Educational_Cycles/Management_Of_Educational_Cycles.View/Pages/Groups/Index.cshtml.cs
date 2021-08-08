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

namespace Management_Of_Educational_Cycles.View.Pages.Groups
{
    public class IndexModel : BasePageModel
    {
       
        public IndexModel(EntitieViewModelsManager viewManager) : base(viewManager)
        {
            
        }
        [BindProperty(SupportsGet = true)]
        public GroupsFilter GroupsFilter { get; set; }

        public async Task OnGetAsync()
        {
            GroupsFilter = await viewManager.groupsProvider.CreateGroupsFilter();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            var newGroupsFilter =await viewManager.groupsProvider.CreateGroupsFilter();
            List<AcademicGroup> filteredGroups = newGroupsFilter.Groups;
            if (GroupsFilter.GroupName != null)
            {
                filteredGroups = filteredGroups.Where(x => x.Name.ToLower().Contains(GroupsFilter.GroupName.ToLower())).ToList();
                newGroupsFilter.GroupName = GroupsFilter.GroupName;
            }

            Guid guid;
            if (Guid.TryParse(GroupsFilter.SelectedFaculty, out guid))
            {
                filteredGroups = filteredGroups.Where(x => x.Department.FacultyId == guid).ToList();
                newGroupsFilter.SelectedFaculty = GroupsFilter.SelectedFaculty;
                newGroupsFilter.Departments = await viewManager.departmentsProvider.GetDepartmentsByFaculty(Guid.Parse(newGroupsFilter.SelectedFaculty));

            }
            if (Guid.TryParse(GroupsFilter.SelectedDepartment, out guid))
            {
                filteredGroups = filteredGroups.Where(x => x.DepartmentId == guid).ToList();
                newGroupsFilter.SelectedDepartment = GroupsFilter.SelectedDepartment;
            }
            newGroupsFilter.Groups = filteredGroups;
            GroupsFilter = newGroupsFilter;
            return Page();
        }
    }
}
