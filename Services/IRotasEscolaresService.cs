using NivelamentoTranscolar.Models;

namespace NivelamentoTranscolar.Services;

public interface IRotasEscolaresService
{
    Task<List<RotaEscolar>> ListarAsync();
    Task<RotaEscolar?> ObterPorIdAsync(int id);
    Task<RotaEscolar> CriarAsync(RotaEscolar escola);
    Task<RotaEscolar?> AtualizarAsync(RotaEscolar escola);
    Task<bool> DeletarAsync(int id);
}