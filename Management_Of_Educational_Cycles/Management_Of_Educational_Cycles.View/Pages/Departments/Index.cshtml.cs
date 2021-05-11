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

namespace Management_Of_Educational_Cycles.View.Pages.Departments
{
    public class IndexModel : PageModel
    {
        private readonly Management_Of_Educational_Cycles.Domain.Entities.ApplicationContext _context;

        public IndexModel(Management_Of_Educational_Cycles.Domain.Entities.ApplicationContext context)
        {
            _context = context;
        }

        public IList<Department> Department { get;set; }

        public async Task OnGetAsync()
        {
            var client = new HttpClient();
            var response = await client.GetAsync("https://localhost:44389/api/Departments/list");
            var textResponse = await response.Content.ReadAsStringAsync();
            Department = JsonConvert.DeserializeObject<List<Department>>(textResponse);
        }
    }
}
