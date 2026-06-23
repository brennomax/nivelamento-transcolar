using NivelamentoTranscolar.Models;

namespace NivelamentoTranscolar.Services;

public interface IEscolasService
{
    Task<List<Escola>> ListarAsync();
    Task<Escola?> ObterPorIdAsync(int id);
    Task<Escola> CriarAsync(Escola escola);
    Task<Escola?> AtualizarAsync(Escola escola);
    Task<bool> DeletarAsync(int id);
}