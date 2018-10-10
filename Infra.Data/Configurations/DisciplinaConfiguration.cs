using Domain.Entidade;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infra.Data.Configurations
{
    public class DisciplinaConfiguration : IEntityTypeConfiguration<Disciplina>
    {
        void IEntityTypeConfiguration<Disciplina>.Configure(EntityTypeBuilder<Disciplina> builder)
        {
            builder.HasIndex(x => x.Id);
            builder.Property(x => x.Id).HasMaxLength(36);

            builder.Property(x => x.Descricao)
                .HasMaxLength(100)
                .IsRequired();

            builder.Ignore(x => x.turmaDisciplina);
        }
    }
}
