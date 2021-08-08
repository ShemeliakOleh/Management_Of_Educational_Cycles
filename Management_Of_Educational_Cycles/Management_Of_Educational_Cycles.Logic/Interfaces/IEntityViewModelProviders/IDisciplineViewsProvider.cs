using Management_Of_Educational_Cycles.Domain.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Management_Of_Educational_Cycles.Logic.Interfaces.IEntityViewModelProviders
{
    public interface IDisciplineViewsProvider
    {
        
        public Task<List<DisciplineViewModel>> CreateDisciplineViewModels(Teacher teacher, int semester);
    }
}
