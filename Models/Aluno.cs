namespace NivelamentoTranscolar.Models;

public class Aluno
{
    public int Id { get; set; }
    public int EscolaId { get; set; }
    public Escola Escola { get; set; } = null!;
    public int? RotaEscolarId { get; set; }
    public RotaEscolar? RotaEscolar { get; set; }
    public string Nome { get; set; } = string.Empty;
    public string Cpf {  get; set; } = string.Empty;
    public DateTime DataNascimento { get; set; }
    public bool Ativo { get; set; }
    
}