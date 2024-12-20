using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using Kanban.Models;

namespace Kanban.DAL
{
    public class KanbanContext : DbContext
    {
        public KanbanContext() : base ("KanbanContext") { }

        public DbSet<Area> Area { get; set; }
        public DbSet<AreaTarefa> AreaTarefa { get; set; }
        public DbSet<Comentario> Comentario { get; set; }
        public DbSet<Prioridade> Prioridade { get; set; }
        public DbSet<Registro> Registro { get; set; }
        public DbSet<Responsabilidade> Responsabilidade { get; set; }
        public DbSet<ResponsavelTarefa> ResponsavelTarefa { get; set; }
        public DbSet<StatusTarefa> StatusTarefa { get; set; }
        public DbSet<Tarefa> Tarefa { get; set; }
        public DbSet<Usuario> Usuario { get; set; }
        public DbSet<UsuarioArea> UsuarioArea { get; set; }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Exemplo de chave estrangeira com no action
            modelBuilder.Entity<Tarefa>()
                .HasRequired(t => t.Usuario) // Relacionamento com Usuario
                .WithMany(u => u.TarefaSolicitadas) // Relacionamento inverso
                .HasForeignKey(t => t.UsuarioID)
                .WillCascadeOnDelete(false); // Desabilita a ação de cascata
        }

    }
}