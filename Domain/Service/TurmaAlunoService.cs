using Domain.Entidade;
using Domain.Interface.Repository;
using Domain.Interface.Service;
using FluentValidation.Results;
using Shared.Service;
using Shared.Validator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Domain.Service
{
    public class TurmaAlunoService : BaseService<TurmaAluno, string>, ITurmaAlunoService
    {
        private readonly ITurmaAlunoRepository repository;
        public TurmaAlunoService(ITurmaAlunoRepository repository) : base(repository)
        {
            this.repository = repository;
        }

        public override ICollection<TurmaAluno> Pesquisar(Expression<Func<TurmaAluno, bool>> predicate)
        {
            throw new NotSupportedException("Para pesquisar utilizar a entidade agregadora e buscar por turmaId");
        }

        public override TurmaAluno RecuperarPorId(string id)
        {
            throw new NotSupportedException("Para pesquisar utilizar a entidade agregadora e buscar por turmaId");
        }

        public override ICollection<TurmaAluno> RecuperarTodos()
        {
            throw new NotSupportedException("Para pesquisar utilizar a entidade agregadora e buscar por turmaId");
        }
        IEnumerable<TurmaAluno> ITurmaAlunoService.RecuperarTodos(string turmaId)
        {
            return repository.RecuperarTodos(turmaId);
        }

        ResultadoValidacao ITurmaAlunoService.Processar(TurmaAluno turmaAlunoModel, TurmaAluno turmaAlunoBancoDados, string turmaId)
        {
            var turmaAlunosModel = new TurmaAluno[1] { turmaAlunoModel };
            var turmaAlunosBancoDados = (turmaAlunoBancoDados == null ? null : new TurmaAluno[1] { turmaAlunoBancoDados });

            return this.Processar(turmaAlunosModel, turmaAlunosBancoDados, turmaId);
        }

        ResultadoValidacao ITurmaAlunoService.Processar(IEnumerable<TurmaAluno> turmaAlunosModel, IEnumerable<TurmaAluno> turmaAlunosBancoDados, string turmaId)
        {
            return this.Processar(turmaAlunosModel, turmaAlunosBancoDados, turmaId);
        }

        void ITurmaAlunoService.RemoverPorId(string id)
        {
            repository.RemoverPorId(id);
        }

        void ITurmaAlunoService.RemoverTodos(string turmaId)
        {
            repository.RemoverTodos(turmaId);
        }

        #region Metodos Privados

        private ResultadoValidacao Processar(IEnumerable<TurmaAluno> turmaAlunosModel, IEnumerable<TurmaAluno> turmaAlunosBancoDados, string turmaId)
        {
            if (string.IsNullOrEmpty(turmaId))
                throw new ArgumentNullException("O parâmetro turmaId não pode ser nulo ou vazio");

            var validacao = new ResultadoValidacao();

            if (turmaAlunosModel != null)
            {
                if (turmaAlunosBancoDados != null)
                {
                    // Verifica os registros removidos pelo usuario e remove da base de dados
                    var registrosParaRemover = turmaAlunosBancoDados.Where(bd => !turmaAlunosModel.Select(m => m.Id).Contains(bd.Id));
                    registrosParaRemover.ToList().ForEach(x => repository.Remover(x));
                }

                // Verifica a acao a ser tomada
                foreach (var TurmaAlunoModel in turmaAlunosModel)
                {
                    // Se o model nao tiver id e um novo registro
                    if (string.IsNullOrEmpty(TurmaAlunoModel.Id))
                    {
                        validacao.AdicionarMensagens(this.Inserir(TurmaAlunoModel, turmaId));
                    }
                    else
                    {
                        // Carrega o registro da base de dados com o mesmo id do enviado pelo model
                        var TurmaAlunoBancoDados = turmaAlunosBancoDados?.SingleOrDefault(x => x.Id == TurmaAlunoModel.Id);
                        // Se tem id e nao em correspondente na base de dados insere um novo registro pois pode ser um segundo usuario inserindo
                        if (turmaAlunosBancoDados == null)
                        {
                            validacao.AdicionarMensagens(this.Inserir(TurmaAlunoModel, turmaId));
                        }
                        else
                        {
                            // Se acho correspondente na base de dados atualiza as informacoes e grava
                            validacao.AdicionarMensagens(this.Atualizar(TurmaAlunoModel, TurmaAlunoBancoDados));
                        }
                    }
                }
            }
            else
            {
                turmaAlunosBancoDados?.ToList().ForEach(x => repository.Remover(x));
            }

            return validacao;
        }

        private ValidationResult Inserir(TurmaAluno turmaAluno, string turmaId)
        {
            turmaAluno.TurmaId = turmaId;

            var validacao = turmaAluno.Validar();

            if (validacao.IsValid)
            {
                repository.Inserir(turmaAluno);
            }

            return validacao;
        }

        private ValidationResult Atualizar(TurmaAluno turmaAlunoModel, TurmaAluno turmaAlunoBancoDados)
        {
            turmaAlunoBancoDados.PreencherDados(turmaAlunoModel);

            var validacao = turmaAlunoBancoDados.Validar();

            if (validacao.IsValid)
            {
                repository.Atualizar(turmaAlunoBancoDados);
            }

            return validacao;
        }

        #endregion
    }
}
