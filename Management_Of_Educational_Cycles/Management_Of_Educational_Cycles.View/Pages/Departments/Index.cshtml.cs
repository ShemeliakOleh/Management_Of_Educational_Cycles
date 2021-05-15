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

namespace Management_Of_Educational_Cycles.View.Pages.Departments
{
    public class IndexModel : BasePageModel
    {
     
        public IndexModel(IRequestSender requestSender) : base(requestSender)
        {
            Departments = new List<Department>();
        }

        public IList<Department> Departments { get;set; }

        public async Task OnGetAsync()
        {
            Departments = await _requestSender.GetContetFromRequestAsyncAs<List<Department>>(
                await _requestSender.SendGetRequestAsync("https://localhost:44389/api/Departments/list")
                );
        }
    }
}
