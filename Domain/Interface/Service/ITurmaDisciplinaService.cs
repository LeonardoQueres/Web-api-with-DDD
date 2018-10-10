using Domain.Entidade;
using Shared.Interface.Service;
using Shared.Validator;
using System.Collections.Generic;

namespace Domain.Interface.Service
{
    public interface ITurmaDisciplinaService : IBaseService<TurmaDisciplina, string>
    {
        ResultadoValidacao Processar(TurmaDisciplina turmaAlunoModel, TurmaDisciplina turmaAlunoBancoDados, string TurmaId);

        ResultadoValidacao Processar(IEnumerable<TurmaDisciplina> turmaAlunoModel, IEnumerable<TurmaDisciplina> turmaAlunoBancoDados, string TurmaId);

        IEnumerable<TurmaDisciplina> RecuperarTodos(string TurmaId);

        void RemoverPorId(string id);

        void RemoverTodos(string TurmaId);
    }
}
