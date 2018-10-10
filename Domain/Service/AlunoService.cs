using Domain.Entidade;
using Domain.Interface.Repository;
using Domain.Interface.Service;
using Shared.Service;

namespace Domain.Service
{
    public class AlunoService : BaseCrudService<Aluno>, IAlunoService
    {
        private readonly IAlunoRepository repository;
        public AlunoService(IAlunoRepository repository) : base(repository)
        {
            this.repository = repository;
        }
    }
}
