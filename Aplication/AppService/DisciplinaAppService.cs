using Aplication.Interface;
using Aplication.ViewModel;
using AutoMapper;
using Domain.Entidade;
using Domain.Interface.Service;
using Shared.Interface;

namespace Aplication.AppService
{
    public class DisciplinaAppService : BaseCrudAppService<DisciplinaViewModel, Disciplina>, IDisciplinaAppService
    {
        private readonly IDisciplinaService service;
        private readonly IMapper mapper;
        public DisciplinaAppService(IDisciplinaService service, IMapper mapper) : base(service, mapper)
        {
            this.service = service;
            this.mapper = mapper;
        }
    }
}
