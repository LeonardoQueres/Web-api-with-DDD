using Domain.Entidade;
using Domain.Interface.Repository;
using Shared.Infra;
using System.Collections.Generic;
using System.Linq;

namespace Infra.Data.Repository
{
    public class TurmaAlunoRepository : BaseRepository<TurmaAluno, string>, ITurmaAlunoRepository
    {
        public readonly AdminContext dbContext;
        public TurmaAlunoRepository(AdminContext dbContext) : base(dbContext)
        {
            this.dbContext = dbContext;
        }

        void ITurmaAlunoRepository.Atualizar(TurmaAluno turmaAluno)
        {
            base.Atualizar(turmaAluno);
        }

        void ITurmaAlunoRepository.Inserir(TurmaAluno turmaAluno)
        {
            base.Inserir(turmaAluno);
        }

        IEnumerable<TurmaAluno> ITurmaAlunoRepository.RecuperarTodos(string turmaId)
        {
            return dbContext.Set<TurmaAluno>()
                .Where(x => x.TurmaId == turmaId)
                .ToList();
        }

        void ITurmaAlunoRepository.Remover(TurmaAluno turmaAluno)
        {
            base.Remover(turmaAluno);
        }

        void ITurmaAlunoRepository.RemoverPorId(string id)
        {
            base.Remover(base.RecuperarPorId(id));
        }

        void ITurmaAlunoRepository.RemoverTodos(string turmaId)
        {
            dbContext.Set<TurmaAluno>()
               .Where(x => x.TurmaId == turmaId)
               .ToList()
               .ForEach(x => base.Remover(x));
        }
    }
}
