using Microsoft.EntityFrameworkCore;
using NivelamentoTranscolar.Data;
using NivelamentoTranscolar.Models;

namespace NivelamentoTranscolar.Services;

public class EscolasService : IEscolasService
{
    private readonly AppDbContext _db;

    public EscolasService(AppDbContext db)
    {
        _db = db;
    }

    // Listar todas
    public async Task<List<Escola>> ListarAsync()
    {
        return await _db.Escolas
            .OrderBy(e => e.Nome)
            .ToListAsync();
    }

    // Buscar uma por Id ou retorna null se não existir
    public async Task<Escola?> ObterPorIdAsync(int id)
    {
        return await _db.Escolas
            .FirstOrDefaultAsync(e => e.Id == id);
    }
    
    // Criar uma escola
    public async Task<Escola> CriarAsync(Escola escola)
    {
        _db.Escolas.Add(escola);
        await _db.SaveChangesAsync();
        return escola;
    }
    
    // Atualiza uma escola existente. Retorna a escola atualizada, ou null se não existir.
    public async Task<Escola?> AtualizarAsync(Escola escola)
    {
        var escolaExistente = await _db.Escolas
            .FirstOrDefaultAsync(e => e.Id == escola.Id);

        if (escolaExistente is null)
        {
            return null;
        }

        escolaExistente.Nome = escola.Nome;
        escolaExistente.Municipio = escola.Municipio;
        escolaExistente.CodigoIbge = escola.CodigoIbge;
        escolaExistente.Endereco = escola.Endereco;
        escolaExistente.Telefone = escola.Telefone;
        escolaExistente.Ativa = escola.Ativa;
        
        await _db.SaveChangesAsync();
        return escolaExistente;
    }
    
    // Retorna true e se existe, false se não encontrou
    public async Task<bool> DeletarAsync(int id)
    {
        var escola = await _db.Escolas
            .FirstOrDefaultAsync(e => e.Id == id);
        
        if (escola is null)
        {
            return false;
        }
        
        _db.Escolas.Remove(escola);
        await _db.SaveChangesAsync();
        return true;
    }
}