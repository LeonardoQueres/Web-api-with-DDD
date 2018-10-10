using Domain.Entidade;
using Shared.Interface.Repository;
using System.Collections.Generic;

namespace Domain.Interface.Repository
{
    public interface ITurmaDisciplinaRepository : IBaseRepository<TurmaDisciplina, string>
    {
        void Remover(TurmaDisciplina turmaDisciplina);
        void RemoverPorId(string id);
        void RemoverTodos(string turmaId);
        void Inserir(TurmaDisciplina turmaDisciplina);
        void Atualizar(TurmaDisciplina turmaDisciplina);
        IEnumerable<TurmaDisciplina> RecuperarTodos(string turmaId);
    }
}
