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
    
    public class TeacherViewsProvider :EntityProvider,ITeacherViewsProvider
    {
        readonly IDisciplineViewsProvider _disciplinesProvider;
        public TeacherViewsProvider(IDisciplineViewsProvider disciplinesProvider, DataManager dataManager):base(dataManager)
        {
            _disciplinesProvider = disciplinesProvider;
        }

        public async Task<TeacherEditViewModel> CreateTeacher()
        {
            var teacher = new TeacherEditViewModel()
            {
                Faculties = await GetAllFaculties(),
                Departments = new List<SelectListItem>()
            };
            return teacher;
        }
        public async Task<bool> SaveTeacher(TeacherEditViewModel teacherToSave)
        {
            if (teacherToSave != null)
            {

                var teacher = new Teacher()
                {
                    Name = teacherToSave.TeacherName,
                    Surname = teacherToSave.TeacherSurname,
                    DepartmentId = Guid.Parse(teacherToSave.SelectedDepartment)

                };
                var response = await dataManager.teachersRepository.CreateTeacher(teacher);
                return true;
            }

            return false;
        }
        public async Task<List<TeacherDisplayViewModel>> GetTeachers()
        {
            var teachers = await dataManager.teachersRepository.GetAllTeachers();
            if (teachers != null)
            {
                List<TeacherDisplayViewModel> teachersDisplay = new List<TeacherDisplayViewModel>();
                foreach (var x in teachers)
                {
                    var teacherDisplay = new TeacherDisplayViewModel()
                    {
                        TeacherId = x.Id,
                        TeacherName = x.Name,
                        TeacherSurname = x.Surname,
                        DepartmentName = x.Department.Name
                    };
                    teachersDisplay.Add(teacherDisplay);
                }
                return teachersDisplay;
            }
            return null;
        }
        public async Task<TeacherEditViewModel> CreateTeacher(Teacher teacher)
        {
            var teacherViewModel = await CreateTeacher();
            teacherViewModel.TeacherId = teacher.Id;
            teacherViewModel.TeacherName = teacher.Name;
            teacherViewModel.TeacherSurname = teacher.Surname;
            if (teacher.Department != null)
            {
                teacherViewModel.SelectedDepartment = teacher.DepartmentId.ToString();
                if (teacher.Department.Faculty != null)
                {
                    teacherViewModel.SelectedFaculty = teacher.Department.FacultyId.ToString();
                    teacherViewModel.Departments = await GetDepartmentsByFaculty(teacher.Department.FacultyId);
                }
            }

            return teacherViewModel;
        }
        public async Task<Teacher> Convert2Teacher(TeacherEditViewModel teacherEditViewModel)
        {
          
            var department = await dataManager.departmentsRepository.GetById(Guid.Parse(teacherEditViewModel.SelectedDepartment));
            return new Teacher() { Name = teacherEditViewModel.TeacherName, Surname = teacherEditViewModel.TeacherSurname, Department = department };
        }
        public async Task<TeachersFilter> CreateTeachersFilter()
        {
            var teachers = await dataManager.teachersRepository.GetAllTeachers();
            TeachersFilter teachersFilter = new TeachersFilter()
            {
                Teachers = teachers,
                Faculties = await GetAllFaculties(),
                Departments = new List<SelectListItem>(),
                TeacherName = "",
                TeacherSurname = ""
            };
            return teachersFilter;
        }
        public async Task<TeacherDisplayViewModel> CreateTeacherDisplayViewModel(Guid? teacherId)
        {
            var teacher = await dataManager.teachersRepository.GetById(teacherId);
            TeacherDisplayViewModel teacherDisplayViewModel = new TeacherDisplayViewModel()
            {
                FacultyName = teacher.Department.Faculty.Name,
                DepartmentName = teacher.Department.Name,
                FirstSemesterDisciplines = await _disciplinesProvider.CreateDisciplineViewModels(teacher, 1),
                SecondSemesterDisciplines = await _disciplinesProvider.CreateDisciplineViewModels(teacher, 2),
                TeacherId = teacher.Id,
                TeacherName = teacher.Name,
                TeacherSurname = teacher.Surname
            };
            return teacherDisplayViewModel;
        }
    }
}
