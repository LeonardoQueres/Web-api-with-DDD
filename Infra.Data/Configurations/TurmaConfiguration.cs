using Domain.Entidade;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infra.Data.Configurations
{
    public class TurmaConfiguration : IEntityTypeConfiguration<Turma>
    {
        void IEntityTypeConfiguration<Turma>.Configure(EntityTypeBuilder<Turma> builder)
        {
            builder.HasIndex(x => x.Id);
            builder.Property(x => x.Id).HasMaxLength(36);

            builder.Property(x => x.Descricao)
                .HasMaxLength(100)
                .IsRequired();

            builder.Ignore(x => x.turmaAluno);
        }
    }
}
