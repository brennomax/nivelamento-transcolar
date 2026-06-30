using Microsoft.EntityFrameworkCore;
using NivelamentoTranscolar.Data;
using NivelamentoTranscolar.Models;

namespace NivelamentoTranscolar.Services;

public class AlunosService : IAlunosService
{
    private readonly AppDbContext _db;

    public AlunosService(AppDbContext db)
    {
        _db = db;
    }

    public async Task<List<Aluno>> ListarAsync()
    {
        return await _db.Alunos
            .Include(a => a.Escola)
            .Include(a => a.RotaEscolar)
            .OrderBy(a => a.Nome)
            .ToListAsync();
    }

    public async Task<Aluno?> ObterPorIdAsync(int id)
    {
        return await _db.Alunos
            .Include(a => a.Escola)
            .Include(a => a.RotaEscolar)
            .FirstOrDefaultAsync(a => a.Id == id);
    }

    public async Task<Aluno> CriarAsync(Aluno aluno)
    {
        bool cpfJaExiste = await _db.Alunos
            .AnyAsync(a => a.Cpf == aluno.Cpf);

        if (cpfJaExiste)
        {
            throw new InvalidOperationException(
                $"Já existe um aluno cadastrado com o CPF {aluno.Cpf}.");
        }

        _db.Alunos.Add(aluno);
        await _db.SaveChangesAsync();
        return aluno;
    }

    public async Task<Aluno?> AtualizarAsync(Aluno aluno)
    {
        var alunoExistente = await _db.Alunos
            .FirstOrDefaultAsync(a => a.Id == aluno.Id);

        if (alunoExistente is null)
        {
            return null;
        }

        bool cpfDeOutro = await _db.Alunos
            .AnyAsync(a => a.Cpf == aluno.Cpf && a.Id != aluno.Id);

        if (cpfDeOutro)
        {
            throw new InvalidOperationException(
                $"O CPF {aluno.Cpf} já pertence a outro aluno.");
        }

        alunoExistente.Nome = aluno.Nome;
        alunoExistente.Cpf = aluno.Cpf;
        alunoExistente.DataNascimento = aluno.DataNascimento;
        alunoExistente.Ativo = aluno.Ativo;
        alunoExistente.EscolaId = aluno.EscolaId;
        alunoExistente.RotaEscolarId = aluno.RotaEscolarId;

        await _db.SaveChangesAsync();
        return alunoExistente;
    }

    public async Task<bool> DeletarAsync(int id)
    {
        var aluno = await _db.Alunos
            .FirstOrDefaultAsync(a => a.Id == id);

        if (aluno is null)
        {
            return false;
        }

        _db.Alunos.Remove(aluno);
        await _db.SaveChangesAsync();
        return true;
    }
}