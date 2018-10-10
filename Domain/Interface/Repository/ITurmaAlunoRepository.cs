using Domain.Entidade;
using Shared.Interface.Repository;
using System.Collections.Generic;

namespace Domain.Interface.Repository
{
    public interface ITurmaAlunoRepository : IBaseRepository<TurmaAluno, string>
    {
        void Remover(TurmaAluno turmaAluno);
        void RemoverPorId(string id);
        void RemoverTodos(string turmaId);
        void Inserir(TurmaAluno turmaAluno);
        void Atualizar(TurmaAluno turmaAluno);
        IEnumerable<TurmaAluno> RecuperarTodos(string turmaId);
    }
}
