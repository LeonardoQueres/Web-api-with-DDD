using Domain.Entidade;
using Domain.Interface.Repository;
using Shared.Infra;
using System.Collections.Generic;
using System.Linq;

namespace Infra.Data.Repository
{
    public class TurmaDisciplinaRepository : BaseRepository<TurmaDisciplina, string>, ITurmaDisciplinaRepository
    {
        private readonly AdminContext dbContext;
        public TurmaDisciplinaRepository(AdminContext dbContext) : base(dbContext)
        {
            this.dbContext = dbContext;
        }

        void ITurmaDisciplinaRepository.Atualizar(TurmaDisciplina turmaDisciplina)
        {
            base.Atualizar(turmaDisciplina);
        }

        void ITurmaDisciplinaRepository.Inserir(TurmaDisciplina turmaDisciplina)
        {
            base.Inserir(turmaDisciplina);
        }

        IEnumerable<TurmaDisciplina> ITurmaDisciplinaRepository.RecuperarTodos(string turmaId)
        {
            return dbContext.Set<TurmaDisciplina>()
                .Where(x => x.TurmaId == turmaId)
                .ToList();
        }

        void ITurmaDisciplinaRepository.Remover(TurmaDisciplina turmaDisciplina)
        {
            base.Remover(turmaDisciplina);
        }

        void ITurmaDisciplinaRepository.RemoverPorId(string id)
        {
            base.Remover(base.RecuperarPorId(id));
        }

        void ITurmaDisciplinaRepository.RemoverTodos(string turmaId)
        {
            dbContext.Set<TurmaDisciplina>()
               .Where(x => x.TurmaId == turmaId)
               .ToList()
               .ForEach(x => base.Remover(x));
        }
    }
}
