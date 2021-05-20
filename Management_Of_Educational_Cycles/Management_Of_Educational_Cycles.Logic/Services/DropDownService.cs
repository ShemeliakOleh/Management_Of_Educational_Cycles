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

        public async Task<TeacherCreateViewModel> CreateTeacher()
        {
            var teacher = new TeacherCreateViewModel()
            {
                Faculties = await GetFaculties(),
                Departments = GetDepartments()
            };
            return teacher;
        }
        public async Task<bool> SaveTeacher(TeacherCreateViewModel teacherToSave)
        {
            if (teacherToSave != null)
            {

                var teacher = new Teacher()
                {
                    Name = teacherToSave.TeacherName,
                    Surname = teacherToSave.TeacherSurname,
                };
                teacher.Faculty = await _requestSender.GetContetFromRequestAsyncAs<Faculty>(
        await _requestSender.SendGetRequestAsync("https://localhost:44389/api/Faculties/one?id=" + Guid.Parse(teacherToSave.SelectedFaculty))
        );
                teacher.Department = await _requestSender.GetContetFromRequestAsyncAs<Department>(
        await _requestSender.SendGetRequestAsync("https://localhost:44389/api/Departments/one?id=" + Guid.Parse(teacherToSave.SelectedDepartment))
        );
                var response = await _requestSender.SendPostRequestAsync("https://localhost:44389/api/Teachers/create", teacher);
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
                new SelectListItem
                {
                    Value = null,
                    Text = " "
                }
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
                    department.Faculty = await _requestSender.GetContetFromRequestAsyncAs<Faculty>(
            await _requestSender.SendGetRequestAsync("https://localhost:44389/api/Faculties/one?id=" + Guid.Parse(departmentToSave.SelectedFaculty))
            );
                    var response = await _requestSender.SendPostRequestAsync("https://localhost:44389/api/Departments/create", department);
                    return true;
                }
            }
            // Return false if customeredit == null or CustomerID is not a guid
            return false;
        }
    }
}
