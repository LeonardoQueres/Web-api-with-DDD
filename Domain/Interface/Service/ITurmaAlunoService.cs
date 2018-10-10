using Domain.Entidade;
using Shared.Interface.Service;
using Shared.Validator;
using System.Collections.Generic;

namespace Domain.Interface.Service
{
    public interface ITurmaAlunoService : IBaseService<TurmaAluno, string>
    {
        ResultadoValidacao Processar(TurmaAluno turmaAlunoModel, TurmaAluno turmaAlunoBancoDados, string TurmaId);

        ResultadoValidacao Processar(IEnumerable<TurmaAluno> turmaAlunoModel, IEnumerable<TurmaAluno> turmaAlunoBancoDados, string TurmaId);

        IEnumerable<TurmaAluno> RecuperarTodos(string TurmaId);

        void RemoverPorId(string id);

        void RemoverTodos(string TurmaId);
    }
}
