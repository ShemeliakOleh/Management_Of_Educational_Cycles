using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Management_Of_Educational_Cycles.Logic.Interfaces.IEntityRepository;
namespace Management_Of_Educational_Cycles.Logic.Services
{
   public class DataManager
    {
        public readonly IDepartmentsRepository departmentsRepository;
        public readonly IDisciplinesRepository disciplinesRepository;
        public readonly IEducationalCyclesRepository educationalCyclesRepository;
        public readonly IFacultiesRepository facultiesRepository;
        public readonly IGroupsRepository groupsRepository;
        public readonly ITeachersRepository teachersRepository;
        public readonly IWorkManagementCyclesRepository workManagementCyclesRepository;

        public DataManager(IDepartmentsRepository departmentsRepository, IDisciplinesRepository disciplinesRepository,
            IEducationalCyclesRepository educationalCyclesRepository, IFacultiesRepository facultiesRepository,
            IGroupsRepository groupsRepository, ITeachersRepository teachersRepository,
            IWorkManagementCyclesRepository workManagementCyclesRepository)
        {
            this.departmentsRepository = departmentsRepository;
            this.disciplinesRepository = disciplinesRepository;
            this.educationalCyclesRepository = educationalCyclesRepository;
            this.facultiesRepository = facultiesRepository;
            this.groupsRepository = groupsRepository;
            this.teachersRepository = teachersRepository;
            this.workManagementCyclesRepository = workManagementCyclesRepository;
        }
    }
}
