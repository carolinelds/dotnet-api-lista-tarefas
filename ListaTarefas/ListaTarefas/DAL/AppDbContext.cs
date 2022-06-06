using Microsoft.EntityFrameworkCore;
using ListaTarefas.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ListaTarefas.DAL
{
    public class AppDbContext: DbContext
    {
        public virtual DbSet<Tarefa> Tarefas { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Tarefa>(entity =>
            {
                entity.Property(x => x.Titulo).IsUnicode(false);
                entity.Property(x => x.Descricao).IsUnicode(false);
            });
        }


    }
}
