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

namespace Management_Of_Educational_Cycles.View.Pages.WorkManagementCycles
{
    public class IndexModel : BasePageModel
    {

        public IndexModel(IRequestSender requestSender):base(requestSender)
        {

        }

        public IList<WorkManagementCycle> WorkManagementCycles { get;set; }

        public async Task OnGetAsync()
        {

            WorkManagementCycles = await _requestSender.GetContetFromRequestAsyncAs<List<WorkManagementCycle>>(
                await _requestSender.SendGetRequestAsync("https://localhost:44389/api/WorkManagementCycles/list")
                );
            if (WorkManagementCycles.Count > 0)
            {
                if (WorkManagementCycles[0].Teachers == null)
                {
                    WorkManagementCycles[0].Teachers = new List<Teacher>();
                }
            }
            
        }
    }
}
