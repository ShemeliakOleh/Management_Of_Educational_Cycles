using Management_Of_Educational_Cycles.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Management_Of_Educational_Cycles.Logic.Interfaces.IEntityRepository
{
    public interface ITeachersRepository
    {
        public Task<Teacher> GetById(Guid? id);
        public Task<List<Teacher>> GetTeachers();

        public Task<bool> CreateTeacher(Teacher teacher);
        public Task<bool> UpdateTeacher(Teacher teacher);
        public Task<bool> DeleteById(Guid? id);
        public Task<List<Teacher>> GetFilteredTeachers(Teacher pattern);
    }
}
