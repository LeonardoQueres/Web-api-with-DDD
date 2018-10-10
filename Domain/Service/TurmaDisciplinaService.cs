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
    public class TurmaDisciplinaService : BaseService<TurmaDisciplina, string>, ITurmaDisciplinaService
    {
        private readonly ITurmaDisciplinaRepository repository;
        public TurmaDisciplinaService(ITurmaDisciplinaRepository repository) : base(repository)
        {
            this.repository = repository;
        }

        public override ICollection<TurmaDisciplina> Pesquisar(Expression<Func<TurmaDisciplina, bool>> predicate)
        {
            throw new NotSupportedException("Para pesquisar utilizar a entidade agregadora e buscar por turmaId");
        }

        public override TurmaDisciplina RecuperarPorId(string id)
        {
            throw new NotSupportedException("Para pesquisar utilizar a entidade agregadora e buscar por turmaId");
        }

        public override ICollection<TurmaDisciplina> RecuperarTodos()
        {
            throw new NotSupportedException("Para pesquisar utilizar a entidade agregadora e buscar por turmaId");
        }
        IEnumerable<TurmaDisciplina> ITurmaDisciplinaService.RecuperarTodos(string turmaId)
        {
            return repository.RecuperarTodos(turmaId);
        }

        ResultadoValidacao ITurmaDisciplinaService.Processar(TurmaDisciplina turmaDisciplinaModel, TurmaDisciplina turmaDisciplinaBancoDados, string turmaId)
        {
            var turmaDisciplinasModel = new TurmaDisciplina[1] { turmaDisciplinaModel };
            var turmaDisciplinasBancoDados = (turmaDisciplinaBancoDados == null ? null : new TurmaDisciplina[1] { turmaDisciplinaBancoDados });

            return this.Processar(turmaDisciplinasModel, turmaDisciplinasBancoDados, turmaId);
        }

        ResultadoValidacao ITurmaDisciplinaService.Processar(IEnumerable<TurmaDisciplina> turmaDisciplinaModel, IEnumerable<TurmaDisciplina> turmaDisciplinaBancoDados, string turmaId)
        {
            return this.Processar(turmaDisciplinaModel, turmaDisciplinaBancoDados, turmaId);
        }

        void ITurmaDisciplinaService.RemoverPorId(string id)
        {
            repository.RemoverPorId(id);
        }

        void ITurmaDisciplinaService.RemoverTodos(string turmaId)
        {
            repository.RemoverTodos(turmaId);
        }

        #region Metodos Privados

        private ResultadoValidacao Processar(IEnumerable<TurmaDisciplina> turmaDisciplinaModel, IEnumerable<TurmaDisciplina> turmaDisciplinaBancoDados, string turmaId)
        {
            if (string.IsNullOrEmpty(turmaId))
                throw new ArgumentNullException("O parâmetro turmaId não pode ser nulo ou vazio");

            var validacao = new ResultadoValidacao();

            if (turmaDisciplinaModel != null)
            {
                if (turmaDisciplinaBancoDados != null)
                {
                    // Verifica os registros removidos pelo usuario e remove da base de dados
                    var registrosParaRemover = turmaDisciplinaBancoDados.Where(bd => !turmaDisciplinaModel.Select(m => m.Id).Contains(bd.Id));
                    registrosParaRemover.ToList().ForEach(x => repository.Remover(x));
                }

                // Verifica a acao a ser tomada
                foreach (var TurmaDisciplinaModel in turmaDisciplinaModel)
                {
                    // Se o model nao tiver id e um novo registro
                    if (string.IsNullOrEmpty(TurmaDisciplinaModel.Id))
                    {
                        validacao.AdicionarMensagens(this.Inserir(TurmaDisciplinaModel, turmaId));
                    }
                    else
                    {
                        // Carrega o registro da base de dados com o mesmo id do enviado pelo model
                        var TurmaDisciplinasBancoDados = turmaDisciplinaBancoDados?.SingleOrDefault(x => x.Id == TurmaDisciplinaModel.Id);
                        // Se tem id e nao em correspondente na base de dados insere um novo registro pois pode ser um segundo usuario inserindo
                        if (turmaDisciplinaBancoDados == null)
                        {
                            validacao.AdicionarMensagens(this.Inserir(TurmaDisciplinaModel, turmaId));
                        }
                        else
                        {
                            // Se acho correspondente na base de dados atualiza as informacoes e grava
                            validacao.AdicionarMensagens(this.Atualizar(TurmaDisciplinaModel, TurmaDisciplinasBancoDados));
                        }
                    }
                }
            }
            else
            {
                turmaDisciplinaBancoDados?.ToList().ForEach(x => repository.Remover(x));
            }

            return validacao;
        }

        private ValidationResult Inserir(TurmaDisciplina turmaDisciplina, string turmaId)
        {
            turmaDisciplina.TurmaId = turmaId;

            var validacao = turmaDisciplina.Validar();

            if (validacao.IsValid)
            {
                repository.Inserir(turmaDisciplina);
            }

            return validacao;
        }

        private ValidationResult Atualizar(TurmaDisciplina turmaDisciplinaModel, TurmaDisciplina turmaDisciplinaBancoDados)
        {
            turmaDisciplinaBancoDados.PreencherDados(turmaDisciplinaModel);

            var validacao = turmaDisciplinaBancoDados.Validar();

            if (validacao.IsValid)
            {
                repository.Atualizar(turmaDisciplinaBancoDados);
            }

            return validacao;
        }

        #endregion
    }
}
