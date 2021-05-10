using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Management_Of_Educational_Cycles.Domain.Entities;
using Management_Of_Educational_Cycles.Domain.Models;
using Newtonsoft.Json;
using System.Net.Http;
using System.Text;

namespace Management_Of_Educational_Cycles.View.Pages.EducationalCycles
{
    public class EditModel : PageModel
    {
        private readonly Management_Of_Educational_Cycles.Domain.Entities.ApplicationContext _context;

        public EditModel(Management_Of_Educational_Cycles.Domain.Entities.ApplicationContext context)
        {
            _context = context;
        }

        [BindProperty]
        public EducationalCycle EducationalCycle { get; set; }

        public async Task<IActionResult> OnGetAsync(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var client = new HttpClient();
            var response =await client.GetAsync("https://localhost:44389/api/EducationalCycles/one?id=" + id);
            var textResponse =await response.Content.ReadAsStringAsync();
            EducationalCycle = JsonConvert.DeserializeObject<EducationalCycle>(textResponse);

            if (EducationalCycle == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            var client = new HttpClient();
            var json = JsonConvert.SerializeObject(EducationalCycle);
            var data = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await client.PostAsync("https://localhost:44389/api/EducationalCycles/update", data);
            if (response.IsSuccessStatusCode)
            {
                return RedirectToPage("./Index");
            }
            //else
            //{
            //    //Do something
            //}

            return RedirectToPage("./Index");
        }

        private bool EducationalCycleExists(Guid id)
        {
            return _context.EducationalCycles.Any(e => e.Id == id);
        }
    }
}
