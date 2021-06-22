﻿using Management_Of_Educational_Cycles.Domain.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Management_Of_Educational_Cycles.Logic.Services
{
    public class DropDownService : IDropDownService
    {
        readonly IRequestSender _requestSender;
        public DropDownService(IRequestSender requestSender)
        {
            _requestSender = requestSender;
        }

        public async Task<TeacherEditViewModel> CreateTeacher()
        {
            var teacher = new TeacherEditViewModel()
            {
                Faculties = await GetFaculties(),
                Departments = GetDepartments()
            };
            return teacher;
        }
        public async Task<AcademicGroupEditViewModel> CreateAcademicGroup()
        {
            var group = new AcademicGroupEditViewModel()
            {
                Faculties = await GetFaculties(),
                Departments = GetDepartments()
            };
            return group;
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

        //        teacher.Faculty = await _requestSender.GetContetFromRequestAsyncAs<Faculty>(
        //await _requestSender.SendGetRequestAsync("https://localhost:44389/api/Faculties/one?id=" + Guid.Parse(teacherToSave.SelectedFaculty))
        //);
        //        teacher.Department = await _requestSender.GetContetFromRequestAsyncAs<Department>(
        //await _requestSender.SendGetRequestAsync("https://localhost:44389/api/Departments/one?id=" + Guid.Parse(teacherToSave.SelectedDepartment))
        //);
                var response = await _requestSender.SendPostRequestAsync("https://localhost:44389/api/Teachers/create", teacher);
                return true;
            }

            // Return false if customeredit == null or CustomerID is not a guid
            return false;
        }
        public async Task<bool> SaveWorkManagementCycle(WorkManagementCycleEditViewModel cycleToSave)
        {
            if (cycleToSave != null)
            {

                var workManagementCycle = new WorkManagementCycle()
                {
                    Name = cycleToSave.CycleName,
                    Semester = cycleToSave.Semester,
                    NumberOfHours = cycleToSave.NumberOfHours,
                    GroupId = Guid.Parse(cycleToSave.SelectedGroup),
                    DepartmentId = Guid.Parse(cycleToSave.SelectedDepartment)
                };
                var response = await _requestSender.SendPostRequestAsync("https://localhost:44389/api/WorkManagementCycles/create", workManagementCycle);
                return true;
            }

            // Return false if customeredit == null or CustomerID is not a guid
            return false;
        }

        public async Task<IEnumerable<SelectListItem>> GetDepartments(Guid? facultyId)
        {

            var faculty = await _requestSender.GetContetFromRequestAsyncAs<Faculty>(
            await _requestSender.SendGetRequestAsync("https://localhost:44389/api/Faculties/one?id=" + facultyId)
            );

            List<SelectListItem> departmentsSelectListItems = faculty.Departments.OrderBy(n => n.Name)
            .Select(n =>
                new SelectListItem
                {
                    Value = n.Id.ToString(),
                    Text = n.Name
                }).ToList();
            var departmenttip = new SelectListItem()
            {
                Value = null,
                Text = "--- select department ---"
            };
            departmentsSelectListItems.Insert(0, departmenttip);
            return new SelectList(departmentsSelectListItems, "Value", "Text");
        }

        public IEnumerable<SelectListItem> GetDepartments()
        {
            List<SelectListItem> departments = new List<SelectListItem>()
            {
                //new SelectListItem
                //{
                //    Value = null,
                //    Text = "--- select department ---"
                //}
            };
            return departments;
        }

        public async Task<IEnumerable<SelectListItem>> GetFaculties()
        {
            var faculties = await _requestSender.GetContetFromRequestAsyncAs<List<Faculty>>(
            await _requestSender.SendGetRequestAsync("https://localhost:44389/api/Faculties/list")
            );
            List<SelectListItem> facultiesSelectListItems = faculties.OrderBy(n => n.Name)
             .Select(n =>
                 new SelectListItem
                 {
                     Value = n.Id.ToString(),
                     Text = n.Name
                 }).ToList();
            var facultytip = new SelectListItem()
            {
                Value = null,
                Text = "--- select faculty ---"
            };
            facultiesSelectListItems.Insert(0, facultytip);
            return new SelectList(facultiesSelectListItems, "Value", "Text");
        }

        public async Task<List<TeacherDisplayViewModel>> GetTeachers()
        {
            var teachers = await _requestSender.GetContetFromRequestAsyncAs<List<Teacher>>(
            await _requestSender.SendGetRequestAsync("https://localhost:44389/api/Teachers/list")
            );
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

        public async Task<DepartmentEditViewModel> CreateDepartmentEditViewModel()
        {
            var department = new DepartmentEditViewModel()
            {
                DepartmentId = Guid.NewGuid().ToString(),
                Faculties = await GetFaculties(),
            };
            return department;
        }

        public async Task<bool> SaveDepartment(DepartmentEditViewModel departmentToSave)
        {
            if (departmentToSave != null)
            {
                if (Guid.TryParse(departmentToSave.DepartmentId, out Guid newGuid))
                {
                    var department = new Department()
                    {
                        Id = newGuid,
                        Name = departmentToSave.DepartmentName,
                        Groups = new List<AcademicGroup>()
                    };
                    department.FacultyId = Guid.Parse(departmentToSave.SelectedFaculty);
                    var response = await _requestSender.SendPostRequestAsync("https://localhost:44389/api/Departments/create", department);
                    return true;
                }
            }
            // Return false if customeredit == null or CustomerID is not a guid
            return false;
        }

        public async Task<TeacherEditViewModel> CreateTeacher(Teacher teacher)
        {
            var teacherViewModel =await CreateTeacher();
            teacherViewModel.TeacherId = teacher.Id;
            teacherViewModel.TeacherName = teacher.Name;
            teacherViewModel.TeacherSurname = teacher.Surname;
            if(teacher.Department != null)
            {
                teacherViewModel.SelectedDepartment = teacher.DepartmentId.ToString();
                if(teacher.Department.Faculty != null)
                {
                    teacherViewModel.SelectedFaculty = teacher.Department.FacultyId.ToString();
                    teacherViewModel.Departments = await GetDepartments(teacher.Department.FacultyId);
                }
            }
            
            return teacherViewModel;
        }

        public async Task<Teacher> Convert2Teacher(TeacherEditViewModel teacherEditViewModel)
        {
            var faculty = await _requestSender.GetContetFromRequestAsyncAs<Faculty>(
        await _requestSender.SendGetRequestAsync("https://localhost:44389/api/Faculties/one?id=" + Guid.Parse(teacherEditViewModel.SelectedFaculty))
        );
            var department = await _requestSender.GetContetFromRequestAsyncAs<Department>(
    await _requestSender.SendGetRequestAsync("https://localhost:44389/api/Departments/one?id=" + Guid.Parse(teacherEditViewModel.SelectedDepartment)));
            return new Teacher() { Name = teacherEditViewModel.TeacherName, Surname = teacherEditViewModel.TeacherSurname, Department = department };
        }

        public async Task<WorkManagementCycleEditViewModel> CreateWorkMangementCycle()
        {
            var cycle = new WorkManagementCycleEditViewModel()
            {
                Faculties = await GetFaculties(),
                Departments = GetDepartments(),
                Groups = GetGroups()
        };
            return cycle;
        }
        public async Task<IEnumerable<SelectListItem>> GetAcademicGroups(Guid? departmentId)
        {
            var department = await _requestSender.GetContetFromRequestAsyncAs<Department>(
             await _requestSender.SendGetRequestAsync("https://localhost:44389/api/Departments/one?id=" + departmentId)
             );

            IEnumerable<SelectListItem> groupsSelectListItems = department.Groups.OrderBy(n => n.Name)
            .Select(n =>
                new SelectListItem
                {
                    Value = n.Id.ToString(),
                    Text = n.Name
                }).ToList();

            return new SelectList(groupsSelectListItems, "Value", "Text");
        }

        public IEnumerable<SelectListItem> GetAcademicGroups()
        {
            List<SelectListItem> groups = new List<SelectListItem>()
            {
                //new SelectListItem
                //{
                //    Value = null,
                //    Text = "--- select group ---"
                //}
            };
            return groups;
        }

        public async Task<bool> SaveAcademicGroup(AcademicGroupEditViewModel groupToSave)
        {
            if (groupToSave != null)
            {

                var group = new AcademicGroup()
                {
                    Name = groupToSave.GroupName,
                    DepartmentId = Guid.Parse(groupToSave.SelectedDepartment)

                };
        //        group.Faculty = await _requestSender.GetContetFromRequestAsyncAs<Faculty>(
        //await _requestSender.SendGetRequestAsync("https://localhost:44389/api/Faculties/one?id=" + Guid.Parse(groupToSave.SelectedFaculty))
        //);
        //        group.Department = await _requestSender.GetContetFromRequestAsyncAs<Department>(
        //await _requestSender.SendGetRequestAsync("https://localhost:44389/api/Departments/one?id=" + Guid.Parse(groupToSave.SelectedDepartment))
        //);
                var response = await _requestSender.SendPostRequestAsync("https://localhost:44389/api/AcademicGroups/create", group);
                return true;
            }
            return false;
        }

        public async Task<WorkManagementCycleEditViewModel> CreateWorkMangementCycle(WorkManagementCycle workManagementCycle)
        {
            var cycle = new WorkManagementCycleEditViewModel()
            {
                CycleName = workManagementCycle.Name,
                NumberOfHours = workManagementCycle.NumberOfHours,
                Semester = workManagementCycle.Semester,
                CycleId = workManagementCycle.Id,
                Faculties = await GetFaculties()
            };
            if (workManagementCycle.Group != null)
            {
                cycle.SelectedGroup = workManagementCycle.GroupId.ToString();
                if (workManagementCycle.Department != null)
                {
                    cycle.Groups = await GetAcademicGroups(workManagementCycle.DepartmentId);
                    cycle.SelectedDepartment = workManagementCycle.DepartmentId.ToString();
                    if (workManagementCycle.Department.FacultyId != null)
                    {
                        cycle.SelectedFaculty = workManagementCycle.Department.FacultyId.ToString();
                        cycle.Departments = await GetDepartments(workManagementCycle.Department.FacultyId);
                    }
                }
            }
            return cycle;
        }

        public async Task<bool> UpdateWorkManagementCycle(WorkManagementCycleEditViewModel cycleToUpdate)
        {
            if (cycleToUpdate != null)
            {

                var workManagementCycle = new WorkManagementCycle()
                {
                    Id = cycleToUpdate.CycleId,
                    Name = cycleToUpdate.CycleName,
                    Semester = cycleToUpdate.Semester,
                    NumberOfHours = cycleToUpdate.NumberOfHours,
                    GroupId = Guid.Parse(cycleToUpdate.SelectedGroup)
                };
                var response = await _requestSender.SendPostRequestAsync("https://localhost:44389/api/WorkManagementCycles/update", workManagementCycle);
                return true;
            }

            // Return false if customeredit == null or CustomerID is not a guid
            return false;
        }

        public async Task<EducationalCycleEditViewModel> CreateEducationalCycle()
        {
            var cycle = new EducationalCycleEditViewModel()
            {
                Faculties = await GetFaculties(),
                Departments = GetDepartments(),
                Groups = GetAcademicGroups(),
                Disciplines = await GetDisciplines(),
                TypesOfClasses = GetTypesOfClasses()
            };
            return cycle;
        }

        private IEnumerable<SelectListItem> GetTypesOfClasses()
        {
            List<SelectListItem> typesOfClassesSelectListItems = new List<SelectListItem>();
            var listOfTypes = Enum.GetValues(typeof(TypeOfClasses));
            foreach(var type in listOfTypes)
            {
                typesOfClassesSelectListItems.Add(new SelectListItem()
                {
                    Text = type.ToString(),
                    Value = ((int)type).ToString()
                });
            }
            var typeOfClassestip = new SelectListItem()
            {
                Value = null,
                Text = "--- select TypeOfClasses ---"
            };
            typesOfClassesSelectListItems.Insert(0, typeOfClassestip);
            return new SelectList(typesOfClassesSelectListItems, "Value", "Text");
        }

        private async Task<IEnumerable<SelectListItem>> GetDisciplines()
        {
            var disciplines = await _requestSender.GetContetFromRequestAsyncAs<List<Discipline>>(
            await _requestSender.SendGetRequestAsync("https://localhost:44389/api/Disciplines/list")
            );
            List<SelectListItem> disciplinesSelectListItems = disciplines.OrderBy(n => n.Name)
             .Select(n =>
                 new SelectListItem
                 {
                     Value = n.Id.ToString(),
                     Text = n.Name
                 }).ToList();
            var disciplinetip = new SelectListItem()
            {
                Value = null,
                Text = "--- select discipline ---"
            };
            disciplinesSelectListItems.Insert(0, disciplinetip);
            return new SelectList(disciplinesSelectListItems, "Value", "Text");
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
                var response = await _requestSender.SendPostRequestAsync("https://localhost:44389/api/EducationalCycles/create", educationalCycle);
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
                Faculties = await GetFaculties(),
                Disciplines = await GetDisciplines(),
                
            };
            if (educationalCycle.Group != null){
                cycle.SelectedGroup = educationalCycle.GroupId.ToString();
                if (educationalCycle.Department!= null)
                {
                    cycle.Groups = await GetGroups(educationalCycle.DepartmentId);
                    cycle.SelectedDepartment = educationalCycle.DepartmentId.ToString();
                    if (educationalCycle.Department.FacultyId != null) {
                        cycle.SelectedFaculty = educationalCycle.Department.FacultyId.ToString();
                        cycle.Departments = await GetDepartments(educationalCycle.Department.FacultyId);
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
                var response = await _requestSender.SendPostRequestAsync("https://localhost:44389/api/EducationalCycles/update", educationalCycle);
                return true;
            }

            // Return false if customeredit == null or CustomerID is not a guid
            return false;
        }

        public async Task<DepartmentEditViewModel> CreateDepartmentEditViewModel(Department department)
        {
            var departmentEditViewModel = new DepartmentEditViewModel()
            {
                DepartmentId = department.Id.ToString(),
                Faculties = await GetFaculties(),
                DepartmentName = department.Name,
                SelectedFaculty = department.FacultyId.ToString()
            };
            return departmentEditViewModel;
        }

        public async Task<bool> UpdateDepartment(DepartmentEditViewModel departmentToUpdate)
        {
            if (departmentToUpdate != null)
            {

                var department = new Department()
                {
                    Id = Guid.Parse(departmentToUpdate.DepartmentId),
                    Name = departmentToUpdate.DepartmentName,
                    FacultyId = Guid.Parse(departmentToUpdate.SelectedFaculty)
                };
                var response = await _requestSender.SendPostRequestAsync("https://localhost:44389/api/Departments/update", department);
                return true;
            }

            return false;
        }

        public async Task<AcademicGroupEditViewModel> CreateAcademicGroupEditViewModel(AcademicGroup group)
        {
            var groupEditViewModel = new AcademicGroupEditViewModel()
            {
                GroupName = group.Name,
                GroupId = group.Id.ToString(),
                Faculties = await GetFaculties(),
                SelectedDepartment = group.DepartmentId.ToString()
 
            };
            if(group.Department != null && group.Department.FacultyId != null)
            {
                groupEditViewModel.Departments = await GetDepartments(group.Department.FacultyId);
                groupEditViewModel.SelectedFaculty = group.Department.FacultyId.ToString();
            }

            return groupEditViewModel;
        }

        public async Task<bool> UpdateAcademicGroup(AcademicGroupEditViewModel groupToUpdate)
        {
            if (groupToUpdate != null)
            {

                var group = new AcademicGroup()
                {
                    Id = Guid.Parse(groupToUpdate.GroupId),
                    Name = groupToUpdate.GroupName,
                    DepartmentId = Guid.Parse(groupToUpdate.SelectedDepartment)
                };
                var response = await _requestSender.SendPostRequestAsync("https://localhost:44389/api/AcademicGroups/update", group);
                return true;
            }

            return false;
        }

        public Task<MixedGroupEditViewModel> CreateMixedGroup()
        {
            throw new NotImplementedException();
        }

        public Task<bool> SaveMixedGroup(MixedGroupEditViewModel mixedGroupEditViewModel)
        {
            throw new NotImplementedException();
        }




        public IEnumerable<SelectListItem> GetGroups()
        {
            List<SelectListItem> groups = new List<SelectListItem>()
            {
                //new SelectListItem
                //{
                //    Value = null,
                //    Text = "--- select group ---"
                //}
            };
            return groups;
        }

        public async Task<IEnumerable<SelectListItem>> GetGroups(Guid? departmentId)
        {
            var department = await _requestSender.GetContetFromRequestAsyncAs<Department>(
             await _requestSender.SendGetRequestAsync("https://localhost:44389/api/Departments/one?id=" + departmentId)
             );

            List<SelectListItem> groupsSelectListItems = department.Groups.OrderBy(n => n.Name)
            .Select(n =>
                new SelectListItem
                {
                    Value = n.Id.ToString(),
                    Text = n.Name
                }).ToList();
            var grouptip = new SelectListItem()
            {
                Value = null,
                Text = "--- select group ---"
            };
            groupsSelectListItems.Insert(0, grouptip);

            return new SelectList(groupsSelectListItems, "Value", "Text");
        }

        public async Task<TeachersFilter> CreateTeachersFilter()
        {
            var teachers = await _requestSender.GetContetFromRequestAsyncAs<List<Teacher>>(
                await _requestSender.SendGetRequestAsync("https://localhost:44389/api/Teachers/list")
                );
            TeachersFilter teachersFilter = new TeachersFilter()
            {
                Teachers = teachers,
                Faculties = await GetFaculties(),
                Departments = GetDepartments(),
                TeacherName = "",
                TeacherSurname = ""
            };
            return teachersFilter;
        }

        public async Task<TeacherDisplayViewModel> CreateTeacherDisplayViewModel(Guid? id)
        {
            var teacher = await _requestSender.GetContetFromRequestAsyncAs<Teacher>(
                await _requestSender.SendGetRequestAsync("https://localhost:44389/api/Teachers/one?id=" + id)
                );

            List<DisciplineViewModel> disciplineViewModels = new List<DisciplineViewModel>();
            var Discipines = teacher.EducationalCycles.Select(x => x.Discipline.Name).Distinct().ToList();
            var cyclesWithLecurersType = teacher.EducationalCycles.Where(x => x.TypeOfClasses == TypeOfClasses.Lecture).ToList();
            var cyclesWithLaboratorType = teacher.EducationalCycles.Where(x => x.TypeOfClasses == TypeOfClasses.Laboratory).ToList();
            var cyclesWithSeminarType = teacher.EducationalCycles.Where(x => x.TypeOfClasses == TypeOfClasses.Seminar).ToList();
            foreach(var disciplineName in Discipines)
            {
                var disciplineViewModel = new DisciplineViewModel()
                {
                    DisciplineName = disciplineName
                };
                var tempcycle = cyclesWithLecurersType.SingleOrDefault(x => x.Discipline.Name == disciplineViewModel.DisciplineName);
                if ( tempcycle  != null)
                {
                    disciplineViewModel.LectureHours = tempcycle.NumberOfHours;
                }
                tempcycle = cyclesWithLaboratorType.SingleOrDefault(x => x.Discipline.Name == disciplineViewModel.DisciplineName);
                if (tempcycle != null)
                {
                    disciplineViewModel.LaboratorHours = tempcycle.NumberOfHours;
                }
                tempcycle = cyclesWithSeminarType.SingleOrDefault(x => x.Discipline.Name == disciplineViewModel.DisciplineName);
                if (tempcycle != null)
                {
                    disciplineViewModel.SeminarHours = tempcycle.NumberOfHours;
                }
                disciplineViewModels.Add(disciplineViewModel);  
                
            }

            TeacherDisplayViewModel teacherDisplayViewModel = new TeacherDisplayViewModel()
            {
                FacultyName = teacher.Department.Faculty.Name,
                DepartmentName = teacher.Department.Name,
                Disciplines = disciplineViewModels,
                TeacherId = teacher.Id,
                TeacherName = teacher.Name,
                TeacherSurname = teacher.Surname   
            };
            return teacherDisplayViewModel;
        }
    }
}
