using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Management_Of_Educational_Cycles.Domain.Models;
using Management_Of_Educational_Cycles.Logic.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Management_Of_Educational_Cycles.View.Pages.EducationalCycles
{
    public class AppointModel : BasePageModel
    {
        public EducationalCycle EducationalCycle { get; set; }
        [BindProperty(SupportsGet = true)]
        public TeachersFilter TeachersFilter { get; set; }
        [BindProperty]
        public string Action { get; set; }
        public AppointModel(EntitieViewModelsManager viewManager, DataManager dataManager) : base(viewManager, dataManager)
        {
            TeachersFilter = new TeachersFilter();
        }
        public async Task<IActionResult> OnGetAsync(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            TeachersFilter = await viewManager.teachersProvider.CreateTeachersFilter();
            EducationalCycle = await dataManager.educationalCyclesRepository.GetById(id);
            if (EducationalCycle == null)
            {
                return NotFound();
            }
            return Page();
        }
        public async Task<IActionResult> OnPostAsync(Guid? educationalCycleId, Guid? teacherId)
        {
            if (educationalCycleId != null)
            {
                EducationalCycle = await dataManager.educationalCyclesRepository.GetById(educationalCycleId);
                if ((Action == "Add" || Action == "Delete") && teacherId != null)
                {
                    if (Action == "Add")
                    {
                        var response = await viewManager.educationalCyclesProvider.AppointTeacherForCycle(educationalCycleId,teacherId);
                    }
                    else
                    {
                        var response = await viewManager.educationalCyclesProvider.ThrowOffTeacherForCycle(educationalCycleId, teacherId);
                    }
                    EducationalCycle = await dataManager.educationalCyclesRepository.GetById(educationalCycleId);
                    return Page();
                }
                if (Action == "Find")
                {
                    if (TeachersFilter != null)
                    {
                        var newTeachersFilter = await viewManager.teachersProvider.CreateTeachersFilter();
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
                        if (Guid.TryParse(TeachersFilter.SelectedFaculty, out guid))
                        {
                            filteredTeachers = filteredTeachers.Where(x => x.Department.FacultyId == guid).ToList();
                            newTeachersFilter.SelectedFaculty = TeachersFilter.SelectedFaculty;
                            newTeachersFilter.Departments = await viewManager.departmentsProvider.GetDepartmentsByFaculty(Guid.Parse(newTeachersFilter.SelectedFaculty));
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
