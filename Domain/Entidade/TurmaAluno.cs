using FluentValidation;
using Shared;
using Shared.Entity;
using Shared.Validator;

namespace Domain.Entidade
{
    public class TurmaAluno : EntityCrud<TurmaAluno>
    {
        public override AbstractValidator<TurmaAluno> Validador => new AlunoTurmaValidator();

        public string AlunoId { get; set; }
        public Aluno Alunos { get; set; }
        public string TurmaId { get; set; }
        public Turma Turmas { get; set; }

        public override void PreencherDados(TurmaAluno data)
        {
            AlunoId = data.AlunoId;
        }

        public override ResultadoValidacao Validar()
        {
            return ExecutarValidacaoPadrao(this);
        }
    }

    internal class AlunoTurmaValidator : AbstractValidator<TurmaAluno>
    {
        public AlunoTurmaValidator()
        {
            RuleFor(x => x.AlunoId)
                .NotNull().WithMessage(Textos.Geral_Mensagem_Erro_Campo_null)
                .MaximumLength(36);

            RuleFor(x => x.TurmaId)
                .NotNull().WithMessage(Textos.Geral_Mensagem_Erro_Campo_null)
                .MaximumLength(36);
        }
    }
}
