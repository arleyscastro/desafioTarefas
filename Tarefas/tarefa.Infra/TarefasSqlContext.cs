using Microsoft.EntityFrameworkCore;
using tarefas.Core.Domain.Entitys;

namespace tarefa.Infra
{
    public class TarefasSqlContext : DbContext
    {
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Projeto> Projetos { get; set; }
        public DbSet<Tarefa> Tarefas { get; set; }
        public DbSet<HistoricoTarefa> HistoricoTarefas { get; set; }
        public DbSet<Comentario> Comentarios { get; set; }

        public TarefasSqlContext(DbContextOptions<TarefasSqlContext> options) : base(options)
        {            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Usuario
            modelBuilder.Entity<Usuario>().HasKey(u => u.UsuarioID);
            modelBuilder.Entity<Usuario>().Property(u => u.Nome).IsRequired();
            modelBuilder.Entity<Usuario>().Property(u => u.Email).IsRequired();

            // Projeto
            modelBuilder.Entity<Projeto>().HasKey(p => p.ProjetoID);
            modelBuilder.Entity<Projeto>().Property(p => p.Nome).IsRequired();
            modelBuilder.Entity<Projeto>()
                .HasOne(p => p.Usuario)
                .WithMany(u => u.Projetos)
                .HasForeignKey(p => p.UsuarioID)
                .OnDelete(DeleteBehavior.Cascade);

            // Tarefa
            modelBuilder.Entity<Tarefa>().HasKey(t => t.TarefaID);
            modelBuilder.Entity<Tarefa>().Property(t => t.Titulo).IsRequired();
            modelBuilder.Entity<Tarefa>().Property(t => t.Descricao).IsRequired();
            modelBuilder.Entity<Tarefa>().Property(t => t.Status).IsRequired();
            modelBuilder.Entity<Tarefa>().Property(t => t.Prioridade).IsRequired();
            modelBuilder.Entity<Tarefa>().Property(t => t.DataVencimento).IsRequired();
            modelBuilder.Entity<Tarefa>()
                .HasOne(t => t.Projeto)
                .WithMany(p => p.Tarefas)
                .HasForeignKey(t => t.ProjetoID)
                .OnDelete(DeleteBehavior.Cascade);

            // HistoricoTarefa
            modelBuilder.Entity<HistoricoTarefa>().HasKey(ht => ht.HistoricoID);
            modelBuilder.Entity<HistoricoTarefa>().Property(ht => ht.DataAlteracao).IsRequired();
            modelBuilder.Entity<HistoricoTarefa>().Property(ht => ht.Detalhes).IsRequired();
            modelBuilder.Entity<HistoricoTarefa>()
                .HasOne(ht => ht.Tarefa)
                .WithMany(t => t.Historico)
                .HasForeignKey(ht => ht.TarefaID)
                .OnDelete(DeleteBehavior.Cascade);

            // Comentario
            modelBuilder.Entity<Comentario>().HasKey(c => c.ComentarioID);
            modelBuilder.Entity<Comentario>().Property(c => c.Texto).IsRequired();
            modelBuilder.Entity<Comentario>().Property(c => c.DataCriacao).IsRequired();
            modelBuilder.Entity<Comentario>()
                .HasOne(c => c.Tarefa)
                .WithMany(t => t.Comentarios)
                .HasForeignKey(c => c.TarefaID)
                .OnDelete(DeleteBehavior.Cascade);

            base.OnModelCreating(modelBuilder);
        }

        public override int SaveChanges()
        {

            foreach (var entry in ChangeTracker.Entries().Where(entry => entry.Entity.GetType().GetProperty("DataCadastro") != null))
            {
                if (entry.State == EntityState.Added)
                    entry.Property("DataCadastro").CurrentValue = DateTime.Now;

                if (entry.State == EntityState.Modified)
                    entry.Property("DataCadastro").IsModified = false;
            }

            return base.SaveChanges();
        }
    }
}
