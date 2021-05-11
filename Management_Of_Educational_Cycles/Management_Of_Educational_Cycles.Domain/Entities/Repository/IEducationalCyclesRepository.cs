﻿using Management_Of_Educational_Cycles.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;

namespace Management_Of_Educational_Cycles.Domain.Entities.Repository
{
    public interface IEducationalCyclesRepository
    {
        public Task<bool> Add([FromBody] EducationalCycle educationalCycle);
        public Task<bool> Update([FromBody] EducationalCycle educationalCycle);
        public Task<bool> Remove(Guid? id);
        public Task<EducationalCycle> GetById(Guid? id);
        public Task<List<EducationalCycle>> GetAll();
        public bool Exists(Guid? id);
    }
}