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
        public AppointModel(IRequestSender requestSender):base(requestSender)
        {

            ListOfTeachers = new List<Teacher>();
        }
        public async Task<IActionResult> OnGetAsync(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            WorkManagementCycle = await _requestSender.GetContetFromRequestAsyncAs<WorkManagementCycle>(
               await _requestSender.SendGetRequestAsync("https://localhost:44389/api/WorkManagementCycles/one?id=" + id));


            //WorkManagementCycle = await _context.WorkManagementCycles.Include(x=>x.Group).FirstOrDefaultAsync(m => m.Id == id);

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


        public async Task<IActionResult> OnPostAsync(Guid? id,Guid? teacherId)
        {
            if(id!= null)
            {
                WorkManagementCycle = await _requestSender.GetContetFromRequestAsyncAs<WorkManagementCycle>(
               await _requestSender.SendGetRequestAsync("https://localhost:44389/api/WorkManagementCycles/one?id=" + id));
                if (Action == "Add" && teacherId != null)
                {

                    var teacher = await _requestSender.GetContetFromRequestAsyncAs<Teacher>(
               await _requestSender.SendGetRequestAsync("https://localhost:44389/api/Teachers/one?id=" + teacherId));
                    WorkManagementCycle.Teachers.Add(teacher);
                    var response = await _requestSender.SendPostRequestAsync("https://localhost:44389/api/WorkManagementCycles/appoint",WorkManagementCycle);
                    WorkManagementCycle = await _requestSender.GetContetFromRequestAsyncAs<WorkManagementCycle>(
               await _requestSender.SendGetRequestAsync("https://localhost:44389/api/WorkManagementCycles/one?id=" + id));
                    //if (response.IsSuccessStatusCode)
                    //{
                    //    return RedirectToPage("./Index");
                    //}
                    //else
                    //{
                    //    //DO something
                    //}
                    return Page();
                }
                if (Action == "Find")
                {
                    if (Filter != null)
                    {
                        
                        var allTeachers = await _requestSender.GetContetFromRequestAsyncAs<List<Teacher>>(
               await _requestSender.SendGetRequestAsync("https://localhost:44389/api/Teachers/list"));
                        var filteredTeachers = allTeachers.Where(x => x.Name.ToLower().Contains(Filter.TeacherName.ToLower())).ToList();
                        ListOfTeachers = filteredTeachers;
                        WorkManagementCycle = await _requestSender.GetContetFromRequestAsyncAs<WorkManagementCycle>(
               await _requestSender.SendGetRequestAsync("https://localhost:44389/api/WorkManagementCycles/one?id=" + id));
                        return Page();
                    }
                    else
                    {
                        return Page();
                    }
                }
                if (Action == "Delete")
                {

                }
            }
            

            
            return RedirectToPage("./Index");
        }
    }
}
