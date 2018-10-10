using FluentValidation;
using Shared;
using Shared.Entity;
using Shared.Validator;
using System.Collections.Generic;

namespace Domain.Entidade
{
    public class Turma : EntityCrud<Turma>
    {
        public override AbstractValidator<Turma> Validador => new TurmaValidator();

        public string Descricao { get; set; }
        public IEnumerable<TurmaAluno> turmaAluno { get; set; }
        public IEnumerable<TurmaDisciplina> turmaDisciplina { get; set; }

        public override void PreencherDados(Turma data)
        {
            Descricao = data.Descricao;
        }

        public override ResultadoValidacao Validar()
        {
            return ExecutarValidacaoPadrao(this);
        }
    }

    internal class TurmaValidator : AbstractValidator<Turma>
    {
        public TurmaValidator()
        {
            RuleFor(x => x.Descricao)
                .NotNull().WithMessage(Textos.Geral_Mensagem_Erro_Campo_null)
                .MaximumLength(100);
        }
    }
}
