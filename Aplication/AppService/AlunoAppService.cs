using Aplication.Interface;
using Aplication.ViewModel;
using AutoMapper;
using Domain.Entidade;
using Domain.Interface.Service;
using Shared.Interface;

namespace Aplication.AppService
{
    public class AlunoAppService : BaseCrudAppService<AlunoViewModel, Aluno>, IAlunoAppService
    {
        private readonly IAlunoService service;
        private readonly IMapper mapper;
        public AlunoAppService(IAlunoService service, IMapper mapper) : base(service, mapper)
        {
            this.service = service;
            this.mapper = mapper;
        }
    }
}
