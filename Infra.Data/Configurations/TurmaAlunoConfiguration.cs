using Domain.Entidade;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infra.Data.Configurations
{
    public class TurmaAlunoConfiguration : IEntityTypeConfiguration<TurmaAluno>
    {
        void IEntityTypeConfiguration<TurmaAluno>.Configure(EntityTypeBuilder<TurmaAluno> builder)
        {
            builder.HasIndex(x => x.Id);
            builder.Property(x => x.Id).HasMaxLength(36);

            builder.HasOne(x => x.Alunos)
               .WithMany(x => x.turmaAluno)
               .HasForeignKey(x => x.AlunoId);
            builder.Property(x => x.AlunoId)
                .HasMaxLength(36);

            builder.HasOne(x => x.Turmas)
               .WithMany(x => x.turmaAluno)
               .HasForeignKey(x => x.TurmaId);

            builder.Property(x => x.TurmaId)
                .HasMaxLength(36);
        }
    }
}
