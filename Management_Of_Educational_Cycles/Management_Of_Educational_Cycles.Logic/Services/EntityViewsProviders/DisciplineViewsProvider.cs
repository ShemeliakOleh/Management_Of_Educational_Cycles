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
   public class DisciplineViewsProvider :EntityProvider,IDisciplineViewsProvider
    {
        public DisciplineViewsProvider(DataManager dataManager) : base(dataManager)
        {

        }

        
        public async Task<List<DisciplineViewModel>> CreateDisciplineViewModels(Teacher teacher, int semester)
        {


            List<DisciplineViewModel> DisciplineViewModels = new List<DisciplineViewModel>();
            var SemesterDiscipines = teacher.EducationalCycles.Where(x => x.Semester == semester).Select(x => x.Discipline.Name).Distinct().ToList();
            int totalDisciplineHours = 0;
            foreach (var disciplineName in SemesterDiscipines)
            {
                var disciplineViewModel = new DisciplineViewModel()
                {
                    DisciplineName = disciplineName

                };
                var tempcycle = teacher.EducationalCycles.Where(x => x.TypeOfClasses == TypeOfClasses.Лекційні && x.Semester == semester)
                    .SingleOrDefault(x => x.Discipline.Name == disciplineViewModel.DisciplineName);
                if (tempcycle != null)
                {
                    disciplineViewModel.LectureHours = tempcycle.NumberOfHours;
                    totalDisciplineHours += tempcycle.NumberOfHours;
                    if (tempcycle.GroupId != null)
                    {
                        disciplineViewModel.Group = await dataManager.groupsRepository.GetById(tempcycle.GroupId);
                    }
                }
                tempcycle = teacher.EducationalCycles.Where(x => x.TypeOfClasses == TypeOfClasses.Лабораторні && x.Semester == semester)
                    .SingleOrDefault(x => x.Discipline.Name == disciplineViewModel.DisciplineName);
                if (tempcycle != null)
                {
                    disciplineViewModel.LaboratorHours = tempcycle.NumberOfHours;
                    totalDisciplineHours += tempcycle.NumberOfHours;
                    if (tempcycle.GroupId != null)
                    {
                        disciplineViewModel.Group = await dataManager.groupsRepository.GetById(tempcycle.GroupId);
                    }

                }
                tempcycle = teacher.EducationalCycles.Where(x => x.TypeOfClasses == TypeOfClasses.Семінарські && x.Semester == semester)
                    .SingleOrDefault(x => x.Discipline.Name == disciplineViewModel.DisciplineName);
                if (tempcycle != null)
                {
                    disciplineViewModel.SeminarHours = tempcycle.NumberOfHours;
                    totalDisciplineHours += tempcycle.NumberOfHours;
                    if (tempcycle.GroupId != null)
                    {
                        disciplineViewModel.Group = await dataManager.groupsRepository.GetById(tempcycle.GroupId);
                    }

                }
                disciplineViewModel.TotalHours = totalDisciplineHours;
                DisciplineViewModels.Add(disciplineViewModel);

            }
            SemesterDiscipines = teacher.WorkManagementCycles.Where(x => x.Semester == semester).Select(x => x.Name).Distinct().ToList();
            foreach (var disciplineName in SemesterDiscipines)
            {
                var disciplineViewModel = new DisciplineViewModel()
                {
                    DisciplineName = disciplineName,
                    TotalHours = teacher.WorkManagementCycles.SingleOrDefault(x => x.Name == disciplineName).NumberOfHours
                };

                DisciplineViewModels.Add(disciplineViewModel);

            }
            return DisciplineViewModels;
        }
    }
}
