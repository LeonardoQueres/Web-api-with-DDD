using Aplication.Interface;
using Aplication.ViewModel;
using AutoMapper;
using Domain.Entidade;
using Domain.Interface.Service;
using Shared.Interface;

namespace Aplication.AppService
{
    public class TurmaAppService : BaseCrudAppService<TurmaViewModel, Turma>, ITurmaAppService
    {
        private readonly ITurmaService service;
        private readonly IMapper mapper;
        public TurmaAppService(ITurmaService service, IMapper mapper) : base(service, mapper)
        {
            this.service = service;
            this.mapper = mapper;
        }
    }
}
