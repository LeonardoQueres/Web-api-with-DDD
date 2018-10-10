using FluentValidation;
using Shared;
using Shared.Entity;
using Shared.Validator;
using System.Collections.Generic;

namespace Domain.Entidade
{
    public class Disciplina : EntityCrud<Disciplina>
    {
        public override AbstractValidator<Disciplina> Validador => new DisciplinaValidator();

        public string Descricao { get; set; }
        public IEnumerable<TurmaDisciplina> turmaDisciplina { get; set; }
        public override void PreencherDados(Disciplina data)
        {
            Descricao = data.Descricao;
        }

        public override ResultadoValidacao Validar()
        {
            return ExecutarValidacaoPadrao(this);
        }
    }

    internal class DisciplinaValidator : AbstractValidator<Disciplina>
    {
        public DisciplinaValidator()
        {
            RuleFor(x => x.Descricao)
                .NotNull().WithMessage(Textos.Geral_Mensagem_Erro_Campo_null)
                .MaximumLength(100).WithMessage(Textos.Geral_Mensagem_Erro_Tamanho_Campo);
        }
    }
}
