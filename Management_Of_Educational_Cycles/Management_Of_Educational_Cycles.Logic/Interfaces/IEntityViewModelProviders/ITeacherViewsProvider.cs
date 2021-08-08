using Management_Of_Educational_Cycles.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Management_Of_Educational_Cycles.Logic.Interfaces.IEntityViewModelProviders
{
    public interface ITeacherViewsProvider
    {
        public Task<bool> SaveTeacher(TeacherEditViewModel teacherToSave);
        public Task<TeacherDisplayViewModel> CreateTeacherDisplayViewModel(Guid? id);
        public Task<TeachersFilter> CreateTeachersFilter();
        public Task<List<TeacherDisplayViewModel>> GetTeachers();
        public Task<TeacherEditViewModel> CreateTeacher();
        public Task<TeacherEditViewModel> CreateTeacher(Teacher teacher);
        public Task<Teacher> Convert2Teacher(TeacherEditViewModel teacherEditViewModel);
    }
}
