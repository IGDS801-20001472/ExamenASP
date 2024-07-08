using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.Collections.Generic;
using System.Reflection.Emit;
using System.Threading;
using Microsoft.EntityFrameworkCore;
using ExamenAPI.Models;


namespace ExamenAPI
{
    public class ProyectoContext : DbContext
    {
        public ProyectoContext()
        {
        }

        public ProyectoContext(DbContextOptions<ProyectoContext> options)
        : base(options)
        {
        }

        public virtual DbSet<Producto> Producto{ get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) => optionsBuilder.UseSqlServer();

        public DbSet<Producto> Productos { get; set; }
        public DbSet<Categoria> Categorias { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Categoria>()
             .HasKey(c => c.idCategoria); // Definir la clave primaria si no es el nombre por convención

            modelBuilder.Entity<Producto>()
                .HasKey(p => p.idProducto);

            // Configurar la relación uno-a-muchos entre Categoria y Producto
            modelBuilder.Entity<Categoria>()
                .HasMany(c => c.Productos)
                .WithOne(p => p.Categoria)
                .HasForeignKey(p => p.idCategoria);

            base.OnModelCreating(modelBuilder);
        }

    }
}
