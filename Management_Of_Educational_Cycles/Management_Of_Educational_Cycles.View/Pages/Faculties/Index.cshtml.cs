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

namespace Management_Of_Educational_Cycles.View.Pages.Faculties
{
    public class IndexModel : BasePageModel
    {
        private readonly Management_Of_Educational_Cycles.Domain.Entities.ApplicationContext _context;

        public IndexModel(IRequestSender requestSender) : base(requestSender)
        {
            Faculties = new List<Faculty>();
        }

        public IList<Faculty> Faculties { get;set; }

        public async Task OnGetAsync()
        {
            Faculties = await _requestSender.GetContetFromRequestAsyncAs<List<Faculty>>(
                await _requestSender.SendGetRequestAsync("https://localhost:44389/api/Faculties/list")
                );
        }
    }
}
