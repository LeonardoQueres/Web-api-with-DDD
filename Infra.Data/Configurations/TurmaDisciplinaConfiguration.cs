using Domain.Entidade;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infra.Data.Configurations
{
    public class TurmaDisciplinaConfiguration : IEntityTypeConfiguration<TurmaDisciplina>
    {
        void IEntityTypeConfiguration<TurmaDisciplina>.Configure(EntityTypeBuilder<TurmaDisciplina> builder)
        {
            builder.HasIndex(x => x.Id);
            builder.Property(x => x.Id).HasMaxLength(36);

            builder.HasOne(x => x.Disciplinas)
               .WithMany(x => x.turmaDisciplina)
               .HasForeignKey(x => x.DisciplinaId);

            builder.Property(x => x.DisciplinaId)
                .HasMaxLength(36);

            builder.HasOne(x => x.Turmas)
               .WithMany(x => x.turmaDisciplina)
               .HasForeignKey(x => x.TurmaId);

            builder.Property(x => x.TurmaId)
                .HasMaxLength(36);
        }
    }
}
