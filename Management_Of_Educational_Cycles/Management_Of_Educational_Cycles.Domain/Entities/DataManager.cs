using Management_Of_Educational_Cycles.Domain.Entities.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Management_Of_Educational_Cycles.Domain.Entities
{
   public class DataManager
    {
        public IWorkManagementCyclesRepository _workManagementCyclesRepository { get; set; }
        public IEducationalCyclesRepository _educationalCyclesRepository { get; set; }
        public ITeachersRepository _teachersRepository { get; set; }
        public IFacultiesRepository _facultiesRepository{ get; set; }
        public IDepartmentRepository _departmentRepository { get; set; }

        public IGroupRepository _groupRepository { get; set; }

        public DataManager(IWorkManagementCyclesRepository workManagementCyclesRepository,
            IEducationalCyclesRepository educationalCyclesRepository,
            ITeachersRepository teachersRepository, IFacultiesRepository facultiesRepository,
            IDepartmentRepository departmentRepository, IGroupRepository groupRepository)
        {
            _workManagementCyclesRepository = workManagementCyclesRepository;
            _educationalCyclesRepository = educationalCyclesRepository;
            _teachersRepository = teachersRepository;
            _facultiesRepository = facultiesRepository;
            _departmentRepository = departmentRepository;
            _groupRepository = groupRepository;
        }
         
    }
}
