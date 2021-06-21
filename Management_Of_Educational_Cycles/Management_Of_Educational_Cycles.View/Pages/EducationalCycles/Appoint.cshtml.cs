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
        [BindProperty]
        public TeachersFilter Filter { get; set; }
        [BindProperty]
        public List<Teacher> ListOfTeachers { get; set; }
        [BindProperty]
        public string Action { get; set; }
        public AppointModel(IRequestSender requestSender) : base(requestSender)
        {

            ListOfTeachers = new List<Teacher>();
        }
        public async Task<IActionResult> OnGetAsync(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            EducationalCycle = await _requestSender.GetContetFromRequestAsyncAs<EducationalCycle>(
               await _requestSender.SendGetRequestAsync("https://localhost:44389/api/EducationalCycles/one?id=" + id));

            if (EducationalCycle == null)
            {
                return NotFound();
            }
            return Page();
        }
        //public async Task<IActionResult> OnPostAsync(Guid? educationalCycleId, Guid? teacherId)
        //{
        //    if (educationalCycleId != null)
        //    {
        //        EducationalCycle = await _requestSender.GetContetFromRequestAsyncAs<EducationalCycle>(
        //       await _requestSender.SendGetRequestAsync("https://localhost:44389/api/EducationalCycles/one?id=" + educationalCycleId));
        //        if ((Action == "Add" || Action == "Delete") && teacherId != null)
        //        {
        //            if (Action == "Add")
        //            {
        //                var response = await _requestSender.SendGetRequestAsync("https://localhost:44389/api/EducationalCycles/appoint?educationalCycleId=" + educationalCycleId + "&teacherId=" + teacherId);

        //            }
        //            else
        //            {
        //                var response = await _requestSender.SendGetRequestAsync("https://localhost:44389/api/EducationalCycles/throwOff?educationalCycleId=" + educationalCycleId + "&teacherId=" + teacherId);

        //            }
        //            EducationalCycle = await _requestSender.GetContetFromRequestAsyncAs<EducationalCycle>(
        //       await _requestSender.SendGetRequestAsync("https://localhost:44389/api/EducationalCycles/one?id=" + educationalCycleId));

        //            return Page();
        //        }
        //        if (Action == "Find")
        //        {
        //            if (Filter != null)
        //            {
        //                var allTeachers = await _requestSender.GetContetFromRequestAsyncAs<List<Teacher>>(
        //                await _requestSender.SendGetRequestAsync("https://localhost:44389/api/Teachers/list"));
        //                var filteredTeachers = new List<Teacher>();
        //                if (Filter.TeacherName != null)
        //                {
        //                    filteredTeachers = allTeachers.Where(x => x.Name.ToLower().Contains(Filter.TeacherName.ToLower())).ToList();
        //                }
        //                if (Filter.TeacherSurname != null)
        //                {
        //                    filteredTeachers = filteredTeachers.Where(x => x.Surname.ToLower().Contains(Filter.TeacherSurname.ToLower())).ToList();

        //                }
        //                if (Filter.Faculty != null)
        //                {
        //                    filteredTeachers = filteredTeachers.Where(x => x.Department.Faculty.Name.ToLower().Contains(Filter.Faculty.ToLower())).ToList();
        //                }
        //                if (Filter.Department != null)
        //                {
        //                    filteredTeachers = filteredTeachers.Where(x => x.Department.Name.ToLower().Contains(Filter.Department.ToLower())).ToList();
        //                }
        //                ListOfTeachers = filteredTeachers;
        //                return Page();
        //            }
        //            else
        //            {
        //                return Page();
        //            }
        //        }

        //    }



        //    return RedirectToPage("./Index");
        //}
    }
}
