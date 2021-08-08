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
    public class EducationalCycleViewsProvider :EntityProvider, IEducationalCycleViewsProvider
    {
        public EducationalCycleViewsProvider(DataManager dataManager) : base(dataManager)
        {

        }
        public EducationalCycleEditViewModel CreateEducationalCycleEditViewModel()
        {
            var cycle = new EducationalCycleEditViewModel()
            {
                Faculties = new List<SelectListItem>(),
                Departments = new List<SelectListItem>(),
                Groups = new List<SelectListItem>(),
                Disciplines = new List<SelectListItem>(),
                TypesOfClasses = new List<SelectListItem>()
            };
            return cycle;
        }
        public async Task<bool> SaveEducationalCycle(EducationalCycleEditViewModel cycleToSave)
        {
            if (cycleToSave != null)
            {

                var educationalCycle = new EducationalCycle()
                {
                    Name = cycleToSave.CycleName,
                    Semester = cycleToSave.Semester,
                    NumberOfHours = cycleToSave.NumberOfHours,
                    GroupId = Guid.Parse(cycleToSave.SelectedGroup),
                    DisciplineId = Guid.Parse(cycleToSave.SelectedDiscipline),
                    TypeOfClasses = cycleToSave.SelectedTypeOfClasses,
                    DepartmentId = Guid.Parse(cycleToSave.SelectedDepartment)
                };
                var response = await dataManager.educationalCyclesRepository.CreateEducationalCycle(educationalCycle);
                return true;
            }

            return false;
        }
        public async Task<EducationalCycleEditViewModel> CreateEducationalCycle(EducationalCycle educationalCycle)
        {
            var cycle = new EducationalCycleEditViewModel()
            {
                CycleName = educationalCycle.Name,
                NumberOfHours = educationalCycle.NumberOfHours,
                Semester = educationalCycle.Semester,
                SelectedTypeOfClasses = educationalCycle.TypeOfClasses,
                CycleId = educationalCycle.Id,
                Faculties = await GetAllFaculties(),
                Disciplines = await GetAllDisciplines(),

            };
            if (educationalCycle.Group != null)
            {
                cycle.SelectedGroup = educationalCycle.GroupId.ToString();
                if (educationalCycle.Department != null)
                {
                    cycle.Groups = await GetGroupsByDepartment(educationalCycle.DepartmentId);
                    cycle.SelectedDepartment = educationalCycle.DepartmentId.ToString();
                    if (educationalCycle.Department.FacultyId != null)
                    {
                        cycle.SelectedFaculty = educationalCycle.Department.FacultyId.ToString();
                        cycle.Departments = await GetDepartmentsByFaculty(educationalCycle.Department.FacultyId);
                    }
                }
            }
            if (educationalCycle.DisciplineId != null)
            {
                cycle.SelectedDiscipline = educationalCycle.DisciplineId.ToString();
            }
            return cycle;
        }
        public async Task<bool> UpdateEducationalCycle(EducationalCycleEditViewModel cycleToUpdate)
        {
            if (cycleToUpdate != null)
            {

                var educationalCycle = new EducationalCycle()
                {
                    Id = cycleToUpdate.CycleId,
                    Name = cycleToUpdate.CycleName,
                    Semester = cycleToUpdate.Semester,
                    NumberOfHours = cycleToUpdate.NumberOfHours,
                    TypeOfClasses = cycleToUpdate.SelectedTypeOfClasses,
                    DisciplineId = Guid.Parse(cycleToUpdate.SelectedDiscipline),
                    GroupId = Guid.Parse(cycleToUpdate.SelectedGroup)
                };
                var response = await dataManager.educationalCyclesRepository.UpdateEducationalCycle(educationalCycle);
                return true;
            }
            return false;
        }

        public Task<bool> AppointTeacherForCycle(Guid? educationalCycleId, Guid? teacherId)
        {
            throw new NotImplementedException();
        }

        public Task<bool> ThrowOffTeacherForCycle(Guid? educationalCycleId, Guid? teacherId)
        {
            throw new NotImplementedException();
        }
    }
}
