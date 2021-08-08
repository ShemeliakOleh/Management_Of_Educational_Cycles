using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Management_Of_Educational_Cycles.Domain.Entities;
using Management_Of_Educational_Cycles.Domain.Models;
using Newtonsoft.Json;
using System.Net.Http;
using Management_Of_Educational_Cycles.Logic.Services;

namespace Management_Of_Educational_Cycles.View.Pages.Teachers
{
    public class DetailsModel : BasePageModel
    {
     
        public DetailsModel(EntitieViewModelsManager viewManager) : base(viewManager)
        {

        }

        public TeacherDisplayViewModel TeacherDisplayViewModel { get; set; }

        public async Task<IActionResult> OnGetAsync(Guid? id)
        {
 
            
            TeacherDisplayViewModel =await viewManager.teachersProvider.CreateTeacherDisplayViewModel(id);
            
            
            if (TeacherDisplayViewModel == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
