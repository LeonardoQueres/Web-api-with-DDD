using Domain.Entidade;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infra.Data.Configurations
{
    public class AlunoConfiguration : IEntityTypeConfiguration<Aluno>
    {
        void IEntityTypeConfiguration<Aluno>.Configure(EntityTypeBuilder<Aluno> builder)
        {
            builder.HasIndex(x => x.Id);
            builder.Property(x => x.Id).HasMaxLength(36);

            builder.Property(x => x.Matricula)
                .HasMaxLength(20)
                .IsRequired();

            builder.Property(x => x.Nome)
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(x => x.Cpf)
                .HasMaxLength(11)
                .IsRequired();

            builder.Ignore(x => x.turmaAluno);
        }
    }
}
