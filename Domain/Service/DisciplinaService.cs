using Domain.Entidade;
using Domain.Interface.Repository;
using Domain.Interface.Service;
using Shared.Interface.Repository;
using Shared.Service;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Service
{
    public class DisciplinaService : BaseCrudService<Disciplina>, IDisciplinaService
    {
        private readonly IDisciplinaRepository repository;
        public DisciplinaService(IDisciplinaRepository repository) : base(repository)
        {
            this.repository = repository;            
        }
    }
}
