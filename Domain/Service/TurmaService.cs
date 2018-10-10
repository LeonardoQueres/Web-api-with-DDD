using Domain.Entidade;
using Domain.Interface.Repository;
using Domain.Interface.Service;
using Shared.Service;
using Shared.Validator;

namespace Domain.Service
{
    public class TurmaService : BaseCrudService<Turma>, ITurmaService
    {
        private readonly ITurmaRepository repository;
        private readonly ITurmaAlunoService turmaAlunoService;
        private readonly ITurmaDisciplinaService turmaDisciplinaService;
        public TurmaService(ITurmaRepository repository, ITurmaAlunoService turmaAlunoService, ITurmaDisciplinaService turmaDisciplinaService) : base(repository)
        {
            this.repository = repository;
            this.turmaAlunoService = turmaAlunoService;
            this.turmaDisciplinaService = turmaDisciplinaService;
        }

        public override ResultadoValidacao Inserir(Turma model)
        {
            var resultado = base.Inserir(model);

            if (resultado.IsValid)
            {
                resultado.AdicionarMensagens(turmaAlunoService.Processar(model.turmaAluno, null, model.Id));
                resultado.AdicionarMensagens(turmaDisciplinaService.Processar(model.turmaDisciplina, null, model.Id));
            }
            return resultado;
        }

        public override ResultadoValidacao Atualizar(Turma model)
        {
            var turma = this.RecuperarPorId(model.Id);
            turma.PreencherDados(model);

            var resultado = base.Atualizar(model);

            if (resultado.IsValid)
            {
                resultado.AdicionarMensagens(turmaAlunoService.Processar(model.turmaAluno, turma.turmaAluno, model.Id));
                resultado.AdicionarMensagens(turmaDisciplinaService.Processar(model.turmaDisciplina, turma.turmaDisciplina, model.Id));
            }
            return resultado;
        }

        public override Turma RecuperarPorId(string id)
        {
            var turma = base.RecuperarPorId(id);
            turma.turmaAluno = turmaAlunoService.RecuperarTodos(id);
            turma.turmaDisciplina = turmaDisciplinaService.RecuperarTodos(id);
            return turma;
        }

        public override void RemoverPorId(string id)
        {
            turmaAlunoService.RemoverTodos(id);
            turmaDisciplinaService.RemoverTodos(id);
            base.RemoverPorId(id);
        }
    }
}
