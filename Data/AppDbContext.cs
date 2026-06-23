using Microsoft.EntityFrameworkCore;
using NivelamentoTranscolar.Models;

namespace NivelamentoTranscolar.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    public DbSet<Escola> Escolas => Set<Escola>();
    public DbSet<Aluno> Alunos => Set<Aluno>();
    public DbSet<RotaEscolar> RotasEscolares => Set<RotaEscolar>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Aluno>()
            .HasIndex(a => a.Cpf)
            .IsUnique();
    }
}