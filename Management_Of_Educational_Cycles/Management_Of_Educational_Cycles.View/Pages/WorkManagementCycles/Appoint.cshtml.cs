using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Management_Of_Educational_Cycles.Domain.Models;
using Management_Of_Educational_Cycles.Logic.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;

namespace Management_Of_Educational_Cycles.View.Pages.WorkManagementCycles
{
    public class AppointModel : BasePageModel
    {
        public WorkManagementCycle WorkManagementCycle { get; set; }
        [BindProperty]
        public TeachersFilter Filter { get; set; }
        [BindProperty]
        public List<Teacher> ListOfTeachers { get; set; }
        [BindProperty]
        public string Action { get; set; }
        public AppointModel(EntitieViewModelsManager viewManager, DataManager dataManager) : base(viewManager, dataManager)
        {

            ListOfTeachers = new List<Teacher>();
        }
        public async Task<IActionResult> OnGetAsync(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            WorkManagementCycle = await dataManager.workManagementCyclesRepository.GetById(id);
            if (WorkManagementCycle == null)
            {
                return NotFound();
            }
            if (WorkManagementCycle.Teachers == null)
            {
                WorkManagementCycle.Teachers = new List<Teacher>();
            }
            return Page();
        }


        public async Task<IActionResult> OnPostAsync(Guid? workManagementCycleId, Guid? teacherId)
        {
            if (workManagementCycleId != null)
            {
                WorkManagementCycle = await dataManager.workManagementCyclesRepository.GetById(workManagementCycleId);
                if ((Action == "Add" || Action == "Delete") && teacherId != null)
                {
                    if (Action == "Add")
                    {
                        var response = await viewManager.workManagementCyclesProvider.AppointTeacherForCycle(workManagementCycleId, teacherId);

                    }
                    else
                    {
                        var response = await viewManager.workManagementCyclesProvider.ThrowOffTeacherForCycle(workManagementCycleId, teacherId);
                    }
                    WorkManagementCycle = await dataManager.workManagementCyclesRepository.GetById(workManagementCycleId);
                    return Page();
                }
                if (Action == "Find")
                {
                    if (Filter != null)
                    {
                        var allTeachers = await dataManager.teachersRepository.GetTeachers();
                        var filteredTeachers = allTeachers;
                        if (Filter.TeacherName != null)
                        {
                            filteredTeachers = filteredTeachers.Where(x => x.Name.ToLower().Contains(Filter.TeacherName.ToLower())).ToList();
                        }
                        if (Filter.TeacherSurname != null)
                        {
                            filteredTeachers = filteredTeachers.Where(x => x.Surname.ToLower().Contains(Filter.TeacherSurname.ToLower())).ToList();

                        }
                        if (Filter.SelectedFaculty != null)
                        {
                            filteredTeachers = filteredTeachers.Where(x => x.Department.Faculty.Name.ToLower().Contains(Filter.SelectedFaculty.ToLower())).ToList();
                        }
                        if (Filter.SelectedDepartment != null)
                        {
                            filteredTeachers = filteredTeachers.Where(x => x.Department.Name.ToLower().Contains(Filter.SelectedDepartment.ToLower())).ToList();
                        }
                        ListOfTeachers = filteredTeachers;
                        return Page();
                    }
                    else
                    {
                        return Page();
                    }
                }

            }



            return RedirectToPage("./Index");
        }
    }
}
