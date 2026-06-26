using Microsoft.EntityFrameworkCore;
using NivelamentoTranscolar.Data;
using NivelamentoTranscolar.Models;

namespace NivelamentoTranscolar.Services;

public class RotasEscolaresService : IRotasEscolaresService
{
    private readonly AppDbContext _db;

    public RotasEscolaresService(AppDbContext db)
    {
        _db = db;
    }

    public async Task<List<RotaEscolar>> ListarAsync()
    {
        return await _db.RotasEscolares
            .OrderBy(e => e.Nome)
            .ToListAsync();
    }

    // Buscar uma por Id ou retorna null se não existir
    public async Task<RotaEscolar?> ObterPorIdAsync(int id)
    {
        return await _db.RotasEscolares
            .FirstOrDefaultAsync(e => e.Id == id);
    }
    
    // Criar uma escola
    public async Task<RotaEscolar> CriarAsync(RotaEscolar rota)
    {
        _db.RotasEscolares.Add(rota);
        await _db.SaveChangesAsync();
        return rota;
    }
    
    // Atualiza uma escola existente. Retorna a escola atualizada, ou null se não existir.
    public async Task<RotaEscolar?> AtualizarAsync(RotaEscolar rota)
    {
        var rotaExistente = await _db.RotasEscolares
            .FirstOrDefaultAsync(e => e.Id == rota.Id);

        if (rotaExistente is null)
        {
            return null;
        }

        rotaExistente.Nome = rota.Nome;
        rotaExistente.Tipo = rota.Tipo;
        rotaExistente.DistanciaKm = rota.DistanciaKm;
        rotaExistente.Descricao = rota.Descricao;
        rotaExistente.Horario = rota.Horario;
        rotaExistente.Ativa = rota.Ativa;
        
        await _db.SaveChangesAsync();
        return rotaExistente;
    }
    
    // Retorna true e se existe, false se não encontrou
    public async Task<bool> DeletarAsync(int id)
    {
        var rota = await _db.RotasEscolares
            .FirstOrDefaultAsync(e => e.Id == id);
        
        if (rota is null)
        {
            return false;
        }
        
        _db.RotasEscolares.Remove(rota);
        await _db.SaveChangesAsync();
        return true;
    }
}