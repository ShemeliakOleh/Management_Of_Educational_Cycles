using Management_Of_Educational_Cycles.Logic.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Management_Of_Educational_Cycles.Domain.Models;
using Management_Of_Educational_Cycles.Logic.Interfaces.IEntityRepository;

namespace Management_Of_Educational_Cycles.Logic.Services.EntityRepository
{
    public abstract class EntityRepository
    {
        public  IRequestSender _requestSender { get; set; }
        public EntityRepository(IRequestSender requestSender)
        {
            _requestSender = requestSender;
        }
    }
}
