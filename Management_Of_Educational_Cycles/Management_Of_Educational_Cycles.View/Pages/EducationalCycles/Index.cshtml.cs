using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Management_Of_Educational_Cycles.Domain.Models;
using System.Net.Http;
using Newtonsoft.Json;
using Management_Of_Educational_Cycles.Logic.Services;

namespace Management_Of_Educational_Cycles.View.Pages.EducationalCycles
{
    public class IndexModel : BasePageModel
    {
       
        public IndexModel(EntitieViewModelsManager viewManager, DataManager dataManager) : base(viewManager, dataManager)
        {
            EducationalCycles = new List<EducationalCycle>();
        }

        public List<EducationalCycle> EducationalCycles { get;set; }

        public async Task OnGetAsync()
        {
            EducationalCycles = await dataManager.educationalCyclesRepository.GetAllEducationalCycles();
            
        }
    }
}
