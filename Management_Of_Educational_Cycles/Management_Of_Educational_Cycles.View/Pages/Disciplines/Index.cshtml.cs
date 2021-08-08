using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Management_Of_Educational_Cycles.Domain.Models;
using Newtonsoft.Json;
using System.Net.Http;
using Management_Of_Educational_Cycles.Logic.Services;

namespace Management_Of_Educational_Cycles.View.Pages.Disciplines
{
    public class IndexModel : BasePageModel
    {

        public IndexModel(EntitieViewModelsManager viewManager, DataManager dataManager) : base(viewManager, dataManager)
        {
            Disciplines = new List<Discipline>();
        }

        public IList<Discipline> Disciplines { get;set; }

        public async Task OnGetAsync()
        {
            Disciplines = await dataManager.disciplinesRepository.GetDisciplines();
        }
    }
}
