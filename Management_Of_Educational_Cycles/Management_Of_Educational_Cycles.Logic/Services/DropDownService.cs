using Management_Of_Educational_Cycles.Domain.Models;
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
        public async Task<GroupEditViewModel> CreateGroup()
        {
            var group = new GroupEditViewModel()
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
                    FacultyId = Guid.Parse(teacherToSave.SelectedFaculty),
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
                    GroupId = Guid.Parse(cycleToSave.SelectedGroup)
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

            IEnumerable<SelectListItem> departmentsSelectListItems = faculty.Departments.OrderBy(n => n.Name)
            .Select(n =>
                new SelectListItem
                {
                    Value = n.Id.ToString(),
                    Text = n.Name
                }).ToList();

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
                        FacultyName = x.Faculty.Name,
                        DepartmentName = x.Department.Name
                    };
                    teachersDisplay.Add(teacherDisplay);
                }
                return teachersDisplay;
            }
            return null;
        }

        public async Task<DepartmentEditViewModel> CreateDepartment()
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
                        Groups = new List<Group>()
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
            teacherViewModel.Departments =await GetDepartments(teacher.FacultyId);
            teacherViewModel.TeacherId = teacher.Id;
            teacherViewModel.TeacherName = teacher.Name;
            teacherViewModel.TeacherSurname = teacher.Surname;
            teacherViewModel.SelectedFaculty = teacher.Faculty.Id.ToString();
            teacherViewModel.SelectedDepartment = teacher.Department.Id.ToString();
            return teacherViewModel;
        }

        public async Task<Teacher> Convert2Teacher(TeacherEditViewModel teacherEditViewModel)
        {
            var faculty = await _requestSender.GetContetFromRequestAsyncAs<Faculty>(
        await _requestSender.SendGetRequestAsync("https://localhost:44389/api/Faculties/one?id=" + Guid.Parse(teacherEditViewModel.SelectedFaculty))
        );
            var department = await _requestSender.GetContetFromRequestAsyncAs<Department>(
    await _requestSender.SendGetRequestAsync("https://localhost:44389/api/Departments/one?id=" + Guid.Parse(teacherEditViewModel.SelectedDepartment)));
            return new Teacher() { Name = teacherEditViewModel.TeacherName, Surname = teacherEditViewModel.TeacherSurname, Faculty = faculty, Department = department };
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
        public async Task<IEnumerable<SelectListItem>> GetGroups(Guid? departmentId)
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

        public async Task<bool> SaveGroup(GroupEditViewModel groupToSave)
        {
            if (groupToSave != null)
            {

                var group = new Group()
                {
                    Name = groupToSave.GroupName,
                    FacultyId = Guid.Parse(groupToSave.SelectedFaculty),
                    DepartmentId = Guid.Parse(groupToSave.SelectedDepartment)

                };
        //        group.Faculty = await _requestSender.GetContetFromRequestAsyncAs<Faculty>(
        //await _requestSender.SendGetRequestAsync("https://localhost:44389/api/Faculties/one?id=" + Guid.Parse(groupToSave.SelectedFaculty))
        //);
        //        group.Department = await _requestSender.GetContetFromRequestAsyncAs<Department>(
        //await _requestSender.SendGetRequestAsync("https://localhost:44389/api/Departments/one?id=" + Guid.Parse(groupToSave.SelectedDepartment))
        //);
                var response = await _requestSender.SendPostRequestAsync("https://localhost:44389/api/Groups/create", group);
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
                Faculties = await GetFaculties(),
                Departments =await GetDepartments(workManagementCycle.Group.FacultyId),
                Groups =await GetGroups(workManagementCycle.Group.DepartmentId),
                SelectedFaculty = workManagementCycle.Group.FacultyId.ToString(),
                SelectedDepartment = workManagementCycle.Group.DepartmentId.ToString(),
                SelectedGroup = workManagementCycle.GroupId.ToString()
            };
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
    }
}
