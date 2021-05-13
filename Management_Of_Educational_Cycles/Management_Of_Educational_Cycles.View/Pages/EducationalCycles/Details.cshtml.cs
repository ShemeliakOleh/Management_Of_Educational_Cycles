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

namespace Management_Of_Educational_Cycles.View.Pages.EducationalCycles
{
    public class DetailsModel : BasePageModel
    {
      
        public DetailsModel(IRequestSender requestSender) : base(requestSender)
        {

        }

        public EducationalCycle EducationalCycle { get; set; }

        public async Task<IActionResult> OnGetAsync(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }
           
            EducationalCycle = await _requestSender.GetContetFromRequestAsyncAs<EducationalCycle>(
                await _requestSender.SendGetRequestAsync("https://localhost:44389/api/EducationalCycles/one?id=" + id)
                );

            if (EducationalCycle == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
