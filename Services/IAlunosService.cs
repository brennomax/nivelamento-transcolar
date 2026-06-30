using NivelamentoTranscolar.Models;

namespace NivelamentoTranscolar.Services;

public interface IAlunosService
{
    Task<List<Aluno>> ListarAsync();
    Task<Aluno?> ObterPorIdAsync(int id);
    Task<Aluno> CriarAsync(Aluno aluno);
    Task<Aluno?> AtualizarAsync(Aluno aluno);
    Task<bool> DeletarAsync(int id);
}