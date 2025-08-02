using cadastro_pessoas_fisicas_juridicas_api.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Reflection.Emit;

namespace cadastro_pessoas_fisicas_juridicas_api.Infrastructure.Repositories
{
    public class AppDbContext : DbContext
    {
        public DbSet<PessoaFisica> PessoaFisica { get; set; }
        public DbSet<PessoaJuridica> PessoaJuridica { get; set; }
        public DbSet<Endereco> Enderecos { get; set; }
        public DbSet<Telefone> Telefones { get; set; }
        public DbSet<PresencaOnLine> PresencasOnline { get; set; }
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {



            base.OnModelCreating(modelBuilder);

            // PessoaFisica → Telefones
            modelBuilder.Entity<Telefone>()
                .HasOne(t => t.PessoaFisica)
                .WithMany(p => p.Telefones)
                .HasForeignKey(t => t.PessoaFisicaId)
                .OnDelete(DeleteBehavior.Restrict);

            // PessoaJuridica → Telefones
            modelBuilder.Entity<Telefone>()
                .HasOne(t => t.PessoaJuridica)
                .WithMany(p => p.Telefones)
                .HasForeignKey(t => t.PessoaJuridicaId)
                .OnDelete(DeleteBehavior.Restrict);

            // PessoaFisica → Endereco (1:1)
            modelBuilder.Entity<Endereco>()
                .HasOne(e => e.PessoaFisica)
                .WithOne(p => p.Endereco)
                .HasForeignKey<Endereco>(e => e.PessoaFisicaId)
                .OnDelete(DeleteBehavior.Restrict);

            // PessoaJuridica → Endereco (1:1)
            modelBuilder.Entity<Endereco>()
                .HasOne(e => e.PessoaJuridica)
                .WithOne(p => p.Endereco)
                .HasForeignKey<Endereco>(e => e.PessoaJuridicaId)
                .OnDelete(DeleteBehavior.Restrict);

            // PessoaFisica → PresencaOnline (1:1)
            modelBuilder.Entity<PresencaOnLine>()
                .HasOne(p => p.PessoaFisica)
                .WithOne(pf => pf.PresencaOnline)
                .HasForeignKey<PresencaOnLine>(p => p.PessoaFisicaId)
                .OnDelete(DeleteBehavior.Restrict);

            // PessoaJuridica → PresencaOnline (1:1)
            modelBuilder.Entity<PresencaOnLine>()
                .HasOne(p => p.PessoaJuridica)
                .WithOne(pj => pj.PresencaOnline)
                .HasForeignKey<PresencaOnLine>(p => p.PessoaJuridicaId)
                .OnDelete(DeleteBehavior.Restrict);

/*
            foreach (var entityType in modelBuilder.Model.GetEntityTypes())
            {
                foreach (var property in entityType.GetProperties())
                {
                    if (property.ClrType == typeof(DateTime) || property.ClrType == typeof(DateTime?))
                    {
                        modelBuilder.Entity(entityType.ClrType).Property(property.Name)
                            .HasConversion(
                                v => v.Kind == DateTimeKind.Unspecified ? DateTime.SpecifyKind(v, DateTimeKind.Utc) : v,
                                v => DateTime.SpecifyKind(v, DateTimeKind.Utc));
                    }
                }
            }

*/




        }
    }
}
