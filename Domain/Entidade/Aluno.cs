using FluentValidation;
using Shared;
using Shared.Entity;
using Shared.Validator;
using System.Collections.Generic;

namespace Domain.Entidade
{
    public class Aluno : EntityCrud<Aluno>
    {
        public string Matricula { get; set; }
        public string Nome { get; set; }
        public string Cpf { get; set; }

        public IEnumerable<TurmaAluno> turmaAluno { get; set; }

        public override AbstractValidator<Aluno> Validador => new AlunoValidator();

        public override void PreencherDados(Aluno data)
        {
            Matricula = data.Matricula;
            Nome = data.Nome;
            Cpf = data.Cpf;
        }

        public override ResultadoValidacao Validar()
        {
            return ExecutarValidacaoPadrao(this);
        }
    }

    internal class AlunoValidator : AbstractValidator<Aluno>
    {
        public AlunoValidator()
        {
            RuleFor(x => x.Matricula)
                .NotNull().WithMessage(Textos.Geral_Mensagem_Erro_Campo_null)
                .MaximumLength(20);

            RuleFor(x => x.Nome)
               .NotNull().WithMessage(Textos.Geral_Mensagem_Erro_Campo_null)
               .MaximumLength(100);

            RuleFor(x => x.Cpf)
                .NotNull().WithMessage(Textos.Geral_Mensagem_Erro_Campo_null)
                .MinimumLength(11).WithMessage(Textos.Geral_Mensagem_Erro_Tamanho_Campo)
                .MaximumLength(11).WithMessage(Textos.Geral_Mensagem_Erro_Tamanho_Campo)
                .CPFValido();
        }
    }
}
