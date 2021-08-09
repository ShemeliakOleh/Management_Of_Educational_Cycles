using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Management_Of_Educational_Cycles.Logic.Services.EntityViewsProviders
{
    public abstract class EntityProvider
    {
        protected readonly DataManager dataManager;
        public EntityProvider(DataManager dataManager)
        {
            this.dataManager = dataManager;
        }
        protected async Task<List<SelectListItem>> GetAllFaculties()
        {
            var faculties = await dataManager.facultiesRepository.GetAllFaculties();
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
            return new SelectList(facultiesSelectListItems, "Value", "Text").ToList();
        }
        protected async Task<List<SelectListItem>> GetAllDisciplines()
        {
            var disciplines = await dataManager.disciplinesRepository.GetAllDisciplines();
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
                Text = "--- вибрати дисципліну ---"
            };
            disciplinesSelectListItems.Insert(0, disciplinetip);
            return new SelectList(disciplinesSelectListItems, "Value", "Text").ToList();
        }
        protected async Task<List<SelectListItem>> GetGroupsByDepartment(Guid? departmentId)
        {
            
            var groups = await dataManager.groupsRepository.GetGroupsByDepartment(departmentId);
            List<SelectListItem> groupsSelectListItems = groups.OrderBy(n => n.Name)
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

            return new SelectList(groupsSelectListItems, "Value", "Text").ToList();
        }
        protected IEnumerable<SelectListItem> GetTypesOfClasses()
        {
            List<SelectListItem> typesOfClassesSelectListItems = new List<SelectListItem>();
            var listOfTypes = Enum.GetValues(typeof(Management_Of_Educational_Cycles.Domain.Models.TypeOfClasses));
            foreach (var type in listOfTypes)
            {

                typesOfClassesSelectListItems.Add(new SelectListItem()
                {
                    Text = type.ToString(),
                    Value = ((int)type).ToString()
                });
            }

            return new SelectList(typesOfClassesSelectListItems, "Value", "Text");
        }
        protected async Task<List<SelectListItem>> GetDepartmentsByFaculty(Guid? facultyId)
        {
            var departments = await dataManager.departmentsRepository.GetDepartmentsByFaculty(facultyId);

            List<SelectListItem> departmentsSelectListItems = departments.OrderBy(n => n.Name)
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
            return new SelectList(departmentsSelectListItems, "Value", "Text").ToList();
        }

    }
}
