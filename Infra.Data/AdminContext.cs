using Domain.Entidade;
using Infra.Data.Configurations;
using Microsoft.EntityFrameworkCore;

namespace Infra.Data
{
    public class AdminContext : DbContext
    {
        public AdminContext(DbContextOptions<AdminContext> options)
            : base(options)
        {
        }

        // Deixar em ordem alfabetica de entidade para ficar mais facil de procurar
        public DbSet<Aluno> Alunos { get; set; }
        public DbSet<TurmaAluno> TurmaAluno { get; set; }
        public DbSet<TurmaDisciplina> TurmaDisciplinas { get; set; }
        public DbSet<Disciplina> Disciplinas { get; set; }
        public DbSet<Turma> Turmas { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Deixar em ordem alfabetica de entidade para ficar mais facil de procurar          
            modelBuilder.ApplyConfiguration(new AlunoConfiguration());
            modelBuilder.ApplyConfiguration(new TurmaAlunoConfiguration());
            modelBuilder.ApplyConfiguration(new TurmaDisciplinaConfiguration());
            modelBuilder.ApplyConfiguration(new DisciplinaConfiguration());
            modelBuilder.ApplyConfiguration(new TurmaConfiguration());
        }
    }
}
