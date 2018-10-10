using FluentValidation;
using Shared;
using Shared.Entity;
using Shared.Validator;

namespace Domain.Entidade
{
    public class TurmaDisciplina : EntityCrud<TurmaDisciplina>
    {
        public override AbstractValidator<TurmaDisciplina> Validador => new TurmaDisciplinaValidator();
        public string DisciplinaId { get; set; }
        public Disciplina Disciplinas { get; set; }
        public string TurmaId { get; set; }
        public Turma Turmas { get; set; }

        public override void PreencherDados(TurmaDisciplina data)
        {
            DisciplinaId = data.DisciplinaId;
        }

        public override ResultadoValidacao Validar()
        {
            return ExecutarValidacaoPadrao(this);
        }
    }

    internal class TurmaDisciplinaValidator : AbstractValidator<TurmaDisciplina>
    {
        public TurmaDisciplinaValidator()
        {
            RuleFor(x => x.DisciplinaId)
               .NotNull().WithMessage(Textos.Geral_Mensagem_Erro_Campo_null)
               .MaximumLength(36);

            RuleFor(x => x.TurmaId)
                .NotNull().WithMessage(Textos.Geral_Mensagem_Erro_Campo_null)
                .MaximumLength(36);
        }
    }
}
