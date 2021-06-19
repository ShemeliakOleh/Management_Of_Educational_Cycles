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

namespace Management_Of_Educational_Cycles.View.Pages.Groups
{
    public class IndexModel : BasePageModel
    {
       
        public IndexModel(IRequestSender requestSender) : base(requestSender)
        {
            Groups = new List<AcademicGroup>();
        }

        public IList<AcademicGroup> Groups { get;set; }

        public async Task OnGetAsync()
        {
            Groups = await _requestSender.GetContetFromRequestAsyncAs<List<AcademicGroup>>(
                await _requestSender.SendGetRequestAsync("https://localhost:44389/api/AcademicGroups/list")
                );
            if (Groups == null) Groups = new List<AcademicGroup>();
        }
    }
}
