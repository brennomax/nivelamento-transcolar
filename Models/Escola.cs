namespace NivelamentoTranscolar.Models;

public class Escola
{
    public int Id { get; set; }
    public string Nome { get; set; } = string.Empty;
    public int CodigoIbge { get; set; }
    public string Municipio { get; set; } = string.Empty;
    public string Endereco { get; set; } = string.Empty;
    public string Telefone { get; set; } = string.Empty;
    public bool Ativa { get; set; }
    
    public List<Aluno> Alunos { get; set; } = new();
    
}