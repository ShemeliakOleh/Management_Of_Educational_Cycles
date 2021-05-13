using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Management_Of_Educational_Cycles.Domain.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;

namespace Management_Of_Educational_Cycles.View.Pages.WorkManagementCycles
{
    public class AppointModel : PageModel
    {
        public WorkManagementCycle WorkManagementCycle { get; set; }
        [BindProperty]
        public TeachersFilter Filter { get; set; }
        [BindProperty]
        public List<Teacher> ListOfTeachers { get; set; }
        [BindProperty]
        public string Action { get; set; }
        public AppointModel()
        {
            
            ListOfTeachers = new List<Teacher>();
        }
        public async Task<IActionResult> OnGetAsync(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var client = new HttpClient();
            var response = await client.GetAsync("https://localhost:44389/api/WorkManagementCycles/one?id=" + id);
            var textResponse = await response.Content.ReadAsStringAsync();
            WorkManagementCycle = JsonConvert.DeserializeObject<WorkManagementCycle>(textResponse);


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
                var client = new HttpClient();
                var response = await client.GetAsync("https://localhost:44389/api/WorkManagementCycles/one?id=" + id);
                var textResponse = await response.Content.ReadAsStringAsync();
                WorkManagementCycle = JsonConvert.DeserializeObject<WorkManagementCycle>(textResponse);
                if (Action == "Add" && teacherId != null)
                {

                }
                if (Action == "Find")
                {
                    if (Filter != null)
                    {
                        response = await client.GetAsync("https://localhost:44389/api/Teachers/list");
                        textResponse = await response.Content.ReadAsStringAsync();
                        var allTeachers = JsonConvert.DeserializeObject<List<Teacher>>(textResponse);
                        var filteredTeachers = allTeachers.Where(x => x.Name.ToLower().Contains(Filter.TeacherName.ToLower())).ToList();
                        ListOfTeachers = filteredTeachers;
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
