using Management_Of_Educational_Cycles.Domain.Models;
using Management_Of_Educational_Cycles.Logic.Interfaces;
using Management_Of_Educational_Cycles.Logic.Interfaces.IEntityViewModelProviders;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Management_Of_Educational_Cycles.Logic.Services.EntityViewsProviders
{
    public class FacultyViewsProvider :EntityProvider, IFacultyViewsProvider
    {
        public FacultyViewsProvider(DataManager dataManager) : base(dataManager)
        {

        }
        
        public async Task<FacultiesFilter> CreateFacultiesFilter()
        {
            FacultiesFilter facultiesFilter = new FacultiesFilter();
            facultiesFilter.Faculties = await dataManager.facultiesRepository.GetFaculties();
            facultiesFilter.FacultyName = "";
            return facultiesFilter;
        }

        public async Task<FacultiesFilter> FilterFacultiesByName(string facultyName)
        {
            return new FacultiesFilter()
            {
                FacultyName = facultyName,
                Faculties = (await dataManager.facultiesRepository.GetFaculties()).Where(x => x.Name.ToLower().Contains(facultyName.ToLower())).ToList()
            };
        }
       
    }
}
